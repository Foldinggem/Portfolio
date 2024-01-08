using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour
{
    public class NumCell
    {
        private GameObject cellSprite;

        private Vector2 size;
        private Vector2 position;

        public NumCell(Vector2 _size, Vector2 _position, GameObject _cellSprite)
        {
            size = _size;
            position = _position;
            cellSprite = _cellSprite;

            cellSprite.transform.localScale = size
            cellSprite.transform.position = position;
        }
    }
}
