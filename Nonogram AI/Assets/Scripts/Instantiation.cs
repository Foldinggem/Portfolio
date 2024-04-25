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

        Vector3 posModifier = Vector2.zero;

        for (int i = 0; i < 5; i++)
        {
            posModifier.x = 0;

            for (int j = 0; j < 5; j++)
            {
                GameObject newObj = Instantiate(CellPrefab, GridPos);
                newObj.transform.position += posModifier;

                Cell newCell = new Cell(newObj);
                manager.Cells[j,i] = newCell;

                posModifier.x += 1.2f;
            }

            posModifier.y -= 1.2f;
        }
    }
}
