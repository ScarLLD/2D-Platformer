using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundRadius;
    [SerializeField] private float _maxEnemyDisctanse;
    [SerializeField] private float _maxAttackDisctanse;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _enemyMask;

    private bool _isGround;
    private bool _facingRight = true;
    private bool _isTargetClose = false;
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

        _ray = Physics2D.Raycast(transform.position, transform.right * transform.localScale.x, _maxEnemyDisctanse, _enemyMask);

        if (_ray.collider)
        {
            if (_isTargetClose == false)
            {
                Enemy enemy = _ray.collider.gameObject.GetComponent<Enemy>();

                StartCoroutine(Attack(enemy));

                _isTargetClose = true;
            }
        }
        else
        {
            StopAllCoroutines();

            _isTargetClose = false;
        }
    }

    private IEnumerator Attack(Enemy enemy)
    {
        bool isAttack = true;

        while (isAttack)
        {
            enemy.GetDamage(_damage);

            yield return new WaitForSeconds(_timeBetweenAttacks);
        }
    }

    private void FixedUpdate()
    {
        _moveX = Input.GetAxis("Horizontal");
        _rigidBody.MovePosition(_rigidBody.position + Vector2.right * _moveX * _speed * Time.deltaTime);
    }

    public void GetDamage(float damage)
    {
        _health -= damage;
    }

    public void GetHealth(float _healthCount)
    {
        _health += _healthCount;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
