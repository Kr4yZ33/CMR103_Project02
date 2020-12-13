using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonLights : MonoBehaviour
{
    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    public void MakeRed()
    {
        r.material.color = Color.red;
    }

    public void MakeGreen()
    {
        r.material.color = Color.green;
    }
}
