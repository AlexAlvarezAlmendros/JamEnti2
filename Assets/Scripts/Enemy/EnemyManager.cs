using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;

    void Start() {
        createEnemy();
    }


    void createEnemy() {
        enemy = Instantiate(enemy);
    }


}
