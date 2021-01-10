using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMeshDirectionSetter : MonoBehaviour
{
    public TrainController trainController; // reference to the TrainController script
    Transform waypoint; // reference to the waypoint transform

    // Update is called once per frame
    private void Update()
    {
        waypoint = trainController.currentTarget; // set the reference of waypoint to the traincontroller script's current target
        Quaternion q = new Quaternion(); //
        q.SetLookRotation(waypoint.transform.position - transform.position); // calculate the different between our transform and the target transform
        transform.rotation = q; // set this value to q
    }
}
