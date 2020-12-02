using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObjectRotation : MonoBehaviour
{
    public int increment;
    private void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, (Mathf.Round(transform.eulerAngles.y / increment) * increment), transform.eulerAngles.z);
    }
}
