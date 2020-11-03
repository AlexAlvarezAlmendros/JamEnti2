using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Nave : MonoBehaviour
{
    public GameObject bullet;

    public float velXY = 10;
    public float velZ = 3;

    public int typeNave;
    float fireTimer;
    bool typeFire;

    // Start is called before the first frame update
    void Start()
    {
        fireTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButton("Jump"))
        {
            velZ = 20;
        }

        else
        {
            velZ = 10;
        }

        if (Input.GetButton("Fire1"))
        {
            if (fireTimer > 0.25f && typeNave == 1)
            {
               if (typeFire)
                {
                    Instantiate(bullet, transform.position + (transform.right * 1.8f) + (transform.forward * 1.2f), transform.rotation * Quaternion.Euler(Vector3.up * -1.5f));
                    typeFire = false;
                }

                else
                {
                    Instantiate(bullet, transform.position + (transform.right * -1.8f) + (transform.forward * 1.2f), transform.rotation * Quaternion.Euler(Vector3.up * 1.5f));
                    typeFire = true;
                }
                fireTimer = 0;
            }
   
        }

        else if (Input.GetButton("Fire2"))
        {
            if (fireTimer > 0.25f && typeNave == -1)
            {
               if (typeFire)
                {
                    Instantiate(bullet, transform.position + (transform.right * 1.8f) + (transform.forward * 1.2f), transform.rotation * Quaternion.Euler(Vector3.up * -1.5f));
                    typeFire = false;
                }

                else
                {
                    Instantiate(bullet, transform.position + (transform.right * -1.8f) + (transform.forward * 1.2f), transform.rotation * Quaternion.Euler(Vector3.up * 1.5f));
                    typeFire = true;
                }
                fireTimer = 0;
            }
        }

        transform.position = transform.position + (transform.forward * velZ * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + (Input.GetAxis("Vertical") * Time.deltaTime *100), transform.eulerAngles.y + (Input.GetAxis("Horizontal") * Time.deltaTime *100), transform.eulerAngles.z);
    }

}
