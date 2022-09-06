using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private UI _ui;
    
    private void Awake()
    {
        _ui.Init();
    }
}