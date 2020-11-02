using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public GameObject nave;
    Vector3 newPos;
    float vel = 3f;

    // Start is called before the first frame update
    void Start()
    {
        newPos = new Vector3(nave.transform.position.x, nave.transform.position.y +2, nave.transform.position.z -5);
    }

    // Update is called once per frame
    void Update()
    {
        newPos = new Vector3(nave.transform.position.x, nave.transform.position.y +1f, nave.transform.position.z -5);

        if (Input.GetKey(KeyCode.Space))
        {
            vel = 12;
        }

        else
        {
            vel = 3;
        }
        nave.transform.position = new Vector3(nave.transform.position.x + (Input.GetAxis("Horizontal") * 10 *Time.deltaTime), nave.transform.position.y + (Input.GetAxis("Vertical") * 10 *Time.deltaTime), nave.transform.position.z +( vel *Time.deltaTime));
        
        transform.position = Vector3.Lerp(transform.position, newPos, 8 * Time.deltaTime);

    }
}
