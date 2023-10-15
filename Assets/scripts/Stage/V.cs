using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V
{
    // Start is called before the first frame update
    public void Init()
    {
        int stage_id = 5;
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
        //80s
        //PHASE 0
        phase_id = 0;
        //car 0 事件7，前车减速
        car = new expEvent();
        car.type = "Jeep";
        car.time = 5;
        car.coord = new Vector2(0f, 230f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 18, 1f));
        car.Moves.Add(new expMove(49f, 1, 5, -0.3f));
        car.Moves.Add(new expMove(1.55f, 1, 23, 1f));
        car.Moves.Add(new expMove(70, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 高速驶过
        car = new expEvent();
        car.type = "T-100";
        car.time = 10;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 35, 1f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Pickup";
        car.time = 20;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 23, 1f));
        car.Moves.Add(new expMove(45, 1, 16, 0f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Coupe";
        car.time = 45;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 23, 1f));
        car.Moves.Add(new expMove(40, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
