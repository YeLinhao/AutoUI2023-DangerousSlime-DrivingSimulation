using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public List<PlayerDataNode> dataList = new List<PlayerDataNode>();
}
[System.Serializable]
public class PlayerDataNode
{
    public Vector2 p;
    public Vector2 v;
    public Vector2 a;
    public float t;
    public Vector2 forward;

    public PlayerDataNode(Vector2 _p, Vector2 _v, Vector2 _a, float _t, Vector2 _forward)
    {
        p = _p;
        v = _v;
        a = _a;
        t = _t;
        forward = _forward;
    }
}


public class AllData
{
    public List<Data> allDataList = new List<Data>();
}
[System.Serializable]
public class Data
{
    public float time;
    public string type;
    public List<DataNode> dataList = new List<DataNode>();
}
[System.Serializable]
public class DataNode
{
    public Vector2 p;
    public Vector2 v;
    public Vector2 a;
    public float t;

    public DataNode(Vector2 _p, Vector2 _v, Vector2 _a, float _t)
    {
        p=_p;
        v=_v;
        a=_a;
        t = _t;
    }
}
