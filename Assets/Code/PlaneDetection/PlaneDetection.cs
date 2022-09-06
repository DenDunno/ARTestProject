using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetection : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _arRaycastManager;
    private readonly List<ARRaycastHit> _arHits = new List<ARRaycastHit>();
    private Vector2 _centreOfScreen;
    private bool _planeNotFound = true;

    public event Action<Pose> PlaneDetected;

    private void Start()
    {
        #if  UNITY_EDITOR
        PlaneDetected?.Invoke(new Pose(Vector3.zero, Quaternion.identity));    
        #endif
        
        _centreOfScreen = new Vector2(Screen.width, Screen.height) / 2f;
    }

    private void Update()
    {
        if (_arRaycastManager.Raycast(_centreOfScreen, _arHits, TrackableType.Planes) && _planeNotFound)
        {
            _planeNotFound = false;
            PlaneDetected?.Invoke(_arHits[0].pose);
        }
    }
}