using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private float HealthCount;

    public float GetHealthCount => HealthCount;
}
