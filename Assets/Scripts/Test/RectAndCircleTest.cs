using Com.JoeYao.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RectAndCircleTest:MonoBehaviour
{
    [SerializeField]
    private Rect _rect;
    [SerializeField]
    private Transform _circlePosTrans;
    [SerializeField]
    private float _radius = 5;
    [SerializeField]
    private Transform _nearestPosTrans;

    private Vector2 _nearestPos;

    private bool _isOverlap;


    public void Update()
    {
        Vector2 circlePos = GetV2(_circlePosTrans);
        //float rectX = _rect.x;
        //float rectY = _rect.y;
        //float rectWidth = _rect.width;
        //float rectHeight = _rect.height;
        //float circleX = circlePos.x;
        //float circleY = circlePos.y;
        //float nearestX = Mathf.Max(rectX, Mathf.Min(circleX, rectX + rectWidth));
        //float nearestY = Mathf.Max(rectY, Mathf.Min(circleY, rectY + rectHeight));

        //_nearestPos = new Vector2(nearestX, nearestY);

        _nearestPos = Math2d.GetNearestRectPoint(circlePos, _rect);
        _isOverlap = Math2d.IsCircleRectOverlap(circlePos, _radius, _rect);

        _nearestPosTrans.position = new Vector3(_nearestPos.x,0, _nearestPos.y);
    }

    private Vector2 GetV2(Transform t)
    {
        Vector3 p = t.position;
        return new Vector2(p.x, p.z);
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = _isOverlap ? Color.red : Color.white;
        Gizmos.DrawCube(new Vector3(_rect.center.x, 0, _rect.center.y), new Vector3(_rect.size.x, 0, _rect.size.y));
        Gizmos.DrawWireSphere(_circlePosTrans.position, _radius);
        Gizmos.DrawLine(_nearestPosTrans.position, _circlePosTrans.position);
    }
}
