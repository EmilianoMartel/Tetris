using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Piece : MonoBehaviour
{
    public enum ColorSelector
    {
        Red,
        Cyan,
        Green,
        Yellow
    }

    //Color selection
    [SerializeField] List<PixelPiece> _pixelList = new List<PixelPiece>();
    [SerializeField] private ColorSelector _color;
    private Color _tempColor;

    //Movement
    private Vector3 _direction = new Vector3();
    [SerializeField] private float _baseSpeed = 1f; //base speed of piece
    [SerializeField] private Player _player;

    private void Start()
    {
        MovementDown();
        ColorSelection();
        _player.movementEvent += SetDirectionValue;
        _player.rotationEvent += Rotation;
    }

    private void Update()
    {
        transform.position += _direction * _baseSpeed * Time.deltaTime;
    }

    private void Rotation()
    {
        // Get the current rotation
        Quaternion currentRotation = gameObject.transform.rotation;

        // Add 90 degrees rotation around the Z-axis
        Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles + new Vector3(0, 0, 90));

        // Apply the new rotation to the game object
        gameObject.transform.rotation = newRotation;
    }

    private void ColorSelection()
    {
        //Basic color selection by switch case
        switch (_color)
        {
            case ColorSelector.Red:
                _tempColor = Color.red;
                ColorInput();
                break;
            case ColorSelector.Cyan:
                _tempColor = Color.cyan;
                ColorInput();
                break;
            case ColorSelector.Green:
                _tempColor = Color.green;
                ColorInput();
                break;
            case ColorSelector.Yellow:
                _tempColor = Color.yellow;
                ColorInput();
                break;
        }
    }

    private void ColorInput()
    {
        for (int i = 0; i < _pixelList.Count; i++)
        {
            _pixelList[i].SelectedColor(_tempColor);
        }
    }

    private void MovementDown()
    {
        _direction = new Vector3(0, -1, 0);
    }

    private void SetDirectionValue(Vector2 direction)
    {
        if (direction.y > 0.5f)
        {
            direction.y = -0.5f;
        }
        else
        {
            direction.y = -1;
        }
        _direction = new Vector3(direction.x, direction.y, 0);
    }

    private void OnDestroy()
    {
        _player.movementEvent -= SetDirectionValue;
        _player.rotationEvent -= Rotation;
    }
}
