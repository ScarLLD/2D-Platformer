using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<Text>();
    }

    public void DisplayScore(float score)
    {
        _scoreText.text = score.ToString();
    }
}
