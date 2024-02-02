using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBetweenAttacks;
    [SerializeField] private float _maxEnemyDisctanse;
    [SerializeField] private float _maxAttackDistanse;
    [SerializeField] private LayerMask _enemyMask;

    private bool _isTargetClose = false;
    private RaycastHit2D _hit;
    private Coroutine _attackCoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeBetweenAttacks);
    }

    private void Update()
    {
        _hit = Physics2D.Raycast(transform.position, transform.right * transform.localScale.x, _maxEnemyDisctanse, _enemyMask);

        if (_hit.collider)
        {
            if (_hit.distance > 0 && _hit.distance <= _maxAttackDistanse && _isTargetClose == false)
            {
                Health enemy = _hit.collider.gameObject.GetComponent<Health>();

                _attackCoroutine = StartCoroutine(Attack(enemy));

                _isTargetClose = true;
            }
        }
        else if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);

            _isTargetClose = false;
        }
    }

    private IEnumerator Attack(Health enemy)
    {
        bool isAttack = true;

        while (isAttack)
        {
            enemy.TakeDamage(_damage);

            yield return _waitForSeconds;
        }
    }
}
