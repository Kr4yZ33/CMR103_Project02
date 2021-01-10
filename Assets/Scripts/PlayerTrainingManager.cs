using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrainingManager : MonoBehaviour
{
    public bool leftEdgeConnected; // bool for if the left edge waypoint is connected to anything
    public bool rightEdgeConnected; // bool for if the right edge waypoint is connected to anything
    public bool trainingCompleted; // bool for if training is completed
    public bool missionCompleteClipPlayed; // bool for if the mission complete audion clip has been played

    public GameObject leftTrackGap; // reference to the left track gap transparent game object
    public GameObject rightTrackGap; // reference to the right track gap transparent game object
    public GameObject guideText;// reference to the game object with the mission text

    public AudioClip trainingCompletedAudioClip; // reference to the training completed audio clip
    public AudioSource audioSource; // reference to the audio source
    public float volume = 0.5f; // reference to the volume setting

    // fixed update happens once each 60 frames
    private void FixedUpdate()
    {
        if(trainingCompleted == true) // if the bool for training completed is true
        {
            FinishPlayerTraining(); // call the function FinishPlayerTraining
        }
        
        if(missionCompleteClipPlayed == true) // if the bool for mission complete clip is true
        {
            return; // exit the function
        }

        if(leftEdgeConnected == true && rightEdgeConnected == true) // if the bool for left edge connected is true and the bool for right edge connected is true
        {
            trainingCompleted = true; // set the bool for training complete to true
            audioSource.PlayOneShot(trainingCompletedAudioClip, volume); // play the training complete audio clip as a single clip
            missionCompleteClipPlayed = true; // set the bool for mission complete caudio clip played to true
        }
    }

    /// <summary>
    /// function to start the player training
    /// </summary>
    public void StartPlayerTraining()
    {
        EnableTrackGapGuides(); // call the function EnableTrackGapGuuides
    }
    
    /// <summary>
    /// function that enables the training gap guides
    /// </summary>
    void EnableTrackGapGuides()
    {
        leftTrackGap.SetActive(true); // set the left track gap transparent object to true
        rightTrackGap.SetActive(true); // set the right track gap transparent object to true
        guideText.SetActive(true); // set the mission board game object to true
    }

    /// <summary>
    /// function to finish the player training
    /// </summary>
    public void FinishPlayerTraining()
    {
        leftTrackGap.SetActive(false); // set the left track gap transparent object to false
        rightTrackGap.SetActive(false); // set the right track gap transparent object to false
        guideText.SetActive(false); // set the mission board game object to false
    }
}
