using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public AudioManager audioManager; // reference to the Audio Manager script
    //public RigScaleController rigScaleController;

    public bool trainHeld; // bool for if the train is being held or not (it's actually if the hand is colliding with the train, not grabbing)
    public bool edgeTransition; // bool for if tile waypoint edge transition is true or not

    public Transform startingPos; // reference to the transform the train will jump to when the scene starts
    public Vector3 targetPosition; // reference to our target position
    public Transform currentTarget; // the transform the train is currently targeting
    public Transform previousTarget; // the previous transform target of the train

    public float trainSpeed = 0.2f; // the speed of the train

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = startingPos.position; // set the target position to the starting poisition
        transform.position = targetPosition; // set the position of the transform this script is attached to, to the target position transform

    }

    void Update()
    {
        
        if (trainHeld == true) // if the bool for train held is true
        {
            currentTarget = previousTarget; // set the current target to the previous target
            currentTarget = null; // clear the current target
            trainSpeed = 0f; // set the train speed to zero
        }
        else // otherwise
        {
            targetPosition = currentTarget.position; // set the target position to the current target
            trainSpeed = 0.2f; // set the train speed to 0.5
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * trainSpeed); // make the transform of the object this script is attached to move towards the target position using delta time at the train speed set (0.5)
        }
    }


    void OnTriggerEnter(Collider other) // on trigger enter
    {
        if (other.CompareTag("Horn")) // if the thing colliding with me is tagged HornSpawn
        {
            PlayTrainHorn(); // call the PLayTrainHorn function
        }

        if (other.CompareTag("RightHand")) // if the thing colliding with me is tagged RightHand
        {

            trainHeld = true; // set train held to true
        }

        if (other.CompareTag("LeftHand")) // if the thing colliding with me is tagged LeftHand
        {

            trainHeld = true; // set train held to true
        }

        if (other.CompareTag("TrackEdge")) // if the thing colliding with me is tagged TrackEdge
        {
            edgeTransition = true; // set the edgeTransition bool to true
        }
    }

    void OnTriggerExit(Collider other) // on trigger exit
    {
        if (other.CompareTag("LeftHand"))// if the thing colliding with me is tagged LeftHand
        {
            trainHeld = false; // set the train held bool to false
            currentTarget = startingPos;
        }

        if (other.CompareTag("RightHand")) // if the thing colliding with me is tagged RightHand
        {
            trainHeld = false; // set the train held bool to false
            currentTarget = startingPos; // set the current target to the starting position
        }

        if (other.CompareTag("TrackEdge")) // if the thing colliding with me is tagged TrackEdge
        {
            edgeTransition = false; // set the edge transition bool to false
        }
    }

    /// <summary>
    /// Play the audio for the train's horn
    /// </summary>
    void PlayTrainHorn()
    {
        audioManager.PlayHornClip(); // call the PLayHornClip from the audio manager script
    }
}
