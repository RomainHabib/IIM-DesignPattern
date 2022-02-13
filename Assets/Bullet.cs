using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        return this;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + (Direction.normalized * Time.fixedDeltaTime * _speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        var v = other.GetComponentInParent<PlayerEntity>();
        v?.Damage(Power);
        Destroy(gameObject);
    }


}
