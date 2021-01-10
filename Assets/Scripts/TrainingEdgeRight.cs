using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingEdgeRight : MonoBehaviour
{
    public PlayerTrainingManager playerTrainingManager; // reference to the PLayerTrainingManager script

    /// <summary>
    /// on trigger enter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TrackEdge")) // if the other thing colliding with us is tagged TrackEdge
        {
            playerTrainingManager.rightEdgeConnected = true; // set the bool for rightEdgeConnected on the PlayerTrainingManager script to true
        }
    }

    /// <summary>
    /// on trigger exit
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrackEdge")) // if the other thing leaving our collider us is tagged TrackEdge
        {
            playerTrainingManager.rightEdgeConnected = false; // set the bool for rightEdgeConnected on the PlayerTrainingManager script to false
        }
    }
}
