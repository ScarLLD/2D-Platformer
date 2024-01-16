using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _moveX;
    private float _forceMultiple = 1000f;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //_rigidBody.AddForce(Vector2.up * _jumpForce * _forceMultiple);
            _rigidBody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        _moveX = Input.GetAxis("Horizontal");
        _rigidBody.MovePosition(_rigidBody.position + Vector2.right * _moveX * _speed * Time.deltaTime);

        
    }
}
