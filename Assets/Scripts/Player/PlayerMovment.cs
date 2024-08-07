using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody _rb;
    private float _x;
    private float _z;
    private Vector3 _dir;
    private float _speed=10;
    [SerializeField]
    private float _jumpForce = 100;
    private bool _isRunning;
    [SerializeField]
    private Transform _groundChecker;
    public LayerMask layer;
    [SerializeField]
    private PlayerStats _stats;
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
        if (Input.GetKey(KeyCode.LeftShift) && _stats.Run)
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
