using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEdgeLeft : MonoBehaviour
{
    public PlayerTrainingManager playerTrainingManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrackEdge"))
        {
            playerTrainingManager.leftEdgeConnected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrackEdge"))
        {
            playerTrainingManager.leftEdgeConnected = false;
        }
    }
}
