using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value
{
    public List<int> values = new List<int>();
    public Cell[] cells = new Cell[5];

    GameManager manager;

    public Value()
    {
        manager = GameManager.Instance;

        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = manager.Cells[i,2];
        }
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

        if(spaceCount > cells.Length)
        {
            throw new System.Exception("Values exceed the limit");
        }
    }
}
