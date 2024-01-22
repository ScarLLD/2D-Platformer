using System.Collections;
using System.Collections.Generic;
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

    private bool _facingRight = true;
    private RaycastHit2D _ray;

    private void Update()
    {
        if (_facingRight == false && _moveX > 0)
        {
            Flip();
        }
        else if (_facingRight == true && _moveX < 0)
        {
            Flip();
        }

        if (_facingRight == true)
        {
            _ray = Physics2D.Raycast(transform.position, transform.right, _maxPlayerDisctanse, _playerMask);
        }
        else
        {
            _ray = Physics2D.Raycast(transform.position, -transform.right, _maxPlayerDisctanse, _playerMask);
        }

        Debug.DrawLine(transform.position, _ray.point);

        if (_ray.distance <= _maxAttackDisctanse && _ray.distance > 0)
        {
            Enemy enemy = _ray.collider.gameObject.GetComponent<Enemy>();

            enemy.GetDamage(_damage);

            Debug.Log("attack");
            Debug.Log(_ray.distance);
        }
    }

    public void GetDamage(float damage)
    {

    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
