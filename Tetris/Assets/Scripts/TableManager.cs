using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    [SerializeField] int _row;
    [SerializeField] int _column;
    private GameObject[,] _tableDimention => new GameObject[_row,_column];
    [SerializeField] GameObject _pixelPrefab;


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
                _tableDimention[f_row, f_column] = Instantiate(_pixelPrefab, transform.position + new Vector3(f_row, f_column, 10), Quaternion.identity);
            }
        }
    }


}
