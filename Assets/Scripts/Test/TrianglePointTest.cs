using Com.JoeYao.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TrianglePointTest:MonoBehaviour
{
    [SerializeField]
    private Transform _t0;
    [SerializeField]
    private Transform _t1;
    [SerializeField]
    private Transform _t2;
    [SerializeField]
    private Transform _p;

    private Triangle2D _triangle;

    public void Awake()
    {
        _triangle = new Triangle2D(Helper.GetVector2(_t0), Helper.GetVector2(_t1), Helper.GetVector2(_t2));
    }

    public void Update()
    {
        bool rlt = _triangle.Contains(Helper.GetVector2(_p));
        Debug.Log(rlt);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(_t0.position, _t1.position);
        Gizmos.DrawLine(_t1.position, _t2.position);
        Gizmos.DrawLine(_t2.position, _t0.position);
    }
}
