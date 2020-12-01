using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to our Audio Source
    public AudioClip bgm1; // reference to our game clip1
    public AudioClip hornClip; // reference to our horn sound clip
    private AudioClip currentTrack; // the current track being played
    private AudioClip previousTrack; // the previous track that was played
    public float volume = 0.5f; // Reference to the volume of our scare shot clip (plays over game musice that is already playing)

    /// <summary>
    /// play the previous track that was being played
    /// </summary>
    public void PlayPreviousTrack()
    {
        // if there is no previous track
        if (previousTrack == null)
        {
            previousTrack = bgm1;
        }
        currentTrack = previousTrack; // set the current track to the previous track
        ChangeTrack(currentTrack); // play our previous track
    }

    /// <summary>
    /// play the horn sound clip
    /// </summary>
    public void PlayHornClip()
    {
        // if there is no previous track
        if (currentTrack == hornClip)
        {
            return;
        }
        else
        {
            audioSource.PlayOneShot(hornClip, volume);
        }
    }

    /// <summary>
    /// This function changes the clip being played at the moment
    /// </summary>
    /// <param name="clip"></param>
    public void ChangeTrack(AudioClip clip)
    {
        audioSource.Stop(); // stop playing the current clip
        if (audioSource.clip != clip) // if the current clip in the audio source is not equal to the clip we are trying to play
        {
            previousTrack = audioSource.clip; // store the previous track
            audioSource.clip = clip; // set the new track
        }
        audioSource.loop = true; // set the track to be looping
        audioSource.Play(); // start playing our music
    }
}
