using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private float _maxPlayerDisctanse;
    [SerializeField] private float _maxAttackDisctanse;
    [SerializeField] private LayerMask _playerMask;

    private bool _isTargetClose = false;
    private RaycastHit2D _ray;
    public bool _facingRight = true;

    private void Update()
    {

        if (_facingRight == true)
        {
            _ray = Physics2D.Raycast(transform.position, transform.right, _maxPlayerDisctanse, _playerMask);
        }
        else
        {
            _ray = Physics2D.Raycast(transform.position, -transform.right, _maxPlayerDisctanse, _playerMask);
        }

        Debug.DrawLine(transform.position, _ray.point);

        if (_ray.distance <= _maxPlayerDisctanse && _ray.distance > 0)
        {
            gameObject.GetComponent<PointByPointMover>().enabled = false;

            Debug.Log(_ray.distance);

            Player player = _ray.collider.gameObject.GetComponent<Player>();

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);

            if (_ray.distance <= _maxAttackDisctanse && _ray.distance > 0)
            {
                if (_isTargetClose == false)
                {
                    StartCoroutine(Attack(player));
                    _isTargetClose = true;
                }
            }
        }
        else
        {
            StopAllCoroutines();

            _isTargetClose = false;

            gameObject.GetComponent<PointByPointMover>().enabled = true;
        }
    }

    private IEnumerator Attack(Player player)
    {
        bool isAttack = true;

        while (isAttack)
        {
            yield return new WaitForSeconds(_timeBetweenAttacks);

            player.GetDamage(_damage);
        }
    }

    public void GetDamage(float damage)
    {
        Debug.Log("Enemy attack");

        _health -= damage;
    }
}
