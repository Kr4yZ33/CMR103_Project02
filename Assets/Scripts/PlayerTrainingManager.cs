using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrainingManager : MonoBehaviour
{
    public bool leftEdgeConnected;
    public bool rightEdgeConnected;
    public bool trainingCompleted;

    public GameObject leftTrackGap;
    public GameObject rightTrackGap;
    public GameObject guideText;

    public AudioClip trainingAudioClip;
    public AudioSource audioSource;

    private void FixedUpdate()
    {
        if(trainingCompleted == true)
        {
            FinishPlayerTraining();
        }
        
        if(leftEdgeConnected == true && rightEdgeConnected == true)
        {
            trainingCompleted = true;
        }
    }

    public void StartPlayerTraining()
    {
        EnableTrackGapGuides();
        audioSource.PlayOneShot(trainingAudioClip);
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
