using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public abstract class AutoController : MonoBehaviour
{
    internal RCC_CarControllerV3 carController = new RCC_CarControllerV3();
    //Position, velocity and acceleration of cars
    public Vector2 p;
    public Vector2 v;
    public Vector2 a;
    //Data of the car
    public Data data = new Data();
    public PlayerData playerData = new PlayerData();
    //Input of CarController
    public float steer = 0;
    public float throttle = 0;
    public float rThrottle = 0;
    public float brake = 0;
    public float handbrake = 0;
    //If steer is smooth
    public bool smoothEnabled = true;
    public float smooth = 20;//50为完全不缓动，0为完全不动
    //limit of velocity
    public bool aimVEnabled = false;
    public float aimV = 0;
    //correct the position of cars
    public bool correctEnabled = false;
    public Vector2 centerPos = new Vector2();
    public Vector2 centerForward = new Vector2();
    public float correctThreshold = 0.01f;
    public void startCorrect()
    {
        centerPos.x = gameObject.transform.position.x;
        centerPos.y = gameObject.transform.position.z;
        gameObject.transform.forward = new Vector3(centerForward.x, 0, centerForward.y).normalized;
        correctEnabled = true;
        return;
    }
    public bool newCorrect = true;
    public bool newCorrectOnTheOrigin = true;
    public abstract void Correct();

    //drive straightforward
    public void straight(float _v, float _throttle)
    {
        startCorrect();
        aimVEnabled = true;
        aimV = _v;
        if (_throttle > 0)
        {
            brake = 0;
            throttle = _throttle;
            rThrottle = _throttle;
        }
        else
        {
            throttle = 0;
            brake = -_throttle;
        }
        return;
    }
    //change Lane
    public void changeLane(float _v, float _throttle, float _steer, float _t1, float _t2)
    {
        newCorrectOnTheOrigin = !newCorrectOnTheOrigin;
        newCorrect = false;
        correctEnabled = false;
        aimVEnabled = true;
        aimV = _v;
        if (_throttle > 0)
        {
            brake = 0;
            throttle = _throttle;
            rThrottle = _throttle;
        }
        else
        {
            throttle = 0;
            brake = -_throttle;
        }
        StartCoroutine(IchangeLane(_v, _throttle, _steer, _t1, _t2));
        return;
    }
    //Coordinates of four corners on the expressway
    public static Vector2 turnP1 = new Vector2(201f, -2252.4f);
    public static Vector2 turnP2 = new Vector2(-346.26f, -2299.5f);
    public static Vector2 turnP3 = new Vector2(-392.34f, 2049.2f);
    public static Vector2 turnP4 = new Vector2(156.72f, 2096.4f);
    public void turnRound(float _steer)
    {
        correctEnabled = false;
        steer = _steer;
        turnEnabled = true;
    }
    public void endTurn()
    {
        Vector2 fd = new Vector2(gameObject.transform.forward.x, gameObject.transform.forward.z);
        if (Vector2.Dot(fd, centerForward)<=0.01)
        {
            Debug.Log(p);
            steer = 0;
            carController.steerInput = 0;
            correctEnabled = true;
            turnEnabled = false;
            centerPos = p;
            if (Mathf.Abs(fd.x) > Mathf.Abs(fd.y)) fd = new Vector2(fd.x, 0).normalized;
            else fd = new Vector2(0, fd.y).normalized;
            centerForward = fd;
        }
    }
    public bool turnEnabled = false;

    void Awake()
    {
        //initialize the Car Controller
        carController = GetComponent<RCC_CarControllerV3>();
        carController.externalController = true;
        //position
        p.x = gameObject.transform.position.x;
        p.y = gameObject.transform.position.z;
        //correct
        centerForward.x = gameObject.transform.forward.x;
        centerForward.y = gameObject.transform.forward.z;
        centerForward.Normalize();
    }

    void FixedUpdate()
    {
        FeedRCC();
        if (correctEnabled) Correct();
        getData();
        newTurn();
    }
    //Pass parameters to Car Controller
    public void FeedRCC()
    {
        if (aimVEnabled)
        {
            if (v.magnitude > aimV) rThrottle -= 0.01f;
            else rThrottle = throttle;
        }
        // Feeding gasInput of the RCC.
        if (!carController.changingGear && !carController.cutGas)
            carController.throttleInput = (carController.direction == 1 ? Mathf.Clamp01(rThrottle) : Mathf.Clamp01(brake));
        else
            carController.throttleInput = 0f;

        if (!carController.changingGear && !carController.cutGas)
            carController.brakeInput = (carController.direction == 1 ? Mathf.Clamp01(brake) : Mathf.Clamp01(rThrottle));
        else
            carController.brakeInput = 0f;

        // Feeding steerInput of the RCC.
        if (smoothEnabled)
            carController.steerInput = Mathf.Lerp(carController.steerInput, steer, Time.deltaTime * smooth);
        else
            carController.steerInput = steer;

        carController.handbrakeInput = handbrake;
    }
    public abstract void getData();
    public IEnumerator IchangeLane(float _v, float _throttle, float _steer, float _t1, float _t2)
    {
        steer = _steer;
        yield return new WaitForSeconds(_t1);
        steer = -_steer;
        yield return new WaitForSeconds(_t2);
        steer = 0;
        straight(_v, _throttle);
        if (newCorrectOnTheOrigin) newCorrect = true;
    }
    /*public IEnumerator IendTurn(float _t)
    {
        yield return new WaitForSeconds(_t);
        steer = 0;
        centerPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
        centerForward = new Vector2(centerForward.y, -centerForward.x);
        gameObject.transform.forward = new Vector3(centerForward.x, gameObject.transform.forward.y, centerForward.y).normalized;
        correctEnabled = true;
        newTurnFlag = false;
    }*/
    public abstract void remove();
    public abstract void newTurn();
}