using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
    }

    public void CreateCase()
    {
        //CreateRowValue(0, 3, new List<int> { 6 });
        //CreateRowValue(0, 4, new List<int> { 3,5 });
        try
        {
            SetRowStates(0, 3, new List<int> { 1, 2, 3, 6, 7 }, new List<int> { 5, 8, 9 });
        }
        catch
        {
            throw new Exception("Test case length doesn't match grid size");
        }
    }

    void CreateRowValue(int x_Index, int y_Index, List<int> values)
    {
        Value newValue = new Value(new Vector2(x_Index, y_Index));

        foreach (int value in values)
        {
            newValue.AddValue(value);
        }

        manager.Values[x_Index, y_Index] = newValue;
    }

    void SetRowStates(int x_Index, int y_Index, List<int> Filled, List<int> Crossed)
    {
        if (x_Index == 0)
        {
            foreach (int fillIndex in Filled)
            {
                manager.Cells[fillIndex, y_Index].ChangeCellState("Filled");
            }
            foreach (int crossIndex in Crossed)
            {
                manager.Cells[crossIndex, y_Index].ChangeCellState("Crossed");
            }
        }
    }
}
