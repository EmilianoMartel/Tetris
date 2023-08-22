using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Pixel _spawnPoint;
    public Piece piece;
    [SerializeField] private List<Piece> _pieceList;

    private void Start()
    {
        PreparedPiece();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnPiece();
        }
    }

    public void SpawnerPoint(Pixel pixel)
    {
        _spawnPoint = pixel;
    }

    private void SpawnPiece()
    {
        Instantiate(piece,_spawnPoint.transform.position,Quaternion.identity);
    }

    private void PreparedPiece()
    {
        for (int i = 0; i < _pieceList.Count; i++)
        {
            Instantiate(_pieceList[i],_spawnPoint.transform.position,Quaternion.identity);
            //_pieceList[i].transform.parent = transform;
        }
    }
}