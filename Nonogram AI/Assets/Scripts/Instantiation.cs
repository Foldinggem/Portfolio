using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject CellPrefab;
    public Transform GridPos;
    public float Dimentions;
    float spacingMultiplier = 1.1f;

    GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
    }

    public void Instantiate()
    {
        // Used because position is determined by an external Transform
        Vector3 posModifier = Vector2.zero;
        float spacing = CalculateSpacing();
        float cellWidth = spacing / 1.1f;

        // Loop numbers set manually
        for (int i = 0; i < Math.Sqrt(manager.Cells.Length); i++)
        {
            posModifier.x = 0;

            for (int j = 0; j < Math.Sqrt(manager.Cells.Length); j++)
            {
                // Instantiate cell on transform + modifier
                GameObject newObj = Instantiate(CellPrefab, GridPos);
                newObj.transform.localScale = new Vector3(cellWidth, cellWidth, 1);
                newObj.transform.position += posModifier;

                // Create class object and store the object
                Cell newCell = new Cell(newObj);
                manager.Cells[j, i] = newCell;

                posModifier.x += spacing;
            }

            posModifier.y -= spacing;
        }
    }

    float CalculateSpacing()
    {
        float spacing = (float)Math.Sqrt(manager.Cells.Length) - 1;
        spacing *= spacingMultiplier;
        spacing += 1;
        return (Dimentions / spacing) * 1.1f;
    }
}
