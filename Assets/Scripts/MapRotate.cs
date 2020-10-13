using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotate : MonoBehaviour
{
    public Transform transform;
    private float zAxis;


    private void Awake()
    {
          zAxis = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            zAxis += 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, zAxis);
            if (zAxis >= 360) zAxis = 0;
        }
    }
}
