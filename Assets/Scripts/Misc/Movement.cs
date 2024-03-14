using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;

    float _moveX;
    bool _canMove = true;

    Rigidbody2D _rigidbody;
    Knockback _knockback;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _knockback = GetComponent<Knockback>();
    }

    void OnEnable()
    {
        _knockback.OnKnockbackStart += CanMoveFalse;
        _knockback.OnKnockbackEnd += CanMoveTrue;
    }

    void OnDisable()
    {
        _knockback.OnKnockbackStart -= CanMoveFalse;
        _knockback.OnKnockbackEnd -= CanMoveTrue;
    }

    void FixedUpdate()
    {
        Move();
    }

    void CanMoveTrue()
    {
        _canMove = true;
    }

    void CanMoveFalse()
    {
        _canMove = false;
    }

    public void SetCurrentDirection(float currentDirection)
    {
        _moveX = currentDirection;
    }

    void Move()
    {
        if (!_canMove) return;
        
        Vector2 movement = new Vector2(_moveX * _moveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = movement;
    }
    
    
    
    
    
    
}
