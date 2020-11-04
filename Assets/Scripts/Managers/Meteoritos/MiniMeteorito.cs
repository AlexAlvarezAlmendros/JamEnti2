using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMeteorito : MonoBehaviour
{
    public int vida;
    bool isDestruido;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(1,5),Random.Range(1,5),Random.Range(1,5)) * 5 * Mathf.Sign(Random.Range(-1, 1));
        vida = 3;
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
