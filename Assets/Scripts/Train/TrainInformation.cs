using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainInformation : MonoBehaviour
{
    public double trainSpeed;
    public List<TrainCar> trainCarList;
    public List<Passenger> passengersList;
    public delegate void CarsAmountChange(int carAmount);
    public static CarsAmountChange carsAmountChanged;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        trainCarList = new List<TrainCar>();
        trainCarList.AddRange(gameObject.GetComponentsInChildren<TrainCar>());
        carsAmountChanged(trainCarList.Count);
    }

    private void AddNewCar()
    {
        carsAmountChanged(trainCarList.Count);
    }

    private void RemoveExistingCar()
    {
        carsAmountChanged(trainCarList.Count);
    }


}
