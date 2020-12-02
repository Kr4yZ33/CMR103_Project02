using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrainingManager : MonoBehaviour
{
    public GameObject leftTrackGap;
    public GameObject rightTrackGap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableTrackGapGuides()
    {
        leftTrackGap.SetActive(true);
        rightTrackGap.SetActive(true);
    }

    public void DisableTrackGapGuides()
    {
        leftTrackGap.SetActive(false);
        rightTrackGap.SetActive(false);
    }
}
