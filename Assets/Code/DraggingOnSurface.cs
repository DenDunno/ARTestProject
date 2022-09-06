using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DraggingOnSurface : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _arRaycastManager;
    private readonly List<ARRaycastHit> _arHits = new List<ARRaycastHit>();
    private const float _draggingSpeed = 2f;

    private void Update()
    {
        if (CheckHit())
        {
            MoveObject(_arHits[0].pose.position);
        }
    }

    private bool CheckHit()
    {
        return Input.touchCount > 0 &&
               EventSystem.current.IsPointerOverGameObject() == false && 
               _arRaycastManager.Raycast(Input.GetTouch(0).position, _arHits, TrackableType.Planes);
    }

    private void MoveObject(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, _draggingSpeed * Time.deltaTime);
    }
}