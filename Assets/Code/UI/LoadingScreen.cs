using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : UIElement
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _startButton;
    private const float _speed = 0.4f;
    
    private IEnumerator Start()
    {
        while (_slider.value < 0.99f)
        {
            _slider.value += Time.deltaTime * _speed;
            yield return null;
        }
        
        _slider.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(true);
    }
}