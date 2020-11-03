using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    public enum RandomSpawnerShape
    {
        Box,
        Sphere
    }

    public Transform prefab;

    public RandomSpawnerShape spawnShape = RandomSpawnerShape.Sphere;
    public Vector3 shapeModifiers = Vector3.one;

    //Cuantos Spawnean??
    public int asteroidCount = 50;

    //Rango
    public float range = 1000.0f;

    //Rotacion aleatoria?¿
    public bool randomRotation = true;

    //Escala e los elementos?¿
    public Vector2 scaleRange = new Vector2(1.0f, 3.0f);


    //Fisicas
    public float velocity = 0.0f;

    public float angularVelocity = 0.0f;

    //escala la masa segun la escala
    public bool scaleMass = true;



    void Start()
    {
        if (prefab != null)
        {
            for (int i = 0; i < asteroidCount; i++)
                CreateAsteroid();
        }
    }
    private void CreateAsteroid()
    {
        Vector3 spawnPos = Vector3.zero;

        if (spawnShape == RandomSpawnerShape.Box)
        {
            spawnPos.x = Random.Range(-range, range) * shapeModifiers.x;
            spawnPos.y = Random.Range(-range, range) * shapeModifiers.y;
            spawnPos.z = Random.Range(-range, range) * shapeModifiers.z;
        }
        else if (spawnShape == RandomSpawnerShape.Sphere)
        {
            spawnPos = Random.insideUnitSphere * range;
            spawnPos.x *= shapeModifiers.x;
            spawnPos.y *= shapeModifiers.y;
            spawnPos.z *= shapeModifiers.z;
        }

        spawnPos += transform.position;

        Quaternion spawnRot = (randomRotation) ? Random.rotation : Quaternion.identity;

        Transform t = Instantiate(prefab, spawnPos, spawnRot) as Transform;
        t.SetParent(transform);

        float scale = Random.Range(scaleRange.x, scaleRange.y);
        t.localScale = Vector3.one * scale;

        Rigidbody rdry = t.GetComponent<Rigidbody>();
        if (rdry)
        {
            if (scaleMass)
                rdry.mass *= scale * scale * scale;

            rdry.AddRelativeForce(Random.insideUnitSphere * velocity, ForceMode.VelocityChange);
            rdry.AddRelativeTorque(Random.insideUnitSphere * angularVelocity * Mathf.Deg2Rad, ForceMode.VelocityChange);
        }
    }

    public void CreateNewAstroid()
    {
        CreateAsteroid();
    }
}
