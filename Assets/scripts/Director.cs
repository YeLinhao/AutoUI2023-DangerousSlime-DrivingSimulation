using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Director : MonoBehaviour
{
    public static AllData allData = new AllData();
    public static PlayerData playerData = new PlayerData();
    public Dictionary<string, string> type = new Dictionary<string, string> { { "Coupe", "Prefabs/Coupe" }, { "Jeep", "Prefabs/Jeep" },
                                                                              { "Pickup", "Prefabs/Pickup" },   { "Sedan", "Prefabs/Sedan" },
                                                                              { "Skala", "Prefabs/Skala" },   { "Skyline", "Prefabs/Skyline" },
                                                                              { "T-100", "Prefabs/T-100" },   { "Truck", "Prefabs/Truck" },};
    Vector2 PlayerPos = new Vector2();
    Vector2 PlayerForward = new Vector2();
    Vector3 spawn = new Vector3();
    Quaternion rotation = new Quaternion();
    List<GameObject> passers = new List<GameObject>();
    bool flag = false;
    private void Awake()
    {
        StartCoroutine(outputData());
        StartCoroutine(outputPlayerData());
    }
    private void FixedUpdate()
    {
        if (!flag)
        {
            StartCoroutine(playerDrive());
            flag = true;
        }
        foreach (expStage stage in expStages.list)
        {
            foreach (expPhase phase in stage.Phases)
            {
                if (Time.time>stage.time+phase.time&&!phase.done)
                {
                    foreach (expEvent carEvent in phase.Events)
                    {
                        StartCoroutine(SpawnCar(carEvent));
                    };
                    phase.done = true;
                }
            }
        }
    }
    public IEnumerator playerDrive()
    {
        PlayerController PC = (PlayerController)gameObject.GetComponent(typeof(PlayerController));
        foreach (expMove move in expStages.playerMoves)
        {
            yield return new WaitForSeconds(move.time);
            switch (move.movement)
            {
                case 1:
                    PC.straight(move.v, move.throttle);
                    break;
                case 2:
                    PC.changeLane(move.v, move.throttle, move.steer, move.t1, move.t2);
                    break;
                case 3:
                    PC.turnRound(move.steer);
                    break;
            }
        }
    }
    //Instantiate a car according to a carEvent
    public IEnumerator SpawnCar(expEvent carEvent)
    {
        yield return new WaitForSeconds(carEvent.time);
        Vector2 pp2 = new Vector2(PlayerInfo.coord.x, PlayerInfo.coord.z);
        Vector2 sp2 = pp2 + carEvent.coord.y * PlayerInfo.forward + carEvent.coord.x * new Vector2(PlayerInfo.forward.y, -PlayerInfo.forward.x);
        Vector2 fd = PlayerInfo.forward;
        float ro = fd.x >= 0 ? Mathf.Acos(fd.y) : -Mathf.Acos(fd.y);
        ro *= 180 / Mathf.PI;
        GameObject Car = Instantiate(Resources.Load(type[carEvent.type]) as GameObject, new Vector3(sp2.x, PlayerInfo.coord.y, sp2.y), Quaternion.Euler(0, ro, 0)) as GameObject;
        PassingController PC = (PassingController) Car.GetComponent(typeof(PassingController));
        PC.data.time = Time.time;
        PC.data.type = carEvent.type;
        foreach (expMove move in carEvent.Moves)
        {
            yield return new WaitForSeconds(move.time);
            switch (move.movement)
            {
                case 1:
                    PC.straight(move.v, move.throttle);
                    break;
                case 2:
                    PC.changeLane(move.v, move.throttle, move.steer, move.t1, move.t2);
                    break;
                case 3:
                    PC.turnRound(move.steer);
                    break;
                case 4:
                    PC.remove();
                    break;
            }
        }
    }
    //Export data for controlling vehicles in the game Dangerous Slime
    public IEnumerator outputData()
    {
        yield return new WaitForSeconds(1300);
        string strJson = JsonUtility.ToJson(allData, true);
        string JsonPath = "Assets/Data/allData.json";
        File.Create(JsonPath).Dispose();
        File.WriteAllText(JsonPath, strJson);
    }
    //Export data for controlling the vehicle that represents the player in the game Dangerous Slime
    public IEnumerator outputPlayerData()
    {
        yield return new WaitForSeconds(1301);
        string strJson = JsonUtility.ToJson(playerData, true);
        string JsonPath = "Assets/Data/playerData.json";
        File.Create(JsonPath).Dispose();
        File.WriteAllText(JsonPath, strJson);
    }
}

