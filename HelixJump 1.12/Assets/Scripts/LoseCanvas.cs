using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCanvas : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Player _player;
    [SerializeField] private Text _newRecordText;
    [SerializeField] private Text _progressSliderText;
    [SerializeField] private Slider _slider;

    void Update()
    {
        ChangeStatusCanvas();
    }
    public void ActiveChilds(bool _activ) 
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(_activ); 
        }
    }
    private void ChangeStatusCanvas()
    {
        switch (_game.CurrentState)
        {
            case State.Play:
            case State.Win:
            case State.Shop:
                ActiveChilds(false);
                break;
            case State.Lose:
                Completed();
                Scoring.BestPointsInfo();
                NewRecord();
                ActiveChilds(true);
                break;
        }
    }
    public void Restart() //кнопка
    {
        _game.ReloadLevel();
    }
    public void SecondChanse() // кнопка
    {
        _player.IgnorDie();
    }
    private void NewRecord()
    {
        if (!Scoring.HaveChanges)return;
        _newRecordText.text = "NEW RECORD: " + Scoring.BestPoints.ToString();
    }
    private void Completed()
    {
        _progressSliderText.text = (_slider.value *100).ToString("F0") + "% COMPLETED ";
    }

}
