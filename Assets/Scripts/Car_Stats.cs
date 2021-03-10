using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;

public class Car_Stats : MonoBehaviour
{
    //Car contoler:
    [SerializeField]
    private float __inertiaFactor { get; set; } // Will be modified per car: DRIFT
    [SerializeField]
    private float __throttleTime { get; set; } // ACCELERATION
    [SerializeField]
    private float __throttleTimeTraction { get; set; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __throttleRelaseTime { get; set; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __throttleReleaseTimeTraction { get; set; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __steerTime { get; set; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __veloSteerTime { get; set; } //handling?
    [SerializeField]
    private float __steerReleaseTime { get; set; } //doenst seem to do anything that can be felt.
    [SerializeField]
    private float __veloSteerReleaseTime { get; set; }
    [SerializeField]
    private float __steerCorectionFactor { get; set; }//handling?

    //Drivetrain:
    [SerializeField]
    private float __engineInertia { get; set; }//not sure. it does something.
    [SerializeField]
    private float __engineRPMFriction { get; set; }//not sure. it does something.
    [SerializeField]
    private float __differentialLockCoefficient { get; set; }//not sure. it does something.

    //Car contoler:
    [HideInInspector]
    public float _inertiaFactor; // Will be modified per car: DRIFT

    [HideInInspector]
    public float _throttleTime; // ACCELERATION
    [HideInInspector]
    public float _throttleTimeTraction; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _throttleRelaseTime; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _throttleReleaseTimeTraction; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _steerTime; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _veloSteerTime; //handling?

    [HideInInspector]
    public float _steerReleaseTime; //doenst seem to do anything that can be felt.
    [HideInInspector]
    public float _veloSteerReleaseTime;
    [HideInInspector]
    public float _steerCorectionFactor;//handling?


    //Drivetrain:

    [HideInInspector]
    public float _engineInertia;//not sure. it does something.
    [HideInInspector]
    public float _engineRPMFriction;//not sure. it does something.
    [HideInInspector]
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
                float veloSteerTime, float steerReleaseTime, float veloSteerReleaseTime,
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

    public void SetStatsFromFile(string carIdentifier)//Because the thing is whiny, it needs to be used itemofcarstats.SetStatsFromFile(carIdentifier);
    {
        //load xml file
        XmlDocument listOfCars = new XmlDocument();
        listOfCars.Load("carstatfile.xml");
        int x = 0;
        foreach (XmlNode car in listOfCars)
        {

            //find car
            if (car.ChildNodes.Item(x).Attributes["name"].Value == carIdentifier)
            {

                //set double-underscore variables to stats of the file

                //car controler:
                __inertiaFactor = float.Parse(car.ChildNodes.Item(x).Attributes["inertiaFactor"].Value);
                __throttleTime = float.Parse(car.ChildNodes.Item(x).Attributes["throttleTime"].Value);
                __throttleTimeTraction = float.Parse(car.ChildNodes.Item(x).Attributes["throttleTimeTraction"].Value);
                __throttleRelaseTime = float.Parse(car.ChildNodes.Item(x).Attributes["throttleRelaseTime"].Value);
                __throttleReleaseTimeTraction = float.Parse(car.ChildNodes.Item(x).Attributes["throttleReleaseTimeTraction"].Value);
                __steerTime = float.Parse(car.ChildNodes.Item(x).Attributes["steerTime"].Value);
                __veloSteerTime = float.Parse(car.ChildNodes.Item(x).Attributes["veloSteerTime"].Value);
                __steerReleaseTime = float.Parse(car.ChildNodes.Item(x).Attributes["steerReleaseTime"].Value);
                __veloSteerReleaseTime = float.Parse(car.ChildNodes.Item(x).Attributes["veloSteerReleaseTime"].Value);
                __steerCorectionFactor = float.Parse(car.ChildNodes.Item(x).Attributes["steerCorectionFactor"].Value);
                //Drivetrain:
                __engineInertia = float.Parse(car.ChildNodes.Item(x).Attributes["engineInertia"].Value);
                __engineRPMFriction = float.Parse(car.ChildNodes.Item(x).Attributes["engineRPMFriction"].Value);
                __differentialLockCoefficient = float.Parse(car.ChildNodes.Item(x).Attributes["differentialLockCoefficient"].Value);

                this.returnStatsToNormal();//sets the stats of single-underscore variables for us

            }
            x = x + 1;
        }
    }

    public void returnStatsToNormal()
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

