using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IX
{
    // Start is called before the first frame update
    public void Init()
    {
        int stage_id = 9;
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
        //160s
        //PHASE 0
        phase_id = 0;
        //car 0 事件9，前车急刹车
        car = new expEvent();
        car.type = "Skyline";
        car.time = 0;//5->15->10->12
        car.coord = new Vector2(0f, 190f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 17f, 1f));
        car.Moves.Add(new expMove(42f, 1, 5, -1f));//13
        car.Moves.Add(new expMove(2f, 1, 20, 1f));
        car.Moves.Add(new expMove(1.5f, 1, 30, 1f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Jeep";
        car.time = 0;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 26, 1f));
        car.Moves.Add(new expMove(30, 1, 16, 0f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 慢速车辆
        car = new expEvent();
        car.type = "Truck";
        car.time = 70;//80->70
        car.coord = new Vector2(3f, 300f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 15, 1f));
        car.Moves.Add(new expMove(90, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 高速驶过
        car = new expEvent();
        car.type = "Skyline";
        car.time = 110;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 40, 1f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
