using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class HealthBarSlider : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private Slider _slider;
    private float _maxSliderValue = 1;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        SetDefaultValue();
    }

    private void OnEnable()
    {
        _playerHealth.AmountChanged += ChangeValue;
    }

    private void Start()
    {
        ChangeValue();
    }

    private void OnDisable()
    {
        _playerHealth.AmountChanged -= ChangeValue;
    }

    public void ChangeValue()
    {
        float currentHealthPercentage = _playerHealth.GetCurrentHealth / _playerHealth.GetMaxHealth;

        _slider.value = currentHealthPercentage;
    }

    private void SetDefaultValue()
    {
        _slider.maxValue = _maxSliderValue;
        _slider.minValue = 0;
    }
}
