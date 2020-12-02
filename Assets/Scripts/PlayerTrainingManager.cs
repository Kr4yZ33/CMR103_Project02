using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrainingManager : MonoBehaviour
{
    public GameObject leftTrackGap;
    public GameObject rightTrackGap;
    public GameObject guideText;

    public AudioClip trainingAudioClip;
    public AudioSource audioSource;

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

    public void DisableTrackGapGuides()
    {
        leftTrackGap.SetActive(false);
        rightTrackGap.SetActive(false);
        guideText.SetActive(false);
    }
}
