using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Nave : MonoBehaviour
{
    public float velXY = 10;
    public float velZ = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            velZ = 18;
        }

        else
        {
            velZ = 5;
        }

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("aaa");
        }

        transform.position = transform.position + (transform.forward * velZ * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + (Input.GetAxis("Vertical") * Time.deltaTime *100), transform.eulerAngles.y + (Input.GetAxis("Horizontal") * Time.deltaTime *100), transform.eulerAngles.z);
    }

}
