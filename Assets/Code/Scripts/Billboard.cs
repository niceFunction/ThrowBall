using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _theCam;

    void Start()
    {
        _theCam = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(_theCam.transform);

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
