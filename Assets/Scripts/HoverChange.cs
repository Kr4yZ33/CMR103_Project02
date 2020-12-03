using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverChange : MonoBehaviour
{
    Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    public void MakeYellow()
    {
        r.material.color = Color.yellow;
    }

    public void MakeGrey()
    {
        r.material.color = Color.grey;
    }
}
