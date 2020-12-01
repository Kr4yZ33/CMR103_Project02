using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMeshDirectionSetter : MonoBehaviour
{
    public TrainController trainController;
    Transform waypoint;

    private void Update()
    {
        waypoint = trainController.currentTarget;
        Quaternion q = new Quaternion();
        q.SetLookRotation(waypoint.transform.position - transform.position);
        transform.rotation = q;
    }
}
