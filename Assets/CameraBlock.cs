using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlock : MonoBehaviour
{
    public GameObject cube, target;

    // Update is called once per frame
    void Update()
    {
        cube.transform.position = target.transform.position;
    }
}
