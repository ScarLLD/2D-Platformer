using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundRadius;
    [SerializeField] private float _maxEnemyDisctanse;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _enemyMask;

    private bool _isGround;
    private bool _facingRight = true;
    private float _moveX;
    private float _forceMultiple = 1000f;
    private string _isRun = "isRun";    
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private RaycastHit2D _ray;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce * _forceMultiple);
        }

        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);

        if (_facingRight == false && _moveX > 0)
        {
            Flip();
        }
        else if (_facingRight == true && _moveX < 0)
        {
            Flip();
        }

        if (_moveX == 0)
        {
            _animator.SetBool(_isRun, false);
        }
        else
        {
            _animator.SetBool(_isRun, true);
        }

        if (_facingRight == true)
            _ray = Physics2D.Raycast(transform.position, transform.right, _maxEnemyDisctanse, _enemyMask);
        else
            _ray = Physics2D.Raycast(transform.position, -transform.right, _maxEnemyDisctanse, _enemyMask);

        Debug.DrawLine(transform.position, _ray.point);
    }

    private void FixedUpdate()
    {
        _moveX = Input.GetAxis("Horizontal");
        _rigidBody.MovePosition(_rigidBody.position + Vector2.right * _moveX * _speed * Time.deltaTime);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
