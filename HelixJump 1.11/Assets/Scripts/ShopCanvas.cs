using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private ColorPlayer _colorPlayer;

    void Update()
    {
        ChangeStatusCanvas();
    }
    private void ChangeStatusCanvas()
    {
        switch (_game.CurrentState)
        {
            case State.Play:
            case State.Lose:
            case State.Win:
                ActiveChilds(false);
                break;
            case State.Shop:
                ActiveChilds(true);
                break;
        }
    }
    public void ActiveChilds(bool _active)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(_active);
        }
    }
    public void Exit() //кнопка
    {
        _game.PlayerPlay();
    }
    public void NextColor() //кнопка
    {
        _colorPlayer.DefineColors(1);
    }
    public void BackColor() // кнопка
    {
        _colorPlayer.DefineColors(-1);
    }
}
