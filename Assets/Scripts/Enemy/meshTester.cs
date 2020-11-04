using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class meshTester : MonoBehaviour
{
    public Transform nave;
    Quaternion initRot;
    Vector3 nextPos;
 
 void Start()
    {
        initRot = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = initRot;
        transform.position = new Vector3(0, nave.position.y, 0);
    }
}
