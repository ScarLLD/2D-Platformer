using System.Collections.Generic;
using UnityEngine;

public class MedicineSpawner : MonoBehaviour
{
    [SerializeField] private Transform _placesParant;
    [SerializeField] private Medicine _medicinePrefab;

    private List<Transform> _places;

    private void Awake()
    {
        _places = new List<Transform>(_placesParant.childCount);

        for (int i = 0; i < _placesParant.childCount; i++)
            _places.Add(_placesParant.GetChild(i));
    }

    private void Start()
    {
        int randomCoinsCount = Random.Range(0, _places.Count);

        for (int i = 0; i < randomCoinsCount || i < _places.Count; i++)
        {
            int randomCoinIndex = Random.Range(0, _places.Count);

            Instantiate(_medicinePrefab, _places[randomCoinIndex].transform.position, Quaternion.identity);
            _places.Remove(_places[randomCoinIndex]);
        }
    }
}
