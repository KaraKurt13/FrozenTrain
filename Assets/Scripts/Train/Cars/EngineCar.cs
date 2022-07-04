using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineCar : TrainCar
{
    public int enginePower;
    public double engineDurability;

    [SerializeField] private TrainInformation trainInfo;


    public override void CarEffect()
    {
        SetTrainSpeed();
    }

    private void SetTrainSpeed()
    {
        trainInfo.trainSpeed = enginePower * 1.3;
    }

    private void Start()
    {
        engineDurability = 100;
        enginePower = 50;
        SetTrainSpeed();
    }

    private void Update()
    {
        CarEffect();
    }
}
