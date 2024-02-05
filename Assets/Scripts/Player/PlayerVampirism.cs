using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerVampirism : MonoBehaviour
{
    [SerializeField] private float _vampirismDamage;
    [SerializeField] private float _vampirismMultiple;
    [SerializeField] private Transform _vampirismCheck;
    [SerializeField] private LayerMask _vampirismMask;
    [SerializeField] private float _vampirismRadius;
    [SerializeField] private int _maxTimer;

    private bool _isVampirism;
    private Collider2D[] _enemys;
    private Coroutine _vampirismCoroutine;
    private WaitForSeconds _timeBetwenVampirism = new WaitForSeconds(1f);
    private Health _player;

    private void Awake()
    {
        _player = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        _enemys = Physics2D.OverlapCircleAll(_vampirismCheck.position, _vampirismRadius, _vampirismMask);
    }

    public void ActivateVampirism()
    {
        if (_enemys.Length > 0 && _isVampirism == false)
        {
            _isVampirism = true;

            if (_enemys[0].gameObject.TryGetComponent<Health>(out Health enemy))
            {
                _vampirismCoroutine = StartCoroutine(Vampirism(enemy));
            }
        }
    }

    private IEnumerator Vampirism(Health enemy)
    {
        int timer = 0;

        while (timer < _maxTimer && _enemys.Length > 0)
        {
            timer++;

            if (enemy.CurrentHealth > 0)
            {
                enemy.TakeDamage(_vampirismDamage);
                _player.TakeHealth(_vampirismDamage * _vampirismMultiple);
            }

            Debug.Log($"Vampirism Active - {timer}s ");

            yield return _timeBetwenVampirism;
        }

        StopCoroutine(_vampirismCoroutine);

        Debug.Log($"Vampirism stoped");

        _isVampirism = false;
    }
}
