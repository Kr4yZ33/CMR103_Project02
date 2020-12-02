using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointRightEdgeController : MonoBehaviour
{
    //public bool trainPassingTransform; // bool for if the train is passing the transform or not
    AudioSource audioSource;
    public AudioClip edgeConnectionClip;

    public Transform closestEdge;  // Reference to the closest edge from another tile next to this transform
    public Transform right; // reference to the right edge transform of the track tile
    public Transform left; // reference to the left edge transform of the track tile

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        //if (trainPassingTransform == true)
        //{
            //return;

        //}
        if (other.CompareTag("Train"))
        {
            
            TrainController script = other.gameObject.GetComponent<TrainController>();

            if(script.previousTarget == null)
            {
                script.previousTarget = right;
                script.currentTarget = left;
            }

            if (script.previousTarget != left)
            {
                script.previousTarget = right;
                script.currentTarget = left;
                //trainPassingTransform = true;
            }
            if (script.previousTarget == left)
            {
                script.previousTarget = right;
                script.currentTarget = closestEdge;
                //trainPassingTransform = true;
            }
        }

        if (other.CompareTag("TrackEdge"))
        {
            closestEdge = other.transform;
            audioSource.PlayOneShot(edgeConnectionClip);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Train"))
        //{
            //trainPassingTransform = false;
        //}
        if (other.CompareTag("TrackEdge"))
        {
            closestEdge = null;
        }
    }
}