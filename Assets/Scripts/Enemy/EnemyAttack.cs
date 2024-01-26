using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBetweenAttacks;

    private Coroutine _attackCoroutine;

    public void StartAttack(PlayerHealth player)
    {
        _attackCoroutine = StartCoroutine(Attack(player));
    }

    public void EndAttack()
    {
        StopCoroutine(_attackCoroutine);
    }

    private IEnumerator Attack(PlayerHealth player)
    {
        bool isAttack = true;

        while (isAttack)
        {
            yield return new WaitForSeconds(_timeBetweenAttacks);

            player.GetDamage(_damage);
        }
    }

    public Coroutine GetCoroutine()
    {
        return _attackCoroutine;
    }
}
