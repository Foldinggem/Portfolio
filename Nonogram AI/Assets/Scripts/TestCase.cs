using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;

        CreateValue(0, new List<int> { 5 });
        CreateValue(1, new List<int> { 1, 1, 1 });
        CreateValue(2, new List<int> { 1, 2 });
        CreateValue(3, new List<int> { 3, 1 });
        CreateValue(4, new List<int> { 4 });
    }

    void CreateValue(int index, List<int> values)
    {
        Value newValue = new Value(index);

        foreach (int value in values)
        {
            newValue.AddValue(value);
        }

        manager.Values[index] = newValue;
    }
}
