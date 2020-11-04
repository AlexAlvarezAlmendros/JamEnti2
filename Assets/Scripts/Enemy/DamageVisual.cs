using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageVisual : MonoBehaviour
{
    public EnemyController controller;
    public GameObject explosion;

    public void OnDamage()
    {
        if (controller.health < 0f) {
            var explosion_ = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion_.gameObject, 1f);

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            OnDamage();
            Destroy(col.gameObject);
        }
    }
}
