using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonLights : MonoBehaviour
{
    Renderer r; // reference to our renderer

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>(); // get the renderer component from the object this scrip is attched to and assign it to r
    }

    /// <summary>
    ///  function to change the object colour to red
    /// </summary>
    public void MakeRed()
    {
        r.material.color = Color.red; // change the material colour of r to red
    }

    /// <summary>
    ///  function to change the object colour to green
    /// </summary>
    public void MakeGreen()
    {
        r.material.color = Color.green; // change the material colour of r to green
    }
}
