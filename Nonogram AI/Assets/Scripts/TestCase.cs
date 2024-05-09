using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;

        CreateRowValue(3, new List<int> { 4 });
        CreateColValue(3, new List<int> { 4 });
    }

    void CreateRowValue(int index, List<int> values)
    {
        Value newValue = new Value(new Vector2(0, index));

        foreach (int value in values)
        {
            newValue.AddValue(value);
        }

        manager.Values[0, index] = newValue;
    }

    void CreateColValue(int index, List<int> values)
    {
        Value newValue = new Value(new Vector2(index, 0));

        foreach (int value in values)
        {
            newValue.AddValue(value);
        }

        manager.Values[index, 0] = newValue;
    }
}
