using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTeleportRay; // reference to the XRController script for the left teleport ray
    public XRController rightTeleportRay; // reference to the XRController script for the right teleport ray
    public InputHelpers.Button teleportActivationButton; // reference to the InputHelpers script for the teleport activation button
    public float activationThreshold = 0.1f; // the threshold for activation of the button

    // late update is processed after update
    private void LateUpdate()
    {
        if (leftTeleportRay) // if the left teleport ray button is used
        {
            leftTeleportRay.gameObject.SetActive(CheckIfActivated(leftTeleportRay)); // set the game object for the left ray to active
        }

        if (rightTeleportRay) // if the right teleport ray button is used
        {
            rightTeleportRay.gameObject.SetActive(CheckIfActivated(rightTeleportRay)); // set the game object for the right ray to active
        }
    }

    public bool CheckIfActivated(XRController controller) // public bool to see if the button on the controller has been pressed
    {
        
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated; // return the output true to is activated
    }
}
