using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class SmoothHealthBarSlider : MonoBehaviour
{
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

    public void ChangeHealthBar(float currentHealth, float maxHealth)
    {
        if (_changeSliderCoroutine != null)
        {
            StopCoroutine(_changeSliderCoroutine);
        }

        _changeSliderCoroutine = StartCoroutine(ChangeSlider(currentHealth, maxHealth));
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
