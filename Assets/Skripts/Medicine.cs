using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private float _healthCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().GetHealth(_healthCount);
            Destroy(gameObject);
        }
    }
}
