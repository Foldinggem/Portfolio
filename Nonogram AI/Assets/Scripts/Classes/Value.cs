using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value
{
    public List<int> values = new List<int>();
    //public GridBound[] cellsIndex = new GridBound[5];
    public Vector2 myIndex;

    GameManager manager;

    public Value(Vector2 index)
    {
        manager = GameManager.Instance;
        myIndex = index;
    }

    public void AddValue(int num)
    {
        values.Add(num);
        CheckRange();
    }

    void CheckRange()
    {
        int spaceCount = 0;

        foreach(int value in values)
        {
            spaceCount += value;
        }

        spaceCount += values.Count - 1;

        if(spaceCount > manager.Cells.Length)
        {
            throw new System.Exception("Values exceed the limit");
        }
    }

    public Cell GetCellIndex(int index)
    {
        if (myIndex.x == 0)
        {
            return manager.Cells[index, (int)myIndex.y - 1];
        }
        else
        {
            return manager.Cells[(int)myIndex.x - 1, index];
        }
    }
}
