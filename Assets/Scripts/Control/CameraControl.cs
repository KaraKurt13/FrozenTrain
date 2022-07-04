using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private static float MAX_CAMERA_ZOOM = 15;
    private static float MIN_CAMERA_ZOOM = 3;

    private bool cameraDrag = false;
    private Vector3 dragDistance;
    private Vector3 dragOrigin;

    private float maxCameraXMovement=5;
    private float minCameraXMovement=-12;
    private float maxCameraYMovement=1;
    private float minCameraYMovement=-1;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            ChangeCameraZoom();
        }

        ChangeCameraPosition();

    }

    private void ChangeCameraPosition()
    {
        if(Input.GetMouseButton(0))
        {
            dragDistance = (mainCamera.ScreenToWorldPoint(Input.mousePosition)) - mainCamera.transform.position;

            if (cameraDrag == false)
            {
                cameraDrag = true;
                dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            
        }
        else
        {
            cameraDrag = false;
        }

        if (cameraDrag)
        {
            Vector3 newPosition=new Vector3();
            newPosition.x = Mathf.Clamp(dragOrigin.x - dragDistance.x, minCameraXMovement, maxCameraXMovement);
            newPosition.y = Mathf.Clamp(dragOrigin.y - dragDistance.y , minCameraYMovement, maxCameraYMovement);
            newPosition.z = -10;

            Debug.Log(newPosition);

            mainCamera.transform.position = newPosition;
        }

    }

    private void ChangeCameraZoom()
    {
        if(Input.mouseScrollDelta.y==0)
        {
            return;
        }

        float newZoom = Mathf.Clamp(mainCamera.orthographicSize + Input.mouseScrollDelta.y, MIN_CAMERA_ZOOM, MAX_CAMERA_ZOOM);
        mainCamera.orthographicSize = newZoom;
    }

    private void ChangeCameraXMovementByCarsAmount(int carsAmount)
    {
        Debug.Log(carsAmount);
        minCameraXMovement = -12 - (carsAmount-1) * 12;
    }

    private void Awake()
    {
        TrainInformation.carsAmountChanged += ChangeCameraXMovementByCarsAmount;
    }
}
