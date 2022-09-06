using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DraggingOnSurface : IUpdate
{
    private readonly DraggingOnSurfaceObject _draggingOnSurfaceObject;
    private readonly ARRaycastManager _arRaycastManager;
    private readonly List<ARRaycastHit> _arHits = new List<ARRaycastHit>();
    private const float _draggingSpeed = 2f;
    
    public DraggingOnSurface(DraggingOnSurfaceObject draggingOnSurfaceObject, ARRaycastManager arRaycastManager)
    {
        _draggingOnSurfaceObject = draggingOnSurfaceObject;
        _arRaycastManager = arRaycastManager;
    }

    void IUpdate.Update()
    {
        if (CheckHit())
        {
            MoveObject(_arHits[0].pose.position);
        }
    }

    private bool CheckHit()
    {
        return Input.touchCount > 0 &&
               _arRaycastManager.Raycast(Input.GetTouch(0).position, _arHits, TrackableType.Planes);
    }

    private void MoveObject(Vector3 targetPosition)
    {
        _draggingOnSurfaceObject.transform.position = Vector3.Lerp(_draggingOnSurfaceObject.transform.position,
            targetPosition, _draggingSpeed * Time.deltaTime);
    }
}