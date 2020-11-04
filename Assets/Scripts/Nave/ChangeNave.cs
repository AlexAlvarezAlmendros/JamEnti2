using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ChangeNave : MonoBehaviour
{
    public GameObject naveGFX1;
    public GameObject naveGFX2;
    public Material matGFX1;
    public Material matGFX2;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject nave1;
    public GameObject nave2;
    public Gradient nave1Gradient;
    public Gradient nave2Gradient;

    public GameObject trail1Nave1;
    public GameObject trail2Nave1;
    public GameObject trail3Nave1;
    public GameObject trail4Nave1;
    public GameObject trail5Nave1;
    
    public GameObject trail1Nave2;
    public GameObject trail2Nave2;
    public GameObject trail3Nave2;
    public GameObject trail4Nave2;
    public GameObject trail5Nave2;
    bool tpNaves;

    public AudioClip meteoritoDead;
    public AudioClip laserShot;
    public AudioClip laserReflection;
    public AudioClip escudoDead;
    public AudioClip escudoDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            if (tpNaves == false)
            {
                naveGFX1.GetComponent<Renderer>().material = matGFX1;
                naveGFX2.GetComponent<Renderer>().material = matGFX2;
                nave1.GetComponent<Nave>().bullet = bullet1;
                nave2.GetComponent<Nave>().bullet = bullet2;
                tpNaves = true;

                trail1Nave1.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail2Nave1.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail3Nave1.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail4Nave1.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail5Nave1.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                
                trail1Nave2.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail2Nave2.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail3Nave2.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail4Nave2.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail5Nave2.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
            }

            else
            {
                naveGFX1.GetComponent<Renderer>().material = matGFX2;
                naveGFX2.GetComponent<Renderer>().material = matGFX1;
                nave1.GetComponent<Nave>().bullet = bullet2;
                nave2.GetComponent<Nave>().bullet = bullet1;
                tpNaves = false;

                trail1Nave1.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail2Nave1.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail3Nave1.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail4Nave1.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                trail5Nave1.GetComponent<TrailRenderer>().colorGradient = nave2Gradient;
                
                trail1Nave2.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail2Nave2.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail3Nave2.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail4Nave2.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
                trail5Nave2.GetComponent<TrailRenderer>().colorGradient = nave1Gradient;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void PlayMeteoritoDamage()
    {
        GetComponent<AudioSource>().PlayOneShot(meteoritoDead, Random.Range(0.5f,1));
    }

    public void PlayMeteoritoDead()
    {
        GetComponent<AudioSource>().PlayOneShot(meteoritoDead, Random.Range(1.5f,2));
    }

    public void PlayDisparo()
    {
        GetComponent<AudioSource>().PlayOneShot(laserShot, Random.Range(0.5f,0.75f));
    }

    public void PlayLaserReflection()
    {
        GetComponent<AudioSource>().PlayOneShot(laserReflection, Random.Range(0.5f,0.75f));
    }

    public void PlayEscudoDamage()
    {
        GetComponent<AudioSource>().PlayOneShot(escudoDamage, Random.Range(0.5f,1));
    }

    public void PlayEscudoDead()
    {
        GetComponent<AudioSource>().PlayOneShot(escudoDead, Random.Range(1.5f,2));
    }

}
