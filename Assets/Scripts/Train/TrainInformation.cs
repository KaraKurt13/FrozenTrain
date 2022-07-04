using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainInformation : MonoBehaviour
{
    public double trainSpeed;
    public List<TrainCar> trainCarList;
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
        SetTrainCars();
    }

    private void SetTrainCars()
    {
        for(int i=1;i<trainCarList.Count;i++)
        {
            trainCarList[i].gameObject.transform.Translate(new Vector3(-12f,0f,0f));

            for(int j=i+1;j<trainCarList.Count;j++)
            {
                trainCarList[j].gameObject.transform.Translate(new Vector3(-12f, 0f, 0f));
            }
        }

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
