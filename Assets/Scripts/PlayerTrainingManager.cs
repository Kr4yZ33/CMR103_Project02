using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrainingManager : MonoBehaviour
{
    public bool leftEdgeConnected;
    public bool rightEdgeConnected;
    public bool trainingCompleted;
    public bool missionCompleteClipPlayed;

    public GameObject leftTrackGap;
    public GameObject rightTrackGap;
    public GameObject guideText;

    public AudioClip trainingCompletedAudioClip;
    public AudioSource audioSource;
    public float volume = 0.5f;

    private void FixedUpdate()
    {
        if(trainingCompleted == true)
        {
            FinishPlayerTraining();
        }
        
        if(missionCompleteClipPlayed == true)
        {
            return;
        }

        if(leftEdgeConnected == true && rightEdgeConnected == true)
        {
            trainingCompleted = true;
            audioSource.PlayOneShot(trainingCompletedAudioClip, volume);
            missionCompleteClipPlayed = true;
        }
    }

    public void StartPlayerTraining()
    {
        EnableTrackGapGuides();
    }
    
    void EnableTrackGapGuides()
    {
        leftTrackGap.SetActive(true);
        rightTrackGap.SetActive(true);
        guideText.SetActive(true);
    }

    public void FinishPlayerTraining()
    {
        leftTrackGap.SetActive(false);
        rightTrackGap.SetActive(false);
        guideText.SetActive(false);
    }
}
