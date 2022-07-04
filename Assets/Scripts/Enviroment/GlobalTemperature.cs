using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalTemperature : MonoBehaviour
{
    public int currentGlobalTemperature;
    public int avarageTemperature;

    private float timeForNextTempChange=10f; 
    private float timeForNextTempEvent;

    private static int MAX_TIME_FOR_TEMP_EVENT = 600;
    private static int MIN_TIME_FOR_TEMP_EVENT = 300;
    private static int TEMP_CHANGE_EDGE=4;

    [SerializeField] private TextMeshProUGUI temperatureText;

    private void Update()
    {
        timeForNextTempChange -= Time.deltaTime;
        timeForNextTempEvent -= Time.deltaTime;

        if (timeForNextTempChange <= 0f)
        {
            CalculateNextTemperature();
            timeForNextTempChange = 10f; 
        }

        if (timeForNextTempEvent <= 0f)
        {
            TemperatureEvent();
            SetRandomTimeForNextEvent();
        }
    }

    private void CalculateNextTemperature()
    {
        int randomChange = Random.Range(0, 2); // 0 - Decrease, 1 - Increase
        switch(randomChange)
        {
            case 0:
                {
                    if (currentGlobalTemperature == (avarageTemperature - TEMP_CHANGE_EDGE))
                    {
                        StartCoroutine(ChangeTemperature(currentGlobalTemperature+1));
                        break;
                    }

                    StartCoroutine(ChangeTemperature(currentGlobalTemperature-1));
                    break;
                }
            case 1:
                {
                    if (currentGlobalTemperature == (avarageTemperature + TEMP_CHANGE_EDGE))
                    {
                        StartCoroutine(ChangeTemperature(currentGlobalTemperature-1));
                        break;
                    }

                    StartCoroutine(ChangeTemperature(currentGlobalTemperature+1));
                    break;
                }
        }
    }

    private IEnumerator ChangeTemperature(int targetTemperature)
    {
        int tempChange; // 1 - Increase, 0 - Decrease
        if (targetTemperature > currentGlobalTemperature)
        {
            tempChange = 1;
        }
        else
        {
            tempChange = 0;
        }


        switch (tempChange)
        {
            case 0:
                {
                    int maxStep = currentGlobalTemperature - targetTemperature;
                    Debug.Log(maxStep);
                    for (int i = 0; i < maxStep; i++)
                    {
                        currentGlobalTemperature--;
                        UpdateTemperatureUI();
                        yield return new WaitForSeconds(0.1f);
                    }

                    break;
                }

            case 1:
                {
                    int maxStep = targetTemperature - currentGlobalTemperature;
                    Debug.Log(maxStep);
                    for (int i = 0; i < maxStep; i++)
                    {
                        currentGlobalTemperature++;
                        UpdateTemperatureUI();
                        yield return new WaitForSeconds(0.1f);
                    }
                    break;
                }
        }



    }

    private void UpdateTemperatureUI()
    {
        temperatureText.text = currentGlobalTemperature.ToString();
    }

    private void SetRandomTimeForNextEvent()
    {
        timeForNextTempEvent = Random.Range(MIN_TIME_FOR_TEMP_EVENT, MAX_TIME_FOR_TEMP_EVENT);
    }
    
    private void TemperatureEvent()
    {
        //event
    }

    private void Start()
    {
        SetRandomTimeForNextEvent();
        currentGlobalTemperature = 50;
        avarageTemperature = 50;
        UpdateTemperatureUI();
        
    }
}
