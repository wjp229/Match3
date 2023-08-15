using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState _gameState = GameState.Ready;

    private BoardContainer _boardContainer;
    public BoardContainer BoardContainer
    {
        get { return _boardContainer; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        _boardContainer = GetComponent<BoardContainer>();
        _boardContainer.InitializeGameSettings();
    }

    public void GameStart()
    {
        if (_gameState != GameState.Ready)
        {
            return;
        }

        _gameState = GameState.Progressing;
        
        // Init Board
        _boardContainer.InitializeBoard();
    }
}

enum GameState
{
    Ready,
    Progressing,
    End
}