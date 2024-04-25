using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    public GameObject[] CellObj;
    public List<int> Values;

    [HideInInspector]
    public Cell[] Cells;

    /*
        Next thing I will do is add an instantiation script for the cells. I want to increase the size and add
        more dimentions but It will be easier if I do it through an instantiation scrip process.

        Plus if I start by doing it this way then I can get on the intersecting scripts like game manager
        quicker and have to move less around in the future.

        For the next instantiation script I will start with hard values and just make a 5x5 grid and store
        the cells classes in a 2d array

        Then I will have to make a class for the values for each row and column. I will need to make this a 
        class so I can store multiple values and also later be able to adjust and use them for whatever purpose.

        So I will have a 2d array of value classes aswell upon instantiation

        For testing purposes I can start with manually assigning values to the value list through code
    */

    private void Start()
    {
        Cells = new Cell[CellObj.Length];
        for (int i = 0; i < Cells.Length; i++)
        {
            Cell newCell = new Cell(CellObj[i]);
            Cells[i] = newCell;
        }
        Process();
    }

    public void Process()
    {
        if (CellObj.Length == GetValueTotal())
        {
            FillStates();
        }
        else if (Values.Count == 0)
        {
            FillAbsentValues();
        }
        else
        {
            Debug.Log("Error");
        }
    }

    int GetValueTotal()
    {
        int Total = 0;
        for (int i = 0; i < Values.Count; i++)
        {
            Total += Values[i];
            if( i > 0 )
            {
                Total++;
            }
        }
        return Total;
    }

    void FillStates()
    {
        int cellIndex = 0;
        foreach (int value in Values)
        {
            for(int i = cellIndex; i < value + cellIndex; i++)
            {
                Cells[i].ChangeCellState(1);
            }
            cellIndex += value;
            try
            {
                Cells[cellIndex].ChangeCellState(2);
                cellIndex++;
            }
            catch (IndexOutOfRangeException)
            {

            }
        }
    }

    void FillAbsentValues()
    {
        foreach (Cell cell in Cells)
        {
            cell.ChangeCellState(2);
        }
    }
}
