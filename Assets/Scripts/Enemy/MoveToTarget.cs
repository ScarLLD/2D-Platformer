using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float _speedMultiple;

    private float _speed;

    void Start()
    {
        _speed = gameObject.GetComponent<EnemyMover>().GetSpeed();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * _speedMultiple * Time.deltaTime);
    }
}
