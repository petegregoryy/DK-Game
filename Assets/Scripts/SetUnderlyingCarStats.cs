using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnderlyingCarStats : MonoBehaviour
{
    public float inertiaFactor = 1.0f; // Will be modified per car: DRIFT
    public float throttleTime = 1.0f; // ACCELERATION
    public float throttleTimeTraction = 10.0f; //doenst seem to do anything that can be felt.
    public float throttleRelaseTime = 0.5f; //doenst seem to do anything that can be felt.
    public float throttleReleaseTimeTraction = 0.1f; //doenst seem to do anything that can be felt.
    public float steerTime = 1.2f; //doenst seem to do anything that can be felt.
    public float veloSteerTime = 0.1f; //handling?
    public float steerReleaseTime = 0.5f; //doenst seem to do anything that can be felt.
    public float veloSteerReleaseTime = 0.01f;
    public float steerCorectionFactor = 5.0f;//handling?


    //Drivetrain:
    public float engineInertia = 0.4f;//not sure. it does something.
    public float engineRPMFriction = 0.2f;//not sure. it does something.
    public float differentialLockCoefficient = 0.1f;//not sure. it does something.



    // Start is called before the first frame update
    void Start()
    {
        Car_Stats stats = new Car_Stats(inertiaFactor, throttleTime, throttleTimeTraction, 
                                        throttleRelaseTime, throttleReleaseTimeTraction, steerTime, 
                                        veloSteerTime, steerReleaseTime, veloSteerReleaseTime, 
                                        steerCorectionFactor, engineInertia, engineRPMFriction, 
                                        differentialLockCoefficient);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
