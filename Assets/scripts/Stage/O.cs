using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is only used to set the surrounding vehicles and their movements for the period of time before the first dangerous event
public class O
{
    public void Init()
    {
        int stage_id = 0;
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

        //Add surrounding vehicles for this stage
        expEvent car;
        //85s
        //PHASE 1
        phase_id = 1;
        //car 高速驶过
        car = new expEvent();
        car.type = "Skyline";
        car.time = 5;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 32, 1f));
        car.Moves.Add(new expMove(60, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 前方车辆
        car = new expEvent();
        car.type = "Skyline";
        car.time = 40;
        car.coord = new Vector2(0f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Pickup";
        car.time = 60;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(23, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Jeep";
        car.time = 5;
        car.coord = new Vector2(3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(23, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
