using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _finishPosition;
    [SerializeField] private Slider _slider;
    [SerializeField] private Game _game;
    [SerializeField] private float _additional;
    [SerializeField] private Text _currentLevel;
    [SerializeField] private Text _nextLevel;
    [SerializeField] private Text _bestPointsText;
    [SerializeField] private Text _allPointsLevel;

    [SerializeField] private Sprite _AudioOnSprite;
    [SerializeField] private Sprite _AudioOffSprite;

    private float _startY;
    private float _finishY;
    private float _minPositionY;
    private float _dynamicsY;

   
    void Start()
    {
        SliderStart();
    }

    void Update()
    {
        AudioSprite();
        SliderWork();
        ScoringPoints();
        ChangeStatusCanvas();
    }
    private void SliderStart()
    {
        _startY = _player.transform.position.y;
        _finishY = _finishPosition.position.y + _additional;
        _currentLevel.text = (_game.LevelIndex + 1).ToString();
        _nextLevel.text = (_game.LevelIndex + 2).ToString();
    }
    private void SliderWork()
    {
        _minPositionY = Mathf.Min(_minPositionY, _player.transform.position.y);
        _dynamicsY = Mathf.InverseLerp(_startY, _finishY, _minPositionY);
        _slider.value = _dynamicsY;
    }
    public void Restart() // кнопка
    {
        _game.ReloadLevel();
    }
    public void ShopActivation() // кнопка
    {
        _player.GoShop();
    }
    public void ScoringPoints()
    {
        _allPointsLevel.text = Scoring.AllPointsLevel.ToString();
        _bestPointsText.text = Scoring.BestPoints.ToString();
    }
    private void ChangeStatusCanvas()
    {
        switch (_game.CurrentState)
        {
            case State.Play:
                transform.Find("RestartButton").gameObject.SetActive(true);
                transform.Find("ShopButton").gameObject.SetActive(true);
                transform.Find("BestPoints").gameObject.SetActive(true);
                transform.Find("AudioButton").gameObject.SetActive(true);
                break;
            case State.Lose:
            case State.Win:
            case State.Shop:
                transform.Find("RestartButton").gameObject.SetActive(false);
                transform.Find("BestPoints").gameObject.SetActive(false);
                transform.Find("ShopButton").gameObject.SetActive(false);
                transform.Find("AudioButton").gameObject.SetActive(false);
                break;
        }
    }
    public void Audio() // кнопка
    {
        AudioStatus.ChangeVolumeAudio();
        AudioSprite();
    }
    private void AudioSprite()
    {
        AudioStatus.CheckSoundMatch();
        if (AudioStatus._IsAudioOn)
            transform.Find("AudioButton").gameObject.GetComponent<Image>().sprite = _AudioOnSprite;
        else
            transform.Find("AudioButton").gameObject.GetComponent<Image>().sprite = _AudioOffSprite;
    }
}
