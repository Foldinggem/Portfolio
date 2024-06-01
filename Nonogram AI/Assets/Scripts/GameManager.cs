using System;
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
                FindAnyObjectByType<TestCase>().CreateCase();
                state = GameState.SettingValues;
                break;

            case GameState.SettingValues:
                CreateBlankValues();
                state = GameState.Solving;
                break;

            case GameState.Solving:
                for (int i = 1; i < Math.Sqrt(Values.Length); i++)
                {
                    var value = Values[0,i];
                    FindAnyObjectByType<Algorithms>().StartProcess(value);
                }

                for (int i = 1; i < Math.Sqrt(Values.Length); i++)
                {
                    var value = Values[i, 0];
                    FindAnyObjectByType<Algorithms>().StartProcess(value);
                }
                state = GameState.Idle;
                break;

            case GameState.Idle:
                break;
        }
    }

    void CreateBlankValues()
    {
        for(int i = 1; i < Math.Sqrt(Values.Length); i++)
        {
            Values[i, 0] = new Value(new Vector2(i, 0));
            Values[0, i] = new Value(new Vector2(0, i));
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
