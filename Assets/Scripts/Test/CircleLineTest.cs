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