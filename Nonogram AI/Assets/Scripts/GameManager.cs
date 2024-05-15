using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Size;
    GameState state;

    [HideInInspector]
    public Cell[,] Cells;
    [HideInInspector]
    public Value[,] Values;

    //[HideInInspector]
    //public Value tempVal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Cells = new Cell[Size, Size];
            Values = new Value[Size + 1, Size + 1];
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
                state = GameState.Solving;
                break;

            case GameState.SettingValues:
                break;

            case GameState.Solving:
                for (int i = 1; i < 6; i++)
                {
                    var value = Values[0,i];
                    try
                    {
                        FindAnyObjectByType<Algorithms>().StartProcess(value);
                    }
                    catch { }
                }
                for (int i = 1; i < 6; i++)
                {
                    var value = Values[i, 0];
                    try
                    {
                        FindAnyObjectByType<Algorithms>().StartProcess(value);
                    }
                    catch { }
                }
                state = GameState.Idle;
                break;

            case GameState.Idle:
                break;
        }
    }


    enum GameState
    {
        Instantiation,
        SettingValues,
        Solving,
        Idle
    }
}
