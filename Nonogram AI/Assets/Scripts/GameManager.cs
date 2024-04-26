using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    GameState state;

    [HideInInspector]
    public Cell[,] Cells = new Cell[5, 5];
    [HideInInspector]
    public Value[,] Values;

    [HideInInspector]
    public Value tempVal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        state = GameState.Instantiation;
    }

    private void Update()
    {
        switch(state)
        {
            case GameState.Instantiation:
                FindAnyObjectByType<Instantiation>().Instantiate();
                //Values = new Value[5, 5];
                state = GameState.Solving;
                break;

            case GameState.SettingValues:
                break;

            case GameState.Solving:
                FindAnyObjectByType<Algorithms>().Process();
                break;
        }
    }


    enum GameState
    {
        Instantiation,
        SettingValues,
        Solving
    }
}
