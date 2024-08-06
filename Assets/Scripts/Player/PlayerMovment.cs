using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody _rb;
    private float _x;
    private float _z;
    private Vector3 _dir;
    private float _speed=10;
    private float _jumpForce = 5;
    private bool _isMoving;
    private void Awake()
    {
        _rb=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");
        _dir = transform.right * _x + transform.forward * _z;
    }
    private void LateUpdate()
    {
        Jump();
        Move();
    }
    private void Move()
    {
        _rb.MovePosition(transform.position + _dir * _speed * Time.deltaTime);
    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up*_jumpForce, ForceMode.Impulse);
        }
    }
    public bool IsMoving
    {
        get => _isMoving;
        set => _isMoving = value;
    }
}
