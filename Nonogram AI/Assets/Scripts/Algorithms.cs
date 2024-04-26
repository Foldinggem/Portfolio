using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
    }


    public void FillByCount()   
    {

    }




    //public void Process()
    //{
    //    if (manager.tempVal.cells.Length == GetValueTotal())
    //    {
    //        FillStates();
    //    }
    //    else if (manager.tempVal.values.Count == 0)
    //    {
    //        FillAbsentValues();
    //    }
    //}

    //int GetValueTotal()
    //{
    //    int Total = 0;
    //    for (int i = 0; i < manager.tempVal.values.Count; i++)
    //    {
    //        Total += manager.tempVal.values[i];
    //        if (i > 0)
    //        {
    //            Total++;
    //        }
    //    }
    //    return Total;
    //}

    //void FillStates()
    //{
    //    int cellIndex = 0;
    //    foreach (int value in manager.tempVal.values)
    //    {
    //        for (int i = cellIndex; i < value + cellIndex; i++)
    //        {
    //            manager.tempVal.cells[i].ChangeCellState(1);
    //        }
    //        cellIndex += value;
    //        try
    //        {
    //            manager.tempVal.cells[cellIndex].ChangeCellState(2);
    //            cellIndex++;
    //        }
    //        catch (IndexOutOfRangeException)
    //        {

    //        }
    //    }
    //}

    //void FillAbsentValues()
    //{
    //    foreach (Cell cell in manager.tempVal.cells)
    //    {
    //        cell.ChangeCellState(2);
    //    }
    //}
}
