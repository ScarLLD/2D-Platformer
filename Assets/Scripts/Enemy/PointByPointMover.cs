using UnityEngine;

public class PointByPointMover : MonoBehaviour
{
    [SerializeField] private Transform _placesParant;

    private float _speed;
    private EnemyMover _enemy;
    private Transform[] _places;
    private int _placeIndex;
    private bool _facingRight = true;

    private void Awake()
    {
        _places = new Transform[_placesParant.childCount];

        for (int i = 0; i < _placesParant.childCount; i++)
            _places[i] = _placesParant.GetChild(i);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _places[_placeIndex].position, _speed * Time.deltaTime);

        if (transform.position.x < _places[_placeIndex].position.x && _facingRight == false || transform.position.x > _places[_placeIndex].position.x && _facingRight == true)
        {
            Flip();
        }

        if (transform.position == _places[_placeIndex].position)
            ChangeNextPlaceIndex();
    }

    public void Init(EnemyMover enemy, float speed)
    {
        this._enemy = enemy;
        this._speed = speed;
    }

    private void ChangeNextPlaceIndex()
    {
        if (++_placeIndex == _places.Length)
            _placeIndex = 0;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}