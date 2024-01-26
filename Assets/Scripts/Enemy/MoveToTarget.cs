using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float _speedMultiple;

    private float _speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * _speedMultiple * Time.deltaTime);
    }

    public void Init(float speed)
    {
        this._speed = speed;
    }
}
