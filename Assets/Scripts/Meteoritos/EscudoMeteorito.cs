using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoMeteorito : MonoBehaviour
{
    public GameObject escudo;

    public int vida;

    bool isDestruido;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().enabled = false;

        if (vida <= 0)
        {
            vida = 3;
        }

        isDestruido = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (escudo.GetComponent<SphereCollider>().enabled == true)
        {
            transform.position = escudo.transform.position;
        }


        if (escudo.GetComponent<SphereCollider>().enabled == false)
        {
            GetComponent<SphereCollider>().enabled = true;
        }
        
        if (vida <= 0)
        {
            if (isDestruido == false)
            {
                isDestruido = true;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<ParticleSystem>().Play();
                Invoke("DestroyMeteorito", 3f);
                AllInOneManager.instance.IncreaseScore();
                AllInOneManager.instance.IncreaseScore();
                AllInOneManager.instance.IncreaseScore();
                AllInOneManager.instance.IncreaseScore();
                AllInOneManager.instance.IncreaseScore();
            }

        }


    }

    void DestroyMeteorito()
    {
        Destroy(gameObject);
    }
}
