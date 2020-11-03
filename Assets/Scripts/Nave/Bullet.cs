using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    float deadTimer;

    // Start is called before the first frame update
    void Start()
    {
        deadTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        deadTimer += Time.deltaTime;

        if (deadTimer > 10)
        {
            Destroy(gameObject);
        }
    }
    
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 50;
    }
}
