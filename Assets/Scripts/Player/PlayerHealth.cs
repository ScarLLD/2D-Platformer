using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float GetCurrentHealth => _currentHealth;
    public float GetMaxHealth => _maxHealth;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public event Action AmountChanged;

    public void GetDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

        AmountChanged?.Invoke();
    }

    public void GetHealth(float health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        AmountChanged?.Invoke();
    }
}