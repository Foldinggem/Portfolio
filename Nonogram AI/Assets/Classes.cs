using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            cellSprite.transform.localScale = size * 0.95f;
            cellSprite.transform.position = position;
            cellSprite.GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,0.5f);
        }
    }


    public class Cell
    {
        private GameObject cellSprite;

        private float size;
        private Vector2 position;

        public Cell(float _size, Vector2 _position, GameObject _cellSprite)
        {
            size = _size;
            position = _position;
            cellSprite = _cellSprite;

            cellSprite.transform.localScale = new Vector2(size * 0.95f, size * 0.95f);
            cellSprite.transform.position = position;
            cellSprite.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
