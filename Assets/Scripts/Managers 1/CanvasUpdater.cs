using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUpdater : MonoBehaviour
{
    public Text scoretext;
    public Text scoretext2;
    bool musicplaying = false;
    public Image live1;
    public Image live2;
    public Image live3;
    public Image mlive1;
    public Image mlive2;
    public Image mlive3;

    void Start() {
        AllInOneManager.instance.score = 0;
    }

    void Update() {
        scoretext.text =  AllInOneManager.instance.score.ToString("D5");
        scoretext2.text = AllInOneManager.instance.score.ToString("D5");
        switch (AllInOneManager.instance.lives)
        {
            case 1:
                live1.enabled = false;
                live2.enabled = false;
                live3.enabled = true;
                mlive1.enabled = false;
                mlive2.enabled = false;
                mlive3.enabled = true;
                break;
            case 2:
                live1.enabled = false;
                live2.enabled = true;
                live3.enabled = true;
                mlive1.enabled = false;
                mlive2.enabled = true;
                mlive3.enabled = true;
                break;
            case 3:
                live1.enabled = true;
                live2.enabled = true;
                live3.enabled = true;
                mlive1.enabled = true;
                mlive2.enabled = true;
                mlive3.enabled = true;
                break;
        }
    }
}
