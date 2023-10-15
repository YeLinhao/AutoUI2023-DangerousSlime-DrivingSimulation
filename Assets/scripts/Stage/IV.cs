using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IV
{
    // Start is called before the first frame update
    public void Init()
    {
        int stage_id = 4;
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
        //150s
        //PHASE 0
        phase_id = 0;
        //car 0 事件1，前车减速
        car = new expEvent();
        car.type = "Skala";
        car.time = 10;//5->15
        car.coord = new Vector2(0f, 230f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 18, 1f));
        car.Moves.Add(new expMove(32f, 1, 5, -0.4f));//15->20->17
        car.Moves.Add(new expMove(1f, 1, 25, 1f));
        car.Moves.Add(new expMove(50, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 慢速车辆
        car = new expEvent();
        car.type = "Truck";
        car.time = 35;//80->70
        car.coord = new Vector2(3f, 300f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 15, 1f));
        car.Moves.Add(new expMove(90, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "T-100";
        car.time = 0;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 22, 1f));
        car.Moves.Add(new expMove(65, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 前方车辆
        car = new expEvent();
        car.type = "Skyline";
        car.time = 70;
        car.coord = new Vector2(3f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 17, 1f));
        car.Moves.Add(new expMove(100, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Coupe";
        car.time = 105;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 24, 1f));
        car.Moves.Add(new expMove(32, 1, 16, 0f));
        car.Moves.Add(new expMove(30, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
