using UnityEngine;

[RequireComponent(typeof(PointByPointMover))]
[RequireComponent(typeof(MoveToTarget))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PointByPointMover _pointByPointMover;
    private MoveToTarget _moveToTarget;

    private void Awake()
    {
        _pointByPointMover = GetComponent<PointByPointMover>();
        _moveToTarget = GetComponent<MoveToTarget>();

        _pointByPointMover.Init(this, _speed);
        _moveToTarget.Init(_speed);
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
}
