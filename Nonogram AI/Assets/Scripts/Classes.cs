using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    CellState state;
    GameObject thisCell;

    public Cell(GameObject thisCell)
    {
        state = CellState.None;
        this.thisCell = thisCell;
    }

    /*
        0 = None
        1 = Filled
        2 = Crossed
    */
    public void ChangeCellState(int stateNum)
    {
        switch(stateNum)
        {
            case 0:
                thisCell.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 1:
                thisCell.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.5f);
                break;
            case 2:
                thisCell.GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
    }

    enum CellState
    {
        None,
        Filled,
        Crossed
    }
}
