using Com.JoeYao.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LineRotateTest:MonoBehaviour
{
    [SerializeField]
    public Vector2 _v;

    [SerializeField]
    public float _rotDeg;

    [SerializeField]
    public Vector2 _rltV;

    public void Awake()
    {

    }

    public void Update()
    {
        _rltV = Math2d.Rotate(_v, _rotDeg);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(Vector3.zero, new Vector3(_v.x, 0, _v.y));
        Gizmos.DrawLine(Vector3.zero, new Vector3(_rltV.x, 0, _rltV.y));
    }
}