using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllInOneManager : MonoBehaviour
{
    public static AllInOneManager instance;
    public int score;
    public int lives = 3;
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
        void Start()
    {
        score = 0;
    }

    public void IncreaseScore() {
        score++;
    }

    public void DecreaseLives() {
        lives--;
        
        if (lives <= 0) {
            SceneManager.LoadScene("SampleScene"); //gameover
        }
    }
}
