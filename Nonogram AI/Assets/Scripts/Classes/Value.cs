using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value
{
    public List<int> values = new List<int>();
    //public GridBound[] cellsIndex = new GridBound[5];
    public int myIndex;

    GameManager manager;

    public Value(int index)
    {
        manager = GameManager.Instance;

        //for (int i = 0; i < cellsIndex.Length; i++)
        //{
        //    cellsIndex[i] = new GridBound(i, index);
        //}
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
}
