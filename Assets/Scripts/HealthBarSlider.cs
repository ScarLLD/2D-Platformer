using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]

public class HealthBarSlider : MonoBehaviour
{
    [SerializeField] protected PlayerHealth _playerHealth;

    protected Slider _slider;
    protected float _maxSliderValue = 1;

    protected void Awake()
    {
        _slider = GetComponent<Slider>();

        SetDefaultValue();
    }

    protected void OnEnable()
    {
        _playerHealth.AmountChanged += OnAmountChanged;
    }

    protected void Start()
    {
        OnAmountChanged();
    }

    protected void OnDisable()
    {
        _playerHealth.AmountChanged -= OnAmountChanged;
    }

    public virtual void OnAmountChanged()
    {
        float currentHealthPercentage = _playerHealth.GetCurrentHealth / _playerHealth.GetMaxHealth;

        _slider.value = currentHealthPercentage;
    }

    protected void SetDefaultValue()
    {
        _slider.maxValue = _maxSliderValue;
        _slider.minValue = 0;
    }
}
