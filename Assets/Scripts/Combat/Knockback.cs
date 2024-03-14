using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public Action OnKnockbackStart;
    public Action OnKnockbackEnd;

    [SerializeField] float _knockBackTime = .2f;

    Vector3 _hitDirection;
    float _knockbackThrust;

    Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        OnKnockbackStart += ApplyKnockbackThrust;
        OnKnockbackEnd += StopKnockRoutine;
    }

    void OnDisable()
    {
        OnKnockbackStart -= ApplyKnockbackThrust;
        OnKnockbackEnd -= StopKnockRoutine;
    }

    public void GetKnockedBack(Vector3 hitDirection, float knockbackThrust)
    {
        _hitDirection = hitDirection;
        _knockbackThrust = knockbackThrust;
        
        OnKnockbackStart?.Invoke();
    }

    void ApplyKnockbackThrust()
    {
        Vector3 forceVector = (transform.position - _hitDirection).normalized * _knockbackThrust * _rigidbody.mass;
        _rigidbody.AddForce(forceVector, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(_knockBackTime);
        OnKnockbackEnd?.Invoke();
    }

    void StopKnockRoutine()
    {
        _rigidbody.velocity = Vector2.zero;
    }
    
    
    
    
    
    
    
    
    
    
    
}
