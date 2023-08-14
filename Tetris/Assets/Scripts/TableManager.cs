using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] int _row; //High
    [SerializeField] int _column; //Width
    private GameObject[,] _tableDimention => new GameObject[_row, _column];
    [SerializeField] GameObject _pixelPrefab;
    private GameObject _pixel;

    private void Awake()
    {
        SpawnTable();
    }

    private void SpawnTable()
    {
        for (int f_row = 0; f_row < _row; f_row++)
        {
            for (int f_column = 0; f_column < _column; f_column++)
            {
                _pixel = Instantiate(_pixelPrefab, transform.position + new Vector3(f_row, f_column, 10), Quaternion.identity);
                if (f_column == (_column - 1) / 2 && f_row == _row -1)
                {
                    Debug.Log("encuentro el medio");
                    //middle this is the spawn zone
                    _pixel.GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else if (f_column == 0)
                {
                    //base of board
                    _pixel.GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else if (f_row == 0 || f_row == _row - 1 || f_column == _column - 1)
                {
                    //wall of board
                    _pixel.GetComponent<SpriteRenderer>().color = Color.gray;
                }
                _tableDimention[f_row, f_column] = _pixel;
            }
        }
    }
}
