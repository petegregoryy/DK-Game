﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftCalculator : MonoBehaviour
{
    Vector3 pointing = new Vector3();
    Vector3 moving = new Vector3();
    points_score_100511480 pointStore = new points_score_100511480(100,1);


    [SerializeField]
    Rigidbody carRb;
    [SerializeField]
    Text angleText;
    [SerializeField]
    Text multText;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text tempScoreText;

    float driftTimer = 0;
    float score = 0;
    float tempScore = 0;
    float tempScoreWithMulti = 0;
    float multiplier = 1;
    float multTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        tempScoreText.enabled = false;
        multText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Trigger").ToString());


        pointing = carRb.transform.forward;
        moving = carRb.velocity;

        float angle = Vector3.Angle(pointing, moving);
        int intAngle = (int)angle;

        Vector3 movingPoint = carRb.position + (moving * (moving.magnitude));
        Vector3 pointingPoint = carRb.position + (pointing * 50);

        Debug.DrawLine(carRb.position, movingPoint);
        Debug.DrawLine(carRb.position, pointingPoint);
        //Debug.Log(moving.magnitude);

        if (angle > 5.0f && angle < 90.0f)
        {
            angleText.text = "Dorifto Angle: " + intAngle.ToString();
            if (moving.magnitude > 0.5f)
            {
                AddScore(intAngle);
                //DriftController();
            }
        }
        else if(angle > 90.0f)
        {
            pointStore.BANK_POINTS();
            angleText.text = "Dorifto Angle: Spinout";
            //score += tempScore * multiplier;
            pointStore.Set_drifting_multiplier(1);
            pointStore.Set_temp_points(0);

            driftTimer = 0;
            //multiplier = 1;
            //tempScore = 0;
            scoreText.text = pointStore.Get_total_score().ToString().PadLeft(15, '0');
            tempScoreText.enabled = false;
            multText.enabled = false;
        }
        else
        {
            pointStore.BANK_POINTS();
            angleText.text = "Dorifto Angle: Straight";
            //score += tempScore * multiplier;

            pointStore.Set_drifting_multiplier(1);
            pointStore.Set_temp_points(0);

            driftTimer = 0;
            //multiplier = 1;
            //tempScore = 0;
            scoreText.text = pointStore.Get_total_score().ToString().PadLeft(15, '0');
            tempScoreText.enabled = false;
            multText.enabled = false;
        }
    }

    void AddScore(int angle)
    {

        driftTimer += Time.deltaTime;
        multTimer += Time.deltaTime;
        if (multTimer >= 1.0f)
        {
            pointStore.Increment_drifting_multiplier(1);
            multTimer = 0;
        }
        pointStore.ADD_TO_TEMP_SCORE(angle);
        tempScoreText.text = pointStore.Get_temp_points().ToString();
        multText.text = "x " + pointStore.Get_drifting_multiplier().ToString().PadLeft(2,'0');
        tempScoreText.enabled = true;
        multText.enabled = true;
    }


    private void FixedUpdate()
    {
        if(moving.magnitude > 5)
        {
            DriftController();
        }
    }
    void DriftController()
    {
        bool LeftInput = Input.GetKey(KeyCode.LeftArrow);
        bool RightInput = Input.GetKey(KeyCode.RightArrow);
        float turn = 15.0f;
        float torque = 500.0f;

        if (LeftInput)
        {
            carRb.AddTorque(-(transform.up * torque * turn));
        }
        if (RightInput)
        {
            carRb.AddTorque(transform.up * torque * turn);
        }
    }
}