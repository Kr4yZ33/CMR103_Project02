using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCentreControllerC : MonoBehaviour
{
    //public bool trainPassingTransform; // bool for if the train is passing the transform or not

    public Transform centre; // reference to the centre transform of the track tile
    public Transform right; // reference to the right edge transform of the track tile
    public Transform left; // reference to the left edge transform of the track tile

    void OnTriggerEnter(Collider other)
    {
        //if (trainPassingTransform == true)
        //{
        //return;

        //}
        if (other.CompareTag("Train"))
        {

            TrainController script = other.gameObject.GetComponent<TrainController>();

            if (script.previousTarget == left)
            {
                script.previousTarget = centre;
                script.currentTarget = right;
            }

            if (script.previousTarget != left)
            {
                script.previousTarget = centre;
                script.currentTarget = left;
                //trainPassingTransform = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Train"))
        //{
        //trainPassingTransform = false;
        //}
    }
}
