using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverChange : MonoBehaviour
{
    Renderer r; // reference to our renderer

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>(); // get the renderer component from the object this scrip is attched to and assign it to r
    }

    /// <summary>
    /// function to change the object colour to yellow
    /// </summary>
    public void MakeYellow()
    {
        r.material.color = Color.yellow; // change the material colour of r to yellow
    }

    /// <summary>
    /// function to change the object colour to grey
    /// </summary>
    public void MakeGrey()
    {
        r.material.color = Color.grey; // change the material colour of r to grey
    }
}
