using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public event Action<float, float> AmountChanged;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

        AmountChanged?.Invoke(_currentHealth ,_maxHealth);
    }

    public void Heal(float health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        AmountChanged?.Invoke(_currentHealth, _maxHealth);
    }
}