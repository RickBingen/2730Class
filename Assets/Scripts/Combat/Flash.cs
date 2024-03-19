using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] Material _defaultMaterial;
    [SerializeField] Material _whiteFlashMaterial;
    [SerializeField] float _flashTime = 0.1f;

    SpriteRenderer[] _spriteRenderers;
    ColorChanger _colorChanger;

    void Awake()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _colorChanger = GetComponent<ColorChanger>();
    }

    public void StartFlash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.material = _whiteFlashMaterial;
            if(_colorChanger) _colorChanger.SetColor(Color.white);
        }

        yield return new WaitForSeconds(_flashTime);
        
        SetDefaultMaterial();
    }

    void SetDefaultMaterial()
    {
        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.material = _defaultMaterial;
            if(_colorChanger) _colorChanger.SetColor(_colorChanger.DefaultColor);
        }
    }
    
    
    
    
    
    
    
    
    
}
