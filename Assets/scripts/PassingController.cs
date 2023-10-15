using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//除本车以外的所有车辆
public class PassingController : AutoController
{
    public override void getData()
    {
        Vector2 newP = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
        a = ((newP - p) / Time.deltaTime - v) / Time.deltaTime;
        v = (newP - p) / Time.deltaTime;
        p = newP;
        data.dataList.Add(new DataNode(p, v, a, Time.time));
        return;
    }
    public override void Correct()
    {
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
        ;
    }
    public override void remove()
    {
        Director.allData.allDataList.Add(data);
        Destroy(gameObject);
    }
}
