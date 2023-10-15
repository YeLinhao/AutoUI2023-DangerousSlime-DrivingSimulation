using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VII
{
    // Start is called before the first frame update
    public void Init()
    {
        int stage_id = 7;
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
        //80
        //PHASE 0
        phase_id = 0;
        //car 0 事件6，后车加速
        car = new expEvent();
        car.type = "Sedan";
        car.time = 5;
        car.coord = new Vector2(0f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 30, 1f));
        car.Moves.Add(new expMove(25f, 1, 40, 1f));
        car.Moves.Add(new expMove(1f, 1, 18, -1f));
        car.Moves.Add(new expMove(1f, 1, 18, 0.5f));
        car.Moves.Add(new expMove(1f, 1, 0, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 高速驶过
        car = new expEvent();
        car.type = "T-100";
        car.time = 5;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 32, 1f));
        car.Moves.Add(new expMove(60, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Coupe";
        car.time = 15;
        car.coord = new Vector2(3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(23, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 高速驶过
        car = new expEvent();
        car.type = "Sedan";
        car.time = 40;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 33, 1f));
        car.Moves.Add(new expMove(70, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 后方车辆
        car = new expEvent();
        car.type = "Skala";
        car.time = 45;
        car.coord = new Vector2(-3f, -150f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 24, 1f));
        car.Moves.Add(new expMove(25, 1, 16, 0f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
        //car 前方车辆
        car = new expEvent();
        car.type = "T-100";
        car.time = 40;
        car.coord = new Vector2(0f, 200f);
        car.Moves.Clear();
        car.Moves.Add(new expMove(0, 1, 25, 1f));
        car.Moves.Add(new expMove(40, 4, 0, 0f));
        expStages.list[stage_id].Phases[phase_id].Events.Add(car);
    }
}
