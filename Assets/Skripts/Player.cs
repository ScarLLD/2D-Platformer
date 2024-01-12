using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
        
    private Rigidbody2D _rigidBody;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        _rigidBody.MovePosition(_rigidBody.position + Vector2.right * moveX * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector2.up * 10f);
        }
    }
}
