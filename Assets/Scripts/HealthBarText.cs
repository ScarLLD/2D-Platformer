using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class HealthBarText : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
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
        _text.SetText($"{_playerHealth.GetCurrentHealth} / {_playerHealth.GetMaxHealth}");
    }
}
