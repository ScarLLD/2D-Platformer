using UnityEngine.UI;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Slider))]

public class SmoothHealthBarSlider : HealthBarSlider
{
    [SerializeField] private float _timeMoveSlider;

    private Coroutine _changeSliderCoroutine;
    private float _currentHealthPercentage;

    public override void OnAmountChanged()
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

            if (_slider.value == _currentHealthPercentage)
                StopCoroutine(_changeSliderCoroutine);

            yield return null;
        }
    }
}
