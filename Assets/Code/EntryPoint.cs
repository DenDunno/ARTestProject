using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryPoint : MonoBehaviourWrapper
{
    [SerializeField] private DraggingOnSurfaceObject _portal;
    [SerializeField] private ARRaycastManager _arRaycastManager;
    
    private void Awake()
    {
        SetDependencies(new object[]
        {
            new DraggingOnSurface(_portal, _arRaycastManager)
        });
    }
}