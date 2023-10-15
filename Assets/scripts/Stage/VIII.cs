using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIII
{
    // Start is called before the first frame update
    public void Init()
    {
        int stage_id = 8;
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
         //130s
        //PHASE 0
        phase_id = 0;
        //car 0 事件5，一车停下
        car = new expEvent();
        car.type = "Skala";
        car.time = 5;
        car.coord = new Vector2(0f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 19, 1f));
        car.Moves.Add(new expMove(17.3f, 1, 0, -0.8f));
        car.Moves.Add(new expMove(2.5f, 1, 0, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 前方车辆
        car = new expEvent();
        car.type = "Skyline";
        car.time = 40;
        car.coord = new Vector2(-3f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Jeep";
        car.time = 65;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(23, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Skala";
        car.time = 55;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(33, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 高速驶过
        car = new expEvent();
        car.type = "Sedan";
        car.time = 60;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(100, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
