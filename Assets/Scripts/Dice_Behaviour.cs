using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Behaviour : MonoBehaviour
{
    public GameObject[] Sides;
    public bool Stationary = false;

    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, UnityEngine.Random.Range(10.0f, 15.0f));
    }

    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            Stationary = true;
        }
    }

    public void SetWinningNumber(int number)
    {

    }
}
