using UnityEngine.UI;
using UnityEngine;

public class HealthBarSlider : MonoBehaviour
{
    private Slider _slider;

    private float _maxSliderValue = 1;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        SetDefaultSliderValue();
    }

    public void ChangeHealthBar(float health, float maxHealth)
    {
        float currentHealthPercentage = health / maxHealth;

        _slider.value = currentHealthPercentage;
    }

    private void SetDefaultSliderValue()
    {
        _slider.maxValue = _maxSliderValue;
        _slider.minValue = 0;
    }
}
