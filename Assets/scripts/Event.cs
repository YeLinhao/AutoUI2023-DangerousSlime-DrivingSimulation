using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一辆车的一个动作
public class expMove
{
    //相对时间
    public float time;
    public int movement;//1.直行2.变道3.转弯
    public float v;
    public float throttle;
    public float steer;
    public float t1;
    public float t2;
    public expMove(float _time, int _movement, float _v, float _throttle)
    {
        time = _time;
        movement = _movement;
        if (movement == 1)
        {
            v = _v;
            throttle = _throttle;
        }
        else
        {
            steer = _v;
            t1 = _throttle;
        }
    }
    public expMove(float _time, int _movement, float _v, float _throttle, float _steer, float _t1, float _t2)
    {
        time = _time;
        movement = _movement;
        v = _v;
        throttle = _throttle;
        steer = _steer;
        t1 = _t1;
        t2 = _t2;
    }
}
//一辆车
public class expEvent
{
    public string type;
    public float time;
    public Vector2 coord;
    public List<expMove> Moves = new List<expMove>();
}
//一段路
public class expPhase
{
    public bool done = false;
    public float time;
    public List<expEvent> Events = new List<expEvent>();
}
//一个事件
public class expStage
{
    public float time;
    public List<expPhase> Phases = new List<expPhase>();
}