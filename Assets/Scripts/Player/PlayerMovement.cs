using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundRadius;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private float _moveX;
    private float _jumpMultiple = 200f;
    private bool _isGround;
    private bool _facingRight = true;
    private string _isRun = "isRun";
    private string _inputX = "Horizontal";
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move(_moveX);
    }

    private void Update()
    {
        _moveX = Input.GetAxis(_inputX);

        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidBody.AddForce(Vector2.up * _jumpMultiple * _jumpForce);
        }

        if (_facingRight == false && _moveX > 0 || _facingRight == true && _moveX < 0)
        {
            Flip();
        }

        _animator.SetBool(_isRun, _moveX != 0);
    }

    private void Move(float direction)
    {
        var velocity = _rigidBody.velocity;
        velocity.x = _walkSpeed * direction;
        _rigidBody.velocity = velocity;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
