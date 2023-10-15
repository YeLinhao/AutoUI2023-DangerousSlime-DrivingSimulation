using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//һ������һ������
public class expMove
{
    //���ʱ��
    public float time;
    public int movement;//1.ֱ��2.���3.ת��
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
//һ����
public class expEvent
{
    public string type;
    public float time;
    public Vector2 coord;
    public List<expMove> Moves = new List<expMove>();
}
//һ��·
public class expPhase
{
    public bool done = false;
    public float time;
    public List<expEvent> Events = new List<expEvent>();
}
//һ���¼�
public class expStage
{
    public float time;
    public List<expPhase> Phases = new List<expPhase>();
}