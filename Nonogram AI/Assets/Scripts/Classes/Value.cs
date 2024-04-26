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
    }
}
