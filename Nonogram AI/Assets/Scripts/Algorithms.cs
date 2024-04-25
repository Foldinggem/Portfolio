using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algorithms : MonoBehaviour
{
    public GameObject[] Cells;

    public int[] values;

    /* In order to identify all that I will need to find the value is go through the different cases:
       
        2 - unknown
        4 - unknown
        5 - values = # of cells in row
        1,3 - values + seperations = # of cells in row
        2,2 - values + seperations = # of cells in row
        0 - No unknowns
        

        Next Steps:
            Match succesfull cases from code to the visual
                - Make a cell class to change the corresponding cell when needed
                - Assign Cells to a class
                - Upon successful completion of an algorithm translate that to each cell for visual
    */

    private void Start()
    {
        Process();
    }

    public void Process()
    {
        if (Cells.Length == GetValueTotal() || GetValueTotal() == 0)
        {
            Debug.Log("Winnable");
        }
        else
        {
            Debug.Log("No");
        }
    }

    int GetValueTotal()
    {
        int Total = 0;
        for (int i = 0; i < values.Length; i++)
        {
            Total += values[i];
            if( i > 0 )
            {
                Total++;
            }
        }
        return Total;
    }
}
