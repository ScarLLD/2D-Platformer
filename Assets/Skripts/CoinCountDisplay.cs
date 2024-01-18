using UnityEngine;
using UnityEngine.UI;

public class CoinCountDisplay : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public static int _score = 0;

    public void Update()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
