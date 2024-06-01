using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridBound
{
    public int left;
    public int right;

    public List<int> fillValues;

    public GridBound(int A, int B)
    {
        left = A;
        right = B;
        fillValues = null;
    }

    public GridBound(int A, int B, List<int> list)
    {
        left = A;
        right = B;
        fillValues = list;
    }

    public void Pinch(int num)
    {
        left += num;
        right -= num;
    }

    public void Pinch(GridBound nums)
    {
        left += nums.left;
        right -= nums.right;
    }
}
