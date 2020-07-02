using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Com.JoeYao.Math
{
    public class Math2d
    {
        public static float Project(Vector2 v1, Vector2 v2)
        {
            float dot = Vector2.Dot(v1, v2);
            return dot / v2.magnitude;
        }


        /// <summary>
        /// 点在线上的投影向量
        /// </summary>
        /// <param name="point"></param>
        /// <param name="lineStart"></param>
        /// <param name="lineEnd"></param>
        /// <returns></returns>
        public static Vector2 GetPointProjectVectorOnLine(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
        {
            Vector2 lineVec = lineEnd - lineStart;
            Vector2 pVec = point - lineStart;
            float project = Project(pVec, lineVec);
            Vector2 lineDir = lineVec.normalized;
            Vector2 proVec = project * lineDir;

            return proVec;
        }

        /// <summary>
        /// 旋转向量
        /// </summary>
        /// <param name="v"></param>
        /// <param name="angleInDegree"></param>
        /// <returns></returns>
        public static Vector2 Rotate(Vector2 v,float angleInDegree)
        {
            float rad = Mathf.Deg2Rad * angleInDegree;
            float c = Mathf.Cos(rad);
            float s = Mathf.Sin(rad);
            return new Vector2(c * v.x + s * v.y, s * v.x + c * v.y);
        }

        /// <summary>
        /// 得到矩形和某点之间最近的点
        /// </summary>
        /// <param name="circleCenter"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static Vector2 GetNearestRectPoint(Vector2 externalPos,Rect rect)
        {
            float rectX = rect.x;
            float rectY = rect.y;
            float rectWidth = rect.width;
            float rectHeight = rect.height;
            float circleX = externalPos.x;
            float circleY = externalPos.y;
            float nearestX = Mathf.Max(rectX, Mathf.Min(circleX, rectX + rectWidth));
            float nearestY = Mathf.Max(rectY, Mathf.Min(circleY, rectY + rectHeight));

            return new Vector2(nearestX, nearestY);
        }

        public static bool IsCircleRectOverlap(Vector2 circleCenter,float radius,Rect rect)
        {
            Vector2 nearestPos = GetNearestRectPoint(circleCenter, rect);
            return IsPointInCircle(circleCenter, radius, nearestPos);
        }

        public static bool IsPointInCircle(Vector2 circleCenter, float radius, Vector2 pos)
        {
            Vector2 delta = pos - circleCenter;
            float dx = delta.x;
            float dy = delta.y;
            return dx * dx + dy * dy <= radius * radius;
        }

        private static Vector2 GetPoint(Vector2 start, Vector2 end, float percent)
        {
            Vector2 diff = end - start;
            Vector2 rlt = diff * percent + start;
            return rlt;
        }

        /// <summary>
        /// 直线和圆的交点
        /// </summary>
        /// <param name="lineStart"></param>
        /// <param name="lineEnd"></param>
        /// <param name="circlePos"></param>
        /// <param name="circleRadius"></param>
        /// <param name="r0">交点1</param>
        /// <param name="r1">交点2</param>
        /// <returns>交点个数</returns>
        public static int LineCircleCollision(Vector2 lineStart, Vector2 lineEnd,Vector2 circlePos, float circleRadius,out Vector2 r0,out Vector2 r1)
        {
            float r = circleRadius;

            float h = circlePos.x;
            float k = circlePos.y;

            float x0 = lineStart.x;
            float y0 = lineStart.y;

            float x1 = lineEnd.x;
            float y1 = lineEnd.y;

            float dx = x1 - x0;
            float dy = y1 - y0;

            float x0h = x0 - h;
            float y0k = y0 - k;
            float a = dx * dx + dy * dy;
            float b = 2f * dx * x0h + 2 * dy * y0k;

            float c = x0h * x0h + y0k * y0k - r * r;

            float diterm = b * b - 4 * a * c;
            float sqrtDiterm = Mathf.Sqrt(diterm);

            float t0 = (-b + sqrtDiterm) / (2 * a);
            float t1 = (-b - sqrtDiterm) / (2 * a);

            int rootCount = 0;

            if (diterm > 0)
            {
                r0 = GetPoint(lineStart, lineEnd, t0);
                r1 = GetPoint(lineStart, lineEnd, t1);
                rootCount = 2;
            }
            else if (Mathf.Approximately(diterm,0))
            {
                r0 = GetPoint(lineStart, lineEnd, t0);
                r1 = Vector2.zero;
                rootCount = 1;
            }
            else
            {
                r0 = Vector2.zero;
                r1 = Vector2.zero;
                rootCount = 0;
            }

            return rootCount;
        }
    }
}
