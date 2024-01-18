using UnityEngine;

public class PointByPointMover : MonoBehaviour
{
    [SerializeField] private Transform _placesParant;
    [SerializeField] private float _speed;

    private Transform[] _places;
    private int _placeIndex;

    private void Awake()
    {
        _places = new Transform[_placesParant.childCount];

        for (int i = 0; i < _placesParant.childCount; i++)
            _places[i] = _placesParant.GetChild(i);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _places[_placeIndex].position, _speed * Time.deltaTime);

        if (transform.position == _places[_placeIndex].position)
            ChangeNextPlaceIndex();
    }

    private void ChangeNextPlaceIndex()
    {
        if (++_placeIndex == _places.Length)
            _placeIndex = 0;
    }
}