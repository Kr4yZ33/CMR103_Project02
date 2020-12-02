using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointLeftEdgeController : MonoBehaviour
{
    //public bool trainPassingTransform; // bool for if the train is passing the transform or not
    AudioSource audioSource;
    public AudioClip edgeConnectionClip;

    public Transform closestEdge; // Reference to the closest edge from another tile next to this transform
    public Transform right; // reference to the right edge transform of the track tile
    public Transform left; // reference to the left edge transform of the track tile

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (closestEdge == null)
        {
            closestEdge = gameObject.transform;
        }
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

            if (script.previousTarget == null)
            {
                script.previousTarget = left;
                script.currentTarget = right;
            }

            if (script.previousTarget != right)
            {
                script.previousTarget = left;
                script.currentTarget = right;
                //trainPassingTransform = true;
            }
            if (script.previousTarget == right)
            {
                script.previousTarget = left;
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
