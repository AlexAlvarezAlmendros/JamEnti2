using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Title;
    public GameObject HowToPlay;
    public GameObject Credits;
    // Start is called before the first frame update
    void Start()
    {
        Title.gameObject.SetActive(true);
        HowToPlay.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        SoundManager.instance.Play("menuLoop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPlay()
    {
        Title.gameObject.SetActive(true);
        HowToPlay.gameObject.SetActive(false);
        Credits.gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
        SoundManager.instance.Stop("menuLoop");
        SoundManager.instance.Play("GameLoop");
    }

    public void PlayHowToPlay()
    {
        Title.gameObject.SetActive(false);
        HowToPlay.gameObject.SetActive(true);
        Credits.gameObject.SetActive(false);
    }

    public void PlayCredits()
    {
        Title.gameObject.SetActive(false);
        HowToPlay.gameObject.SetActive(false);
        Credits.gameObject.SetActive(true);
    }

    public void PlayExit()
    {
        Application.Quit();
    }
}
