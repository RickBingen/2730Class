using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color DefaultColor { get; private set; }

    [SerializeField] Color[] _colors;
    [SerializeField] SpriteRenderer _fillSpriteRenderer;

    public void SetDefaultColor(Color color)
    {
        DefaultColor = color;
        SetColor(color);
    }

    public void SetColor(Color color)
    {
        _fillSpriteRenderer.color = color;
    }

    public void SetRandomColor()
    {
        int randomNum = Random.Range(0, _colors.Length);
        DefaultColor = _colors[randomNum];
        _fillSpriteRenderer.color = DefaultColor;
    }
}
