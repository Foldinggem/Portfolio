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


    public void RuleOfHalfs()   
    {
        int index = 0;

        // Loop through each value in a set of values and call functions for each
        foreach(int number in manager.tempVal.values)
        {
            GridBound sideValues = new GridBound();

            // Identify and add side values to this value
            for(int i = 0; i < manager.tempVal.values.Count; i++)
            {
                if(i < index)
                {
                    sideValues.left += manager.tempVal.values[i] + 1;
                }
                else if (i > index)
                {
                    sideValues.right += manager.tempVal.values[i] + 1;
                }
            }

            // If there are enough values to form determined spots call the solve function to get specific spots
            if (number + sideValues.left + sideValues.right > manager.tempVal.cells.Length / 2)
            {
                FillGrid(number, sideValues);
            }

            index++;
        }
    }

    public void FillGrid(int number, GridBound sideValues)
    {
        GridBound Barrier = new GridBound(0, manager.tempVal.cells.Length - 1);

        Barrier.Pinch(sideValues);

        int availableSpace = Barrier.right + 1 - Barrier.left;
        int extra = availableSpace - number;

        Barrier.Pinch(extra);

        for(int i = Barrier.left; i <= Barrier.right; i++)
        {
            manager.tempVal.cells[i].ChangeCellState(1);
        }
    }
}
