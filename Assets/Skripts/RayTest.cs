using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    private RaycastHit2D _hitRay;

    void Start()
    {
    }

    void Update()
    {
        _hitRay = Physics2D.Raycast(transform.position, transform.right);
        Debug.DrawLine(transform.position, _hitRay.point);
    }
}
