using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VI
{
    // Start is called before the first frame update
    public void Init()
    {
        int stage_id = 6;
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
        //155
        //PHASE 0
        phase_id = 0;
        //car 0 事件8，左前车急刹车
        car = new expEvent();
        car.type = "Coupe";
        car.time = 0;
        car.coord = new Vector2(-3f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 17, 1f));
        car.Moves.Add(new expMove(50, 1, 0, -1f));//15->14
        car.Moves.Add(new expMove(2.7f, 1, 0, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 前方车辆
        car = new expEvent();
        car.type = "Sedan";
        car.time = 100;
        car.coord = new Vector2(0f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 20, 1f));
        car.Moves.Add(new expMove(10, 1, 25, 1f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Pickup";
        car.time = 85;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(32, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 慢速车辆
        car = new expEvent();
        car.type = "Truck";
        car.time = 50;
        car.coord = new Vector2(3f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 15, 1f));
        car.Moves.Add(new expMove(90, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
