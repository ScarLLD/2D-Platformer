using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] private float _speed;

    private PointByPointMover _pointByPointMover;
    private MoveToTarget _moveToTarget;

    public bool _facingRight = true;

    private void Awake()
    {        
        _pointByPointMover = gameObject.GetComponent<PointByPointMover>();
        _moveToTarget = gameObject.GetComponent<MoveToTarget>();
    }

    public void EnablePoinByPointMover()
    {
        _pointByPointMover.enabled = true;
        _moveToTarget.enabled = false;
    }

    public void EnableMoveToTarget()
    {
        _pointByPointMover.enabled = false;
        _moveToTarget.enabled = true;
    }

    public float GetSpeed()
    {
        return _speed;
    }
}
