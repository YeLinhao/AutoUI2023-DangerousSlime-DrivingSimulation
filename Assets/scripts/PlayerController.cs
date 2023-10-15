using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

//±¾³µ³µÁ¾
public class PlayerController : AutoController
{
    public override void getData()
    {
        Vector2 newP = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
        a = ((newP - p) / Time.deltaTime - v) / Time.deltaTime;
        v = (newP - p) / Time.deltaTime;
        p = newP;
        PlayerInfo.coord = gameObject.transform.position;
        PlayerInfo.forward = centerForward;
        if (turnEnabled) PlayerInfo.forward = new Vector2(gameObject.transform.forward.x, gameObject.transform.forward.z);
        Director.playerData.dataList.Add(new PlayerDataNode(p, v, a, Time.time, PlayerInfo.forward));
        return;
    }
    public override void Correct()
    {
        /*float l = Mathf.Abs(200.99f - p.x);
        float r = Mathf.Abs(-392.37f - p.x);
        float u = Mathf.Abs(-2301.5f - p.y);
        float d = Mathf.Abs(2094.44f - p.y);
        if (l < r && l < u && l < d && !turnEnabled && newCorrect) centerPos.x = 200.99f;
        if (r < l && r < u && r < d && !turnEnabled && newCorrect) centerPos.x = -392.37f;
        if (u < r && u < l && l < d && !turnEnabled && newCorrect) centerPos.y = -2301.5f;
        if (d < r && d < u && d < l && !turnEnabled && newCorrect) centerPos.y = 2094.44f;*/
        Vector2 P_CP = p - centerPos;
        Vector2 proj = Vector2.Dot(P_CP, centerForward) * centerForward / centerForward.magnitude;
        Vector2 h = centerPos + proj;
        float distance = Vector2.Distance(p, h);
        if (distance > correctThreshold)
        {
            gameObject.transform.position += new Vector3((h - p).x, 0, (h - p).y);
            gameObject.transform.forward = new Vector3(centerForward.x, gameObject.transform.forward.y, centerForward.y).normalized;
        }
        return;
    }
    public override void newTurn()
    {
        if (((Vector2.Distance(p, turnP1) < 20 && p.y < turnP1.y + 3)
            || (Vector2.Distance(p, turnP2) < 20 && p.x < turnP2.x + 6.26)
            || (Vector2.Distance(p, turnP3) < 20 && p.y > turnP3.y - 7.59)
            || (Vector2.Distance(p, turnP4) < 20 && p.x > turnP4.x - 8.27)) && turnEnabled == false)
        {
            turnEnabled = true;
            turnRound(0.37f);
        };
        if (turnEnabled) endTurn();
    }
    public override void remove()
    {
        ;
    }
}