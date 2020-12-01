using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigScaleController : MonoBehaviour
{
    public GameObject smallScaleRig;
    public GameObject xRInteractionManagerS;
    //public GameObject smallScaleRigBelt;
    public GameObject xRInteractionManagerL;
    public GameObject largeScaleRig;
    //public GameObject largeScaleRigBelt;
    public bool manualTrainRide;


    public void ChangeScaleToSmall()
    {
        largeScaleRig.SetActive(false);
        xRInteractionManagerL.SetActive(false);
        //largeScaleRigBelt.SetActive(false);
        //gameObject.transform.localScale = new Vector3(1, 1, 1);
        smallScaleRig.SetActive(true);
        //smallScaleRigBelt.SetActive(true);
        xRInteractionManagerS.SetActive(true);
        //manualTrainRide = true;
        //gameObject.transform.position = smallScaleRig.transform.position;
    }

    public void ChangeScaleToLarge()
    {
        smallScaleRig.SetActive(false);
        //smallScaleRigBelt.SetActive(false);
        xRInteractionManagerS.SetActive(false);
        //gameObject.transform.localScale = new Vector3(10, 10, 10);
        //gameObject.transform.position = largeRigSpawnTransform.position;
        //gameObject.transform.rotation = largeRigSpawnTransform.rotation;
        largeScaleRig.SetActive(true);
        xRInteractionManagerL.SetActive(true);
        //largeScaleRigBelt.SetActive(true);
    }

    public void ManualTrainRide()
    {
        manualTrainRide = true;
    }

    //public void IncreaseSCalebyOne()
    //{
    //gameObject.transform.localScale += new Vector3(1, 1, 1);
    //}

    //public void DecreaseSCalebyOne()
    //{
    //gameObject.transform.localScale += new Vector3(-1, -1, -1);
    //}
}