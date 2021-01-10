using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointRightEdgeController : MonoBehaviour
{
    public HapticsController hapticsController;  // Reference to the Haptics Controller Script
    public bool trainPassingTransform; // bool for if the train is passing the transform or not

    public Transform closestEdge;  // Reference to the closest edge from another tile next to this transform
    public Transform right; // reference to the right edge transform of the track tile
    public Transform left; // reference to the left edge transform of the track tile

    /// <summary>
    /// on trigger enter
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (trainPassingTransform == true) // if the bool for train passing transform is true
        {
            return; // exit

        }
        if (other.CompareTag("Train")) // if the object colliding with us is tagged Train
        {
            TrainController script = other.gameObject.GetComponent<TrainController>(); // access the game object and get the train controller script from it (saves us having to assign manually)

            if (script != null && script.previousTarget != left) // if the train controller's previous target was not the left transform
            {
                script.previousTarget = right; // set the previous target on the train controller script to the right transform
                script.currentTarget = left; // set the current target on the train controller script to the left transform of the track tile
                trainPassingTransform = true; // set the train passing transform bool to true
            }
            if (script != null && script.previousTarget == left) // if the previous target on the train controller script is the left transform
            {
                script.previousTarget = right; // set the previous target on the train controller script to the right transform
                trainPassingTransform = true; // set the train passing transform bool to true
                if (closestEdge != null)
                {
                    script.currentTarget = closestEdge; // set the current target on the train controller script to the closest edge transform of the track tile
                }
            }
        }

        if (other.CompareTag("TrackEdge")) // if the thing colliding with us is tagged TrackEdge
        {
            closestEdge = other.transform; // set the closest edge transform to the transform of the object that just collided with us.
            hapticsController.trackConnected = true; // set the bool for track connected to true on the  haptics controller script
            hapticsController.PlayTrackConnectionClip(); // call the function to play the track connection clip fom the haptics controller script
        }
    }

    /// <summary>
    /// on trigger exit
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Train")) // if the thing leaving out collider is tagged Train
        {
            trainPassingTransform = false; // set the train passing bool transfor to false
        }
        if (other.CompareTag("TrackEdge")) // if the thing leaving out collider is tagged TrackEdge
        {
            closestEdge = null; // set the closest edge to null
            hapticsController.trackConnected = false; // set the bool for trackj connected to true on the  haptics controller script
            hapticsController.trackConnectClipPlayed = false; // set the bool for track connect clip played to true on the  haptics controller script
        }
    }
}