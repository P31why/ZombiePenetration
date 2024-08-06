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
    [SerializeField]
    private float _jumpForce = 5;
    private bool _isRunning;
    [SerializeField]
    private Transform _groundChecker;
    public LayerMask layer;
    private void Awake()
    {
        _rb=GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            _x = Input.GetAxis("Horizontal");
            _z = Input.GetAxis("Vertical");
            _dir = transform.right * _x + transform.forward * _z;
        }
        
    }
    private void LateUpdate()
    {
        if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
        {
            Jump();
            Move();
        }
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rb.MovePosition(transform.position + _dir * _speed * 2 * Time.deltaTime);
            _isRunning = true;
        }
        else
        {
            _rb.MovePosition(transform.position + _dir * _speed * Time.deltaTime);
            _isRunning = false;
        }
    }
    private void Jump()
    {
        
            if (Physics.CheckSphere(_groundChecker.position, 0.1f,layer))
            {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }
    public bool IsRunning
    {
        get => _isRunning;
        set => _isRunning = value;
    }
}
