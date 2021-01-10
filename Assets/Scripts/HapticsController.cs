using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsController : MonoBehaviour
{

    public AudioSource audioSource; // reference to the audio source
    // OVRHapticsClip buzz; // reference to the OVR Haptic clip
    public bool trackConnected; // bool for if the track is connected or not
    public bool trackConnectedRhand; // bool showing if the right hand is the one holding the object
    public bool trackConnectedLhand; // bool showing if the left hand is the one holding the object
    public bool isHeld; // bool for if the object is being held of not

    public bool trackConnectClipPlayed; // bool for if the track connection clip has played or not
    public AudioClip trackConnectedClip; // reference to the audio clip for the track connection clip
    public float volume = 0.7f; // the volume the clip plays at

    // Start is called before the first frame update
    //void Start()
    //{
    //buzz = new OVRHapticsClip(trackConnect); // set the ovr haptic clip to the track connect audio clip
    //}

    //void Update()
    //{

    //if (trackConnectClipPlayed == true) // if the bool for trackConnectClipPlayed equals true
    //{
    //return; // exit the function
    //}

    //else if (trackConnectedRhand == true && trackConnected == true) // if the bool for right hand used is true
    //{
    //OVRHaptics.RightChannel.Mix(buzz); // use the buzz ovr haptic clip on the right controller.
    //trackConnectClipPlayed = true;
    //}

    //else if (trackConnectedLhand == true && trackConnected == true) // if the bool for left hand used is true
    //{
    //OVRHaptics.LeftChannel.Mix(buzz); // use the buzz ovr haptic clip on the left controller.
    //trackConnectClipPlayed = true;
    //}
    //}

    void OnTriggerEnter(Collider hand) // on trigger enter
    {
        if (hand.gameObject.CompareTag("LeftHand")) // if the object colliding with us is tagged LeftHand
        {
            isHeld = true; // set the bool for isHeld to true
            trackConnectedLhand = true;
            // OVRHaptics.LeftChannel.Mix(buzz); // use the buzz ovr haptic clip on the left controller.

        }

        if (hand.gameObject.CompareTag("RightHand")) // if the object colliding with us is tagged LeftHand
        {
            isHeld = true; // set the bool for isHeld to true
            trackConnectedRhand = true;
            // OVRHaptics.RightChannel.Mix(buzz); // use the buzz ovr haptic clip on the left controller.

        }
    }
    void OnTriggerExit(Collider hand) // on trigger exit
    {
        if (hand.gameObject.CompareTag("LeftHand")) // if the object colliding with us is tagged LeftHand
        {
            // OVRHaptics.LeftChannel.Mix(buzz); // use the buzz ovr haptic clip on the left controller
            trackConnectedLhand = false; // set the bool for left hand in use to false
            isHeld = false; // set the bool for isHeld to false
        }
        if (hand.gameObject.CompareTag("RightHand")) // if the object colliding with us is tagged RightHand
        {
            // OVRHaptics.RightChannel.Mix(buzz); // use the buzz ovr haptic clip on the right controller
            trackConnectedRhand = false; // set the bool for right hand in use to false
            isHeld = false; // set the bool for isHeld to false
        }
    }

    /// <summary>
    /// Function that plays our track connection audio clip
    /// </summary>
    public void PlayTrackConnectionClip()
    {
        audioSource.PlayOneShot(trackConnectedClip, volume); // play one shot of the track connected clip on the audio source at the volume set (0.7)
        // OVRHaptics.RightChannel.Mix(buzz); // use the buzz ovr haptic clip on the right controller.
        // OVRHaptics.LeftChannel.Mix(buzz); // use the buzz ovr haptic clip on the left controller.
    }
}
