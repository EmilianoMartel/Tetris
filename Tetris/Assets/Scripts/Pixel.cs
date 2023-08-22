using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    public enum State
    {
        Empty,
        Wall,
        Base,
        Spawner,
        Occupied,
        Piece
    }

    public State state;
    [SerializeField] protected SpriteRenderer _spriteRenderer;

    private void Start()
    {
        SelectedState();
    }

    protected void SelectedState()
    {
        switch (state)
        {
            case State.Empty:
                _spriteRenderer.color = Color.black;
                break;
            case State.Base:
                _spriteRenderer.color = Color.grey;
                break;
            case State.Wall:
                _spriteRenderer.color = Color.grey;
                break;
            case State.Spawner:
                _spriteRenderer.color = Color.grey;
                break;
            case State.Piece:
                break;
        }
    }

    public void SelectedColor(Color colorSelected)
    {
        _spriteRenderer.color = colorSelected;
    }
}
