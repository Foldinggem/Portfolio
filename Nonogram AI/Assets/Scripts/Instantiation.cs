using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject CellPrefab;
    public Transform GridPos;

    GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
    }

    public void Instantiate()
    {
        // Used because position is determined by an external Transform
        Vector3 posModifier = Vector2.zero;

        // Loop numbers set manually
        for (int i = 0; i < 5; i++)
        {
            posModifier.x = 0;

            for (int j = 0; j < 5; j++)
            {
                // Instantiate cell on transform + modifier
                GameObject newObj = Instantiate(CellPrefab, GridPos);
                newObj.transform.position += posModifier;

                // Create class object and store the object
                Cell newCell = new Cell(newObj);
                manager.Cells[j, i] = newCell;

                posModifier.x += 1.2f;
            }

            posModifier.y -= 1.2f;
        }

        // Manually set case for the algorithm to solve
        Value newVal = new Value();
        newVal.AddValue(2);
        newVal.AddValue(2);
        manager.tempVal = newVal;
    }
}
