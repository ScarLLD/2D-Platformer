using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private float _score;
    [SerializeField] private ScoreDisplay _scoreDisplay;

    public void IncreaseScore()
    {
        _score++;

        _scoreDisplay.DisplayScore(_score);
    }

    public float GetScore => _score;
}
