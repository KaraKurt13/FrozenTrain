using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrainCar : MonoBehaviour
{
    public float temperature;
    public float durability=100;

    public abstract void CarEffect();
}
