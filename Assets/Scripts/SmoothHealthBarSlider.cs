using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Slider))]

public class SmoothHealthBarSlider : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _timeMoveSlider;

    private Slider _slider;
    private Coroutine _changeSliderCoroutine;
    private float _maxSliderValue = 1;
    private float _currentHealthPercentage;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        SetDefaultSliderValue();
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
        if (_changeSliderCoroutine != null)
        {
            StopCoroutine(_changeSliderCoroutine);
        }

        _changeSliderCoroutine = StartCoroutine(ChangeSlider(_playerHealth.GetCurrentHealth, _playerHealth.GetMaxHealth));
    }

    private IEnumerator ChangeSlider(float currentHealth, float maxHealth)
    {
        bool isChanging = true;
        _currentHealthPercentage = currentHealth / maxHealth;

        while (isChanging)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _currentHealthPercentage, _timeMoveSlider * Time.deltaTime);

            yield return null;
        }
    }

    private void SetDefaultSliderValue()
    {
        _slider.maxValue = _maxSliderValue;
        _slider.minValue = 0;
    }
}
