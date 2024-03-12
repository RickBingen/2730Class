using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] float _yLandVelocityCheck = -10f;

    Vector2 _velocityBeforePhysicsUpdate;
    Rigidbody2D _rigidbody;
    CinemachineImpulseSource _impulseSource;


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void FixedUpdate()
    {
        _velocityBeforePhysicsUpdate = _rigidbody.velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(_velocityBeforePhysicsUpdate.y);
        if (_velocityBeforePhysicsUpdate.y < _yLandVelocityCheck)
        {
            _impulseSource.GenerateImpulse();
        }
    }
}
