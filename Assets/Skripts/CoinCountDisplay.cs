using UnityEngine;
using UnityEngine.UI;

public class CoinCountDisplay : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public static CoinCountDisplay Instance { get; set; }

    private int _score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseScore()
    {
        _score += 1;
        _scoreText.text = "Score: " + _score.ToString();
    }
}
