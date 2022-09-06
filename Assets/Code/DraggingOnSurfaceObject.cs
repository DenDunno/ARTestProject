using UnityEngine;

public class DraggingOnSurfaceObject : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public Collider Collider => _collider;
}