using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCountDisplay _coinDisplayObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            CoinCountDisplay.Instance.IncreaseScore();
            Destroy(gameObject);
        }
    }
}
