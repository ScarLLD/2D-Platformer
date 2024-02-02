using UnityEngine;

[RequireComponent (typeof(EnemyAttack))]
[RequireComponent (typeof(EnemyMover))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxPlayerDisctanse;
    [SerializeField] private float _maxAttackDistanse;
    [SerializeField] private LayerMask _playerMask;

    private bool _isTargetClose = false;
    private EnemyAttack _enemyAttack;
    private EnemyMover _enemyMover;
    public RaycastHit2D _hit;

    private void Awake()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        _hit = Physics2D.Raycast(transform.position, transform.right * transform.localScale.x, _maxPlayerDisctanse, _playerMask);

        if (_hit.collider)
        {
            _enemyMover.EnableMoveToTarget();

            if (_hit.distance > 0 && _hit.distance <= _maxAttackDistanse && _isTargetClose == false)
            {
                _enemyAttack.StartAttack(_hit.collider.gameObject.GetComponent<Health>());

                _isTargetClose = true;
            }
        }
        else
        {
            _enemyAttack.EndAttack();

            _isTargetClose = false;

            _enemyMover.EnablePoinByPointMover();
        }
    }
}
