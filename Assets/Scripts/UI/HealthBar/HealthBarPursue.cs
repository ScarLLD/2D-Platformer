using UnityEngine;

public class HealthBarPursue : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = _target.position;
    }
}
