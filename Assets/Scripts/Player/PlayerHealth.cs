using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private HealthBarVisualizer _healthBar;

    private void Awake()
    {
        _healthBar.ChangeHealth(_currentHealth, _maxHealth);
    }

    public void GetDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;

        _healthBar.ChangeHealth(_currentHealth, _maxHealth);
    }

    public void GetHealth(float health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        _healthBar.ChangeHealth(_currentHealth, _maxHealth);
    }
}