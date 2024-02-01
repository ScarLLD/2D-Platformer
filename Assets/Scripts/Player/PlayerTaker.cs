using UnityEngine;

[RequireComponent (typeof(PlayerHealth))]
[RequireComponent (typeof(PlayerScore))]

public class PlayerTaker : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerScore _playerScore;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerScore = GetComponent<PlayerScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject item = collision.gameObject;

        if (item.TryGetComponent<Coin>(out Coin coin))
        {
            _playerScore.IncreaseScore();
            Destroy(item);
        }
        else if (item.TryGetComponent<Medicine>(out Medicine medicine))
        {
            _playerHealth.TakeHealth(medicine.GetHealthCount);
            Destroy(item);
        }        
    }
}
