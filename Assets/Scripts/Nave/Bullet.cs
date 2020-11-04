using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    public int bulletType;
    float deadTimer;

    int direction;

    // Start is called before the first frame update
    void Start()
    {
        deadTimer = 0;
        direction = 1;
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
        GetComponent<Rigidbody>().velocity = transform.forward * 100 * direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Meteorito")
        {
            collision.gameObject.GetComponent<Meteoritos>().vida -= 1;
            Invoke("DestroyBullet", 0.3f);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }

        if (collision.gameObject.tag == "Satelit")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            direction = direction * -1;
        }

        if (collision.gameObject.tag == "MiniMeteoritos")
        {
            collision.gameObject.GetComponent<MiniMeteorito>().vida -= 1;
            Invoke("DestroyBullet", 0.3f);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }

        if (collision.gameObject.tag == "Escudo")
        {
            if (bulletType == 1 && collision.gameObject.GetComponent<Escudo>().escudoType == 1)
            {
                collision.gameObject.GetComponent<Escudo>().vida -= 1;
                Invoke("DestroyBullet", 0.3f);
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
            }

            if (bulletType == 2 && collision.gameObject.GetComponent<Escudo>().escudoType == 2)
            {
                collision.gameObject.GetComponent<Escudo>().vida -= 1;
                Invoke("DestroyBullet", 0.3f);
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
            }

            if (bulletType != collision.gameObject.GetComponent<Escudo>().escudoType)
            {
                direction = direction * -1;
            }
        }

        if (collision.gameObject.tag == "Dorado")
        {
            collision.gameObject.GetComponent<EscudoMeteorito>().vida -= 1;
            Invoke("DestroyBullet", 0.3f);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
