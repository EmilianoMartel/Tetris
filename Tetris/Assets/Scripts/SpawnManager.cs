using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Pixel _spawnPoint;
    public Piece piece;
    private List<Piece> _pieceList = new List<Piece>();
    [SerializeField] private List<Piece> _pieceListPrefab;

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
        for (int i = 0; i < _pieceListPrefab.Count; i++)
        {
            piece = Instantiate(_pieceListPrefab[i], _spawnPoint.transform.position, Quaternion.identity);
            piece.transform.parent = transform;
            _pieceList.Add(piece);
            piece.gameObject.SetActive(false);
        }
    }
}