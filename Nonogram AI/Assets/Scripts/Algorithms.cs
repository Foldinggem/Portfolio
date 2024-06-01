using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    GameManager manager;
    Value value;
    List<GridBound> scan;

    private void Start()
    {
        manager = GameManager.Instance;
    }


    public void StartProcess(Value value)
    {
        this.value = value;
        scan = new List<GridBound>();
        ScanValues();

        Debug.Log(this.value.myIndex);
        foreach (GridBound scanValue in scan)
        {
            Debug.Log($"    Left: {scanValue.left}");
            foreach (var fillVal in scanValue.fillValues)
            {
                Debug.Log("         " + fillVal);
            }
            Debug.Log($"    Right: {scanValue.right}");
        }
        //RuleOfHalfs();
    }


    void ScanValues()
    {
        int left = -1; int right = -1;
        int prevIndex = -1;
        List<int> filledIndex = new List<int>();

        for (int i = 0; i < Math.Sqrt(manager.Cells.Length); i++)
        {
            if (value.GetCellIndex(i).state != Cell.CellState.Crossed)
            {
                if (left < 0)
                {
                    left = i;
                }
                if (value.GetCellIndex(i).state == Cell.CellState.Filled)
                {
                    filledIndex.Add(i);
                }
            }
            if (value.GetCellIndex(i).state == Cell.CellState.Crossed && left >= 0)
            {
                right = prevIndex;
                scan.Add(new GridBound(left, right, filledIndex));
                left = -1; right = -1;
                filledIndex = new List<int>();
            }
            else if(left >= 0 && i == Math.Sqrt(manager.Cells.Length) - 1)
            {
                right = i;
                scan.Add(new GridBound(left, right, filledIndex));
            }

            prevIndex = i;
        }
    }


    void RuleOfHalfs()   
    {
        int index = 0;
        // Loop through each value in a set of values and call functions for each
        foreach(int number in value.values)
        {
            GridBound sideValues = new GridBound();

            // Identify and add side values to this value
            for(int i = 0; i < value.values.Count; i++)
            {
                if(i < index)
                {
                    sideValues.left += value.values[i] + 1;
                }
                else if (i > index)
                {
                    sideValues.right += value.values[i] + 1;
                }
            }

            // If there are enough values to form determined spots call the solve function to get specific spots
            if (number + sideValues.left + sideValues.right > Math.Sqrt(manager.Values.Length) / 2)
            {
                FillGrid(number, sideValues);
            }

            index++;
        }
    }

    void FillGrid(int number, GridBound sideValues)
    {
        GridBound Barrier = new GridBound(0, (int)Math.Sqrt(manager.Values.Length) - 2);
        Debug.Log(Barrier.right);

        Barrier.Pinch(sideValues);

        int availableSpace = Barrier.right + 1 - Barrier.left;
        int extra = availableSpace - number;

        Barrier.Pinch(extra);

        for(int i = Barrier.left; i <= Barrier.right; i++)
        {
            if (value.myIndex.x == 0)
            {
                Debug.Log(Barrier.left);
                manager.Cells[i, (int)value.myIndex.y - 1].ChangeCellState("Filled");
            }
            else if (value.myIndex.y == 0)
            {
                manager.Cells[(int)value.myIndex.x - 1, i].ChangeCellState("Filled");
            }
        }
    }




    /* 
    Notes to developer:
    - all "manager.Values.Length" are temporary and will later need to be changed
    */
}
