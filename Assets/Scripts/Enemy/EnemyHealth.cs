using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    public void TakeHealth(float health)
    {
        _health += health;
        Debug.Log(_health);
    }
}
