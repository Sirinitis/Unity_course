using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Game _game;
    
    private void Update()
    {
        ChangeStatusCanvas();
    }
    public void ActiveChilds(bool _active)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(_active);
        }
    }
    private void ChangeStatusCanvas()
    {
        switch (_game.CurrentState)
        {
            case State.Win:
                ActiveChilds(true);
                Scoring.BestPointsInfo();
                GetInfoLevelPassed();
                break;
            case State.Play:
            case State.Lose:
            case State.Shop:
                ActiveChilds(false);
                break;
        }
    }
    private void GetInfoLevelPassed()
    {
        _text.text = "Level " + _game.LevelIndex.ToString() + " passed";
    }
    public void Restart() // кнопка
    {
        _game.ReloadLevel();
    }
}

