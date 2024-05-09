using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    GameManager manager;
    Value value;

    private void Start()
    {
        manager = GameManager.Instance;
    }


    public void StartProcess(Value value)
    {
        this.value = value;
        RuleOfHalfs();
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
                manager.Cells[i, (int)value.myIndex.y - 1].ChangeCellState(1);
            }
            else if (value.myIndex.y == 0)
            {
                manager.Cells[(int)value.myIndex.x - 1, i].ChangeCellState(1);
            }
        }
    }




    /* 
    Notes to developer:
    - all "manager.Values.Length" are temporary and will later need to be changed
    */
}
