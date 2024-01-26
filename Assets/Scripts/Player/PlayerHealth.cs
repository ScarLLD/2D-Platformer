using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] public float _timeMoveSlider;
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

    private void Update()
    {
        _SecondtSlider.value = Mathf.MoveTowards(_SecondtSlider.value, _currentHealth, _timeMoveSlider);
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
    }

    private void SetDefaultSliderValue(Slider slider)
    {
        slider.maxValue = _maxHealth;
        slider.minValue = 0f;


    }
}