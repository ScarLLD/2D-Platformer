using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] public TMP_Text _text;
    [SerializeField] public Slider _firstSlider;
    [SerializeField] public Slider _SecondtSlider;

    private void Awake()
    {
        SetDefaultSliderValue(_firstSlider);
        SetDefaultSliderValue(_SecondtSlider);
    }

    private void Start()
    {
        ChangeHealthBarValue();
    }

    public void GetDamage(float damage)
    {
        _currentHealth -= damage;
        ChangeHealthBarValue();
    }

    public void GetHealth(float health)
    {
        _currentHealth += health;
        ChangeHealthBarValue();
    }

    private void ChangeHealthBarValue()
    {
        _text.SetText($"{_currentHealth} / {_maxHealth}");
        _firstSlider.value = _currentHealth;

        float healthStorage = _SecondtSlider.value;
        _SecondtSlider.value = Mathf.MoveTowards(healthStorage, _currentHealth, 1f) ;
    }

    private void SetDefaultSliderValue(Slider slider)
    {
        slider.maxValue = _maxHealth;
        slider.minValue = 0f;


    }
}
