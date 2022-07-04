using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{
    private TrainInformation trainInfo;
    
    private void SetTrainCars()
    {
        for (int i = 1; i < trainInfo.trainCarList.Count; i++)
        {
            trainInfo.trainCarList[i].gameObject.transform.Translate(new Vector3(-12f, 0f, 0f));

            for (int j = i + 1; j < trainInfo.trainCarList.Count; j++)
            {
                trainInfo.trainCarList[j].gameObject.transform.Translate(new Vector3(-12f, 0f, 0f));
            }
        }
    }

    private void Start()
    {
        trainInfo = GetComponent<TrainInformation>();
    }
}
