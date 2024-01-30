using UnityEngine;

public class HealthBarVisualizer : MonoBehaviour
{
    [SerializeField] private SmoothHealthBarSlider _smoothHealthBarSlider;
    [SerializeField] private HealthBarSlider _healthBarSlider;
    [SerializeField] private HealthBarText _healthBarText;

    public void ChangeHealth(float health, float maxHealth)
    {
        _healthBarText.ChangeHealthBar(health, maxHealth);
        _healthBarSlider.ChangeHealthBar(health, maxHealth);
        _smoothHealthBarSlider.ChangeHealthBar(health, maxHealth);
    }
}
