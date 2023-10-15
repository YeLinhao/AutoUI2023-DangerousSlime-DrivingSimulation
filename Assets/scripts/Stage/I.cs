using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is only used to set the surrounding vehicles and their movements for the period of time before the second dangerous event
public class I
{
    // Start is called before the first frame update
    public void Init()
    {
        int stage_id = 1;
        int phase_id = 0;
        int phase_number = 3;
        expStages.list[stage_id].Phases = new List<expPhase>();
        for (int i=0; i<phase_number; i++)
        {
            expStages.list[stage_id].Phases.Add(new expPhase());
        }
        expStages.list[stage_id].Phases[0].time = 0;
        expStages.list[stage_id].Phases[1].time = 0;
        expStages.list[stage_id].Phases[2].time = 0;
        expStages.list[stage_id].Phases[phase_id].Events = new List<expEvent>();

        expEvent car;
        //110s
        //PHASE 0
        phase_id = 0;
        //car 0 事件2，前车减速
        car = new expEvent();
        car.type = "Jeep";
        car.time = 10;//5->15
        car.coord = new Vector2(0f, 190f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 18, 1f));
        car.Moves.Add(new expMove(32f, 1, 5, -0.4f));//15->20->17
        car.Moves.Add(new expMove(1f, 1, 25, 1f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 高速驶过
        car = new expEvent();
        car.type = "Skyline";
        car.time = 10;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 35, 1f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 高速驶过
        car = new expEvent();
        car.type = "T-100";
        car.time = 60;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 40, 1f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Jeep";
        car.time = 70;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 26, 1f));
        car.Moves.Add(new expMove(20, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
