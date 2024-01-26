using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    public void GetDamage(float damage)
    {
        _health -= damage;
    }

    public void GetHealth(float health)
    {
        _health += health;
        Debug.Log(_health);
    }
}
