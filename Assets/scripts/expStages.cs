using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is used to set the motion of player vehicles and surrounding vehicles throughout the entire experiment
public class expStages: MonoBehaviour
{
    //List of player movements
    public static List<expMove> playerMoves = new List<expMove>();
    //List of hazardous events
    public static List<expStage> list = new List<expStage>();

    private void Start()
    {
        for (int i=0; i<11; i++)
        {
            list.Add(new expStage());
        }
        //The start time of each hazardous event
        list[0].time = 0;
        list[1].time = 85;
        list[2].time = 195;
        list[3].time = 355;
        list[4].time = 445;
        list[5].time = 595;
        list[6].time = 675;
        list[7].time = 830;
        list[8].time = 910;
        list[9].time = 1040;
        list[10].time = 1200;
        O o = new O();
        o.Init();
        I _i = new I();
        _i.Init();
        II ii = new II();
        ii.Init();
        III iii = new III();
        iii.Init();
        IV iv = new IV();
        iv.Init();
        V v = new V();
        v.Init();
        VI vi = new VI();
        vi.Init();
        VII vii = new VII();
        vii.Init();
        VIII viii = new VIII();
        viii.Init();
        IX ix = new IX();
        ix.Init();
        X _x = new X();
        _x.Init();

        //Add movement of player vehicles
        playerMoves.Add(new expMove(0, 1, 20, 1f));
        playerMoves.Add(new expMove(936, 2, 20, 1f, -0.17f, 0.8f, 1.0f));
        playerMoves.Add(new expMove(7, 2, 20, 1f, 0.17f, 0.8f, 1.0f));
        playerMoves.Add(new expMove(1.9f, 1, 20, 1f));
    }
    private void Update()
    {
        Debug.Log(Time.time);
    }
}