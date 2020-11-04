using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoritos : MonoBehaviour
{
    public int vida;
    bool isDestruido;

    public GameObject miniMeteorito;
    // Start is called before the first frame update
    void Start()
    {
        string vidas = ((int)transform.lossyScale.x).ToString();
        vida = vidas.Length * (int)Random.Range(1,3);

        if (vida <= 0)
        {
            vida = 3;
        }
        isDestruido = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (vida <= 0)
        {
            if (isDestruido == false)
            {
                isDestruido = true;
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<ParticleSystem>().Play();
                Instantiate(miniMeteorito, transform.position, transform.rotation);
                Instantiate(miniMeteorito, transform.position, transform.rotation);
                GameObject.FindGameObjectWithTag("Sound").GetComponent<ChangeNave>().PlayMeteoritoDead();
                AllInOneManager.instance.IncreaseScore();
                AllInOneManager.instance.IncreaseScore();
                Invoke("DestroyMeteorito", 3f);
            }

        }


        
    }
    void DestroyMeteorito()
    {

        Destroy(gameObject);
    }

}
