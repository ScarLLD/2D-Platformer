using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBetweenAttacks;

    private Coroutine _attackCoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeBetweenAttacks);
    }

    public void StartAttack(PlayerHealth player)
    {
        _attackCoroutine = StartCoroutine(Attack(player));
    }

    public void EndAttack()
    {
        if (_attackCoroutine != null)
            StopCoroutine(_attackCoroutine);
    }

    private IEnumerator Attack(PlayerHealth player)
    {
        bool isAttack = true;

        while (isAttack)
        {
            yield return _waitForSeconds;

            player.GetDamage(_damage);
        }
    }
}