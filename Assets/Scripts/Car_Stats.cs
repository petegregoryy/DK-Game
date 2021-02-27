using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

class Car_Stats : MonoBehaviour
{
    //Car contoler:
    [SerializeField]
    private float __inertiaFactor {get;} // Will be modified per car: DRIFT
    [SerializeField]
    private float __throttleTime { get; } // ACCELERATION
<<<<<<< HEAD
    [SerializeField]
=======
    [SerializeField] 
>>>>>>> cb25de2f5828a005e38b82185b2777abfcfdbcd8
    private float __throttleTimeTraction { get; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __throttleRelaseTime { get; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __throttleReleaseTimeTraction { get; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __steerTime { get; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __veloSteerTime { get; } //handling?
<<<<<<< HEAD
    [SerializeField]
    private float __steerReleaseTime { get; } //doenst seem to do anything that can be felt.
    [SerializeField]
=======
    [SerializeField] 
    private float __steerReleaseTime { get; } //doenst seem to do anything that can be felt.
    [SerializeField] 
>>>>>>> cb25de2f5828a005e38b82185b2777abfcfdbcd8
    private float __veloSteerReleaseTime { get; }
    [SerializeField]
    private float __steerCorectionFactor { get; }//handling?

    //Drivetrain:
    [SerializeField]
    private float __engineInertia { get; }//not sure. it does something.
    [SerializeField]
    private float __engineRPMFriction { get; }//not sure. it does something.
<<<<<<< HEAD
    [SerializeField]
=======
    [SerializeField] 
>>>>>>> cb25de2f5828a005e38b82185b2777abfcfdbcd8
    private float __differentialLockCoefficient { get; }//not sure. it does something.

    //Car contoler:
    [HideInInspector]
    public float _inertiaFactor; // Will be modified per car: DRIFT
<<<<<<< HEAD
    [HideInInspector]
    public float _throttleTime; // ACCELERATION
    [HideInInspector]
    public float _throttleTimeTraction; //doenst seem to do anything that can be felt.
    [HideInInspector]
=======
    [HideInInspector] 
    public float _throttleTime; // ACCELERATION
    [HideInInspector]
    public float _throttleTimeTraction; //doenst seem to do anything that can be felt.
    [HideInInspector] 
>>>>>>> cb25de2f5828a005e38b82185b2777abfcfdbcd8
    public float _throttleRelaseTime; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _throttleReleaseTimeTraction; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _steerTime; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _veloSteerTime; //handling?
<<<<<<< HEAD
    [HideInInspector]
=======
    [HideInInspector] 
>>>>>>> cb25de2f5828a005e38b82185b2777abfcfdbcd8
    public float _steerReleaseTime; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _veloSteerReleaseTime;
    [HideInInspector]
    public float _steerCorectionFactor;//handling?


    //Drivetrain:
<<<<<<< HEAD
    [HideInInspector]
    public float _engineInertia;//not sure. it does something.
    [HideInInspector]
    public float _engineRPMFriction;//not sure. it does something.
    [HideInInspector]
=======
    [HideInInspector] 
    public float _engineInertia;//not sure. it does something.
    [HideInInspector] 
    public float _engineRPMFriction;//not sure. it does something.
    [HideInInspector] 
>>>>>>> cb25de2f5828a005e38b82185b2777abfcfdbcd8
    public float _differentialLockCoefficient;//not sure. it does something.

    public Car_Stats()
    {
        //car controler:
        _inertiaFactor = 1.5f;
        _throttleTime = 1.0f;
        _throttleTimeTraction = 10.0f;
        _throttleRelaseTime = 0.5f;
        _throttleReleaseTimeTraction = 0.1f;
        _steerTime = 1.2f;
        _veloSteerTime = 0.1f;
        _steerReleaseTime = 0.6f;
        _veloSteerReleaseTime = 0f;
        _steerCorectionFactor = 4.0f;

        //Drivetrain:
        _engineInertia = 0.3f;
        _engineRPMFriction = 0.2f;
        _differentialLockCoefficient = 0.1f;

        //private versions:
        //car controler:
        __inertiaFactor = 1.5f;
        __throttleTime = 1.0f;
        __throttleTimeTraction = 10.0f;
        __throttleRelaseTime = 0.5f;
        __throttleReleaseTimeTraction = 0.1f;
        __steerTime = 1.2f;
        __veloSteerTime = 0.1f;
        __steerReleaseTime = 0.6f;
        __veloSteerReleaseTime = 0f;
        __steerCorectionFactor = 4.0f;
        //Drivetrain:
        __engineInertia = 0.3f;
        __engineRPMFriction = 0.2f;
        __differentialLockCoefficient = 0.1f;
    }
    public Car_Stats(float inertiaFactor, float throttleTime, float throttleTimeTraction, 
                float throttleRelaseTime, float throttleReleaseTimeTraction, float steerTime, 
                float veloSteerTime, float steerReleaseTime,float veloSteerReleaseTime, 
                float steerCorectionFactor, float engineInertia, float engineRPMFriction, 
                float differentialLockCoefficient)
    {
        //car controler:
        _inertiaFactor = inertiaFactor;
        _throttleTime = throttleTime;
        _throttleTimeTraction = throttleTimeTraction;
        _throttleRelaseTime = throttleRelaseTime;
        _throttleReleaseTimeTraction = throttleReleaseTimeTraction;
        _steerTime = steerTime;
        _veloSteerTime = veloSteerTime;
        _steerReleaseTime = steerReleaseTime;
        _veloSteerReleaseTime = veloSteerReleaseTime;
        _steerCorectionFactor = steerCorectionFactor;

        //Drivetrain:
        _engineInertia = engineInertia;
        _engineRPMFriction = engineRPMFriction;
        _differentialLockCoefficient = differentialLockCoefficient;


        //private versions
        //car controler:
        __inertiaFactor = inertiaFactor;
        __throttleTime = throttleTime;
        __throttleTimeTraction = throttleTimeTraction;
        __throttleRelaseTime = throttleRelaseTime;
        __throttleReleaseTimeTraction = throttleReleaseTimeTraction;
        __steerTime = steerTime;
        __veloSteerTime = veloSteerTime;
        __steerReleaseTime = steerReleaseTime;
        __veloSteerReleaseTime = veloSteerReleaseTime;
        __steerCorectionFactor = steerCorectionFactor;
        //Drivetrain:
        __engineInertia = engineInertia;
        __engineRPMFriction = engineRPMFriction;
        __differentialLockCoefficient = differentialLockCoefficient;
    }

    void returnStatsToNormal()
    {
        //car controler:
        _inertiaFactor = __inertiaFactor;
        _throttleTime = __throttleTime;
        _throttleTimeTraction = __throttleTimeTraction;
        _throttleRelaseTime = __throttleRelaseTime;
        _throttleReleaseTimeTraction = __throttleReleaseTimeTraction;
        _steerTime = __steerTime;
        _veloSteerTime = __veloSteerTime;
        _steerReleaseTime = __steerReleaseTime;
        _veloSteerReleaseTime = __veloSteerReleaseTime;
        _steerCorectionFactor = __steerCorectionFactor;

        //Drivetrain:
        _engineInertia = __engineInertia;
        _engineRPMFriction = __engineRPMFriction;
        _differentialLockCoefficient = __differentialLockCoefficient;
    }
}

