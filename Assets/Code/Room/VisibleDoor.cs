using UnityEngine;

public class VisibleDoor : MonoBehaviour
{
    [SerializeField] private Room _room;

    public void Activate(Pose pose)
    {
        gameObject.SetActive(true);
        transform.SetPositionAndRotation(pose.position, pose.rotation);
    }
    
    public void Show()
    {
        ToggleRoom(false);
    }
    
    public void Hide()
    {
        ToggleRoom(true);
        _room.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }

    private void ToggleRoom(bool activate)
    {
        _room.gameObject.SetActive(activate);
        gameObject.SetActive(activate == false);
    }
}