using System;
using UnityEngine;
using Cinemachine;

public class Gun : MonoBehaviour
{
    public static Action OnShoot;
    public Transform BulletSpawnPoint => _bulletSpawnPoint;

    [SerializeField] Transform _bulletSpawnPoint;
    [SerializeField] Bullet _bulletPrefab;

    static readonly int FIRE_HASH = Animator.StringToHash("Fire");
    Vector2 _mousePos;

    CinemachineImpulseSource _impulseSource;
    Animator _animator;


    void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Shoot();
        RotateGun();
    }

    void OnEnable()
    {
        OnShoot += ShootProjectile;
        OnShoot += FireAnimation;
        OnShoot += ScreenShake;
    }

    void OnDisable()
    {
        OnShoot -= ShootProjectile;
        OnShoot -= FireAnimation;
        OnShoot -= ScreenShake;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            OnShoot?.Invoke();
        }
    }

    void ShootProjectile()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
        newBullet.Init(_bulletSpawnPoint.position, _mousePos);
    }

    void FireAnimation()
    {
        _animator.Play(FIRE_HASH, 0,0f);
    }

    void ScreenShake()
    {
        _impulseSource.GenerateImpulse();
    }

    void RotateGun()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = PlayerController.Instance.transform.InverseTransformPoint(_mousePos);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation  = Quaternion.Euler(0,0,angle);
    }
}
