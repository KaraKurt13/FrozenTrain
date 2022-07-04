using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingCar : TrainCar
{
    public LivingCarClass carClass;
    [SerializeField] private int recommendedResidentsAmount;
    [SerializeField] private int currentResidentsAmount;

    public override void CarEffect()
    {
        throw new System.NotImplementedException();
    }

    public enum LivingCarClass
    {
        HighClass,
        MiddleClass,
        LowerClass,
    }
    
}
