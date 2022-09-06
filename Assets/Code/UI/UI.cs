using UnityEngine;

public class UI : MonoBehaviour, IInitializable
{
    [SerializeField] private ScanPanel _scanPanel;
    [SerializeField] private RoomPlacingPanel _roomPlacingPanel;
    [SerializeField] private RoomObservingPanel _roomObservingPanel;
    [SerializeField] private LoadingScreen _loadingScreen;
    private UIElement[] _allUIElements;

    public void Init()
    {
        _allUIElements = new UIElement[] {_scanPanel, _roomPlacingPanel, _roomObservingPanel, _loadingScreen};
    }

    public void ShowScanPanel() => ShowPanel(_scanPanel);

    public void ShowRoomPlacingPanel() => ShowPanel(_roomPlacingPanel);

    public void ShowRoomObservingPanel() => ShowPanel(_roomObservingPanel);

    private void ShowPanel(UIElement elementToBeShown)
    {
        foreach (UIElement uiElement in _allUIElements)
        {
            uiElement.Hide();
        }
        
        elementToBeShown.Show();
    }
}