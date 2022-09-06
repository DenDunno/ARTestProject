using UnityEngine;

public class PlaneDetectionEventHandler : MonoBehaviour
{
    [SerializeField] private PlaneDetection _planeDetection;
    [SerializeField] private UI _ui;
    [SerializeField] private VisibleDoor _visibleDoor;
    
    private void OnEnable()
    {
        _planeDetection.PlaneDetected += OnPlaneDetected;
    }

    private void OnDisable()
    {
        _planeDetection.PlaneDetected -= OnPlaneDetected;
    }
    
    private void OnPlaneDetected(Pose pose)
    {
        _ui.ShowRoomPlacingPanel();
        _visibleDoor.Activate(pose);
    }
}