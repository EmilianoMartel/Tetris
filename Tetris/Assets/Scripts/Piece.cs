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

    [SerializeField] List<SpriteRenderer> _spriteList = new List<SpriteRenderer>();
    [SerializeField] private ColorSelector _color;
    private Color _tempColor;

    private void Start()
    {
        ColorSelection();
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
        for (int i = 0; i < _spriteList.Count; i++)
        {
            _spriteList[i].color = _tempColor;
        }
    }

}
