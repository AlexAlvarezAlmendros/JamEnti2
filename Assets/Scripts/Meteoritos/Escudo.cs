using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public int vida;
    public int escudoType;

    bool isDestruido;

    public Material escudo1;
    public Material escudo2;
    // Start is called before the first frame update
    void Start()
    {
        vida = 5;

        if (Random.Range(0,10) > 5)
        {
            escudoType = 1;
            GetComponent<Renderer>().material = escudo1;

        }

        else
        {
            escudoType = 2;
            GetComponent<Renderer>().material = escudo2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            if (isDestruido == false)
            {
                isDestruido = true;
                GameObject.FindGameObjectWithTag("Sound").GetComponent<ChangeNave>().PlayEscudoDead();
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
            }
        }
    }
    
}
