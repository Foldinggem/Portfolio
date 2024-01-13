using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InstantiateCells : MonoBehaviour
{
    int tempCellCount = 10;

    // Canvas for cells to be instantiated in
    public GameObject canvas;
    public GameObject cell;

    public static Classes.NumCell[,] NumCells;
    public static Classes.Cell[,] Cells;
    
    private void Awake()
    {
        NumCells = new Classes.NumCell[tempCellCount + 1 , tempCellCount + 1];
        Cells = new Classes.Cell[tempCellCount , tempCellCount];

        // Get top left corner of canvas
        Vector2 originPoint = canvas.transform.position;
        originPoint -= new Vector2(canvas.transform.localScale.x/2, -canvas.transform.localScale.y/2);

        float avg = canvas.transform.localScale.x / (tempCellCount + 3);
        float cellSize = avg;
        float numCellSize = avg * 3;

        Vector2 location = originPoint + new Vector2(cellSize / 2 + (2 * cellSize), -numCellSize / 2);

        for (int i = 1; i < tempCellCount + 1; i++)
        {
            location.x += cellSize;
            GameObject newCell = Instantiate(cell);
            Classes.NumCell newNumCell = new Classes.NumCell(new Vector2(cellSize, numCellSize), location, newCell);
            NumCells[i,0] = newNumCell;
        }

        location = originPoint + new Vector2(0, -numCellSize + (cellSize/2));

        for (int i = 1; i < tempCellCount + 1; i++)
        {
            location.y -= cellSize;
            location.x = originPoint.x + (numCellSize / 2);
            GameObject newNumCell = Instantiate(cell);
            Classes.NumCell newNumCellClass = new Classes.NumCell(new Vector2(numCellSize, cellSize), location, newNumCell);
            NumCells[0, i] = newNumCellClass;
            location.x += cellSize;
            for (int j = 0; j < tempCellCount; j++)
            {
                location.x += cellSize;
                GameObject newCell = Instantiate(cell);
                Classes.Cell newCellClass = new Classes.Cell(cellSize, location, newCell);
                Cells[j,i-1] = newCellClass;
            }
        }
    }
}
