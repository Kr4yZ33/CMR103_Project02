using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public PlayerTrainingManager playerTrainingManager;
    
    public GameObject uIControls;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RightHand"))
        {
            uIControls.SetActive(false);
            playerTrainingManager.StartPlayerTraining();
        }
    }

    public void TurnOnUiControls()
    {
        uIControls.SetActive(true);
    }

    public void TurnOffUiControls()
    {
        uIControls.SetActive(false);
    }
}
