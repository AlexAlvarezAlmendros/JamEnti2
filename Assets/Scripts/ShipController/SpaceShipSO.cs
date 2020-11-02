using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spaceship Data", menuName = "Scriptable Objects/Spaceship Data", order = 1)]
public class SpaceShipSO : ScriptableObject
{
    public float thrustAmount;
    public float thrustInput;
    public float yawSpeed;
    public float pitchSpeed;
    public Vector3 steeringInput;

    public float leanAmount_X;
    public float leanAmount_Y;

    public float shootRate;

    public bool shootInput;

    public void UpdateInputData(Vector3 newSteering, float newThrust, bool newShoot)
    {
        steeringInput = newSteering;
        thrustInput = newThrust;
        shootInput = newShoot;
    }
}
