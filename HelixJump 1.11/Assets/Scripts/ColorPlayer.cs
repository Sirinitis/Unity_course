using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlayer : MonoBehaviour
{
    [SerializeField] private Material[] _colors;

    private Renderer _playerRenderer;
    public  int _currentColor { get => PlayerPrefs.GetInt(CurrentColorKey, 0); private set => PlayerPrefs.SetInt(CurrentColorKey, value); }

    private const string CurrentColorKey = "CurrentColor";
    void Start()
    {
        _playerRenderer = transform.gameObject.GetComponent<Renderer>();
        _playerRenderer.sharedMaterial = _colors[_currentColor];
    }
    public void DefineColors(int choice)
    {
        _currentColor += choice;

        if (_currentColor >= _colors.Length)
        {
            _currentColor = 0;
            _playerRenderer.sharedMaterial = _colors[_currentColor];
        }
        if (_currentColor < 0)
        {
            _currentColor = _colors.Length - 1;
            _playerRenderer.sharedMaterial = _colors[_currentColor];
        }
        else
            _playerRenderer.sharedMaterial = _colors[_currentColor];
    }
}
