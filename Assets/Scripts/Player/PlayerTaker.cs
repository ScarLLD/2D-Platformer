using UnityEngine;

[RequireComponent (typeof(Health))]
[RequireComponent (typeof(PlayerScore))]

public class PlayerTaker : MonoBehaviour
{
    private Health _playerHealth;
    private PlayerScore _playerScore;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
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
            _playerHealth.Heal(medicine.GetHealthCount);
            Destroy(item);
        }        
    }
}
