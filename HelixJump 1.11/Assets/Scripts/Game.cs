using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum State
{
    Play,
    Win,
    Lose,
    Shop
}

public class Game : MonoBehaviour
{
    [SerializeField] private Controls _controls;

    public State CurrentState { get; private set;}
    public int LevelIndex { get => PlayerPrefs.GetInt(LevelIndexKey, 0);private set => PlayerPrefs.SetInt(LevelIndexKey,value); }

    private const string LevelIndexKey = "LevelIndex";

    public void Start()
    {
        Scoring.Bonuspoints = LevelIndex+1;
        Scoring.DestroyPoints();
        PlayerPlay();
    }
    public void PlayerPlay()
    {
        CurrentState = State.Play;
        _controls.enabled = true;
        print("Go!");
    }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Play && CurrentState != State.Shop) return;
        CurrentState = State.Lose;
        _controls.enabled = false;
        print("You Lose!");
    }
    public void OnPlayerFinish()
    {
        if (CurrentState != State.Play && CurrentState != State.Shop) return;
        CurrentState = State.Win;
        _controls.enabled = false;
        LevelIndex++;
        print("You Win!");
    }
    public void ShopOpen()
    {
        if (CurrentState != State.Play) return;
        CurrentState = State.Shop;
        _controls.enabled = false;
        print("Shop open!");
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Scoring.DestroyPoints();
    }
    public void ContinueLevel() 
    {
        if (CurrentState != State.Lose) return;
        PlayerPlay();
        print("Second chanse!");
    }
    public void PlayerGetPoints()
    {
        if (CurrentState != State.Play) return;
        Scoring.ScoringPoints();
    }
}
