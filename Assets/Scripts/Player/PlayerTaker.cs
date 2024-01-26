using UnityEngine;

public class PlayerTaker : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerScore _playerScore;

    private void Awake()
    {
        _playerHealth = gameObject.GetComponent<PlayerHealth>();
        _playerScore = gameObject.GetComponent<PlayerScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject item = collision.gameObject;

        if (item.TryGetComponent<Coin>(out Coin coin))
        {
            _playerScore.IncreaseScore();
        }
        else if (item.TryGetComponent<Medicine>(out Medicine medicine))
        {

            _playerHealth.GetHealth(medicine.HealthCount);
        }

        Destroy(item);
    }
}
