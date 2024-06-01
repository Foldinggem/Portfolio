using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public CellState state;
    GameObject thisCell;

    public Cell(GameObject thisCell)
    {
        state = CellState.None;
        this.thisCell = thisCell;
    }


    public void ChangeCellState(string stateName)
    {
        switch(stateName)
        {
            case "None":
                thisCell.GetComponent<SpriteRenderer>().color = Color.white;
                state = CellState.None;
                break;
            case "Filled":
                thisCell.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.5f);
                state = CellState.Filled;
                break;
            case "Crossed":
                thisCell.GetComponent<SpriteRenderer>().color = Color.red;
                state = CellState.Crossed;
                break;
            case null:
                break;
        }
    }

    public enum CellState
    {
        None,
        Filled,
        Crossed
    }
}