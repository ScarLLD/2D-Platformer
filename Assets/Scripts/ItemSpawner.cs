using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform _placesParant;
    [SerializeField] private GameObject _itemPrefab;

    private List<Transform> _places;

    private void Awake()
    {
        _places = new List<Transform>(_placesParant.childCount);

        for (int i = 0; i < _placesParant.childCount; i++)
            _places.Add(_placesParant.GetChild(i));
    }

    private void Start()
    {
        int randomItemsCount = Random.Range(0, _places.Count);

        for (int i = 0; i < randomItemsCount || i < _places.Count; i++)
        {
            int randomItemIndex = Random.Range(0, _places.Count);

            Instantiate(_itemPrefab, _places[randomItemIndex].transform.position, Quaternion.identity);
            _places.Remove(_places[randomItemIndex]);
        }
    }
}
