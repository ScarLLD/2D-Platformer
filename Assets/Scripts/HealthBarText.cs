using TMPro;
using UnityEngine;

public class HealthBarText : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void ChangeHealthBar(float health, float maxHealth)
    {
        _text.SetText($"{health} / {maxHealth}");
    }
}
