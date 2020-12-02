using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEdgeRight : MonoBehaviour
{
    public PlayerTrainingManager playerTrainingManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TrackEdge"))
        {
            playerTrainingManager.rightEdgeConnected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrackEdge"))
        {
            playerTrainingManager.rightEdgeConnected = false;
        }
    }
}
