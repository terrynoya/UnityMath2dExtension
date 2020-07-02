using Com.JoeYao.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CircleLineTest : MonoBehaviour
{
    [SerializeField]
    private float _radius = 10;
    [SerializeField]
    private Transform _circlePosTrans;
    [SerializeField]
    private Transform _lineStartTrans;
    [SerializeField]
    private Transform _lineEndTrans;

    [SerializeField]
    private Transform _interTrans0;
    [SerializeField]
    private Transform _interTrans1;

    private Vector2 _intersect0;
    private Vector2 _intersect1;

    public void Awake()
    {

    }

    public void Update()
    {
        Vector2 lineStart = Helper.GetVector2(_lineStartTrans);
        Vector2 lineEnd = Helper.GetVector2(_lineEndTrans);

        Vector2 circlePos = Helper.GetVector2(_circlePosTrans);
        //float r = _radius;

        //float h = circlePos.x;
        //float k = circlePos.y;

        //float x0 = lineStart.x;
        //float y0 = lineStart.y;

        //float x1 = lineEnd.x;
        //float y1 = lineEnd.y;

        //float dx = x1 - x0;
        //float dy = y1 - y0;

        //float x0h = x0 - h;
        //float y0k = y0 - k;
        //float a = dx * dx + dy * dy;
        //float b = 2f*dx*x0h+ 2*dy * y0k;

        //float c = x0h * x0h + y0k * y0k - r * r;

        //float diterm = b * b - 4 * a * c;
        //float sqrtDiterm = Mathf.Sqrt(diterm);

        //if (diterm > 0)
        //{
        //    float t0 = (-b + sqrtDiterm) /(2*a);
        //    float t1 = (-b - sqrtDiterm) / (2 * a);

        //    _intersect0 = GetPoint(lineStart,lineEnd,t0);
        //    _intersect1 = GetPoint(lineStart, lineEnd, t1);

        //    _interTrans0.position = _intersect0;
        //    _interTrans1.position = _intersect1;
        //}


        Vector2 r0;
        Vector2 r1;

        int rootCount = Math2d.LineCircleCollision(lineStart, lineEnd, circlePos, _radius,out r0,out r1);

        if (rootCount > 0)
        {
            _interTrans0.position = r0;
            _interTrans1.position = r1;
        }
    }

    private Vector2 GetPoint(Vector2 start,Vector2 end, float percent)
    {
        Vector2 diff = end - start;
        Vector2 rlt = diff * percent +start;
        return rlt;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_circlePosTrans.position, _radius);
        Gizmos.DrawLine(_lineStartTrans.position, _lineEndTrans.position);
    }
}