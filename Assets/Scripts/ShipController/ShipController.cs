using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float thrustForce = 20f;
    public float shootRate;
    public Rigidbody spaceshipRigidbody;

    public GameObject projectile;
    public Transform projectileSpawnTransform;
    private float nextShot = 0.0f;

    float horizontalInput;
    float verticalInput;

    public Transform lookRight;
    public Transform lookLeft;
    public Transform lookUp;
    public Transform lookDown;
    public float RotateSpeed = 30f;

    bool down, up, right, left;


    void Update() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        down = Input.GetButton("down");
        up = Input.GetButton("up");
        right = Input.GetButton("right");
        left = Input.GetButton("left");
        TurnSpaceShip();
    }

    private void FixedUpdate()
    {
        MoveSpaceship();
        spaceshipRigidbody.velocity = new Vector2(horizontalInput * thrustForce, verticalInput * thrustForce);
    }

    void MoveSpaceship()
    {
        spaceshipRigidbody.velocity = transform.forward * thrustForce * (Mathf.Max(thrustForce, .2f));
    }

    void TurnSpaceShip() {

        if (left)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookLeft.rotation, Time.time * RotateSpeed);
        }

        if (right)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRight.rotation, Time.time * RotateSpeed);
        }

        if (up)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookUp.rotation, Time.time * RotateSpeed);
        }

        if (down)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, lookLeft.rotation, Time.time * RotateSpeed);
        }

    }








    void CalculateShootingLogic()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time > nextShot)
            {
                ShootProjectile();
                nextShot = Time.time + shootRate;
            }
        }
    }
    void ShootProjectile()
    {

        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        newProjectile.transform.position = projectileSpawnTransform.position;
        newProjectile.transform.rotation = projectileSpawnTransform.rotation;
        newProjectile.SetActive(true);

    }
}
