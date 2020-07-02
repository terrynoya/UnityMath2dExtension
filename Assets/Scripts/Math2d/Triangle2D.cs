using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Com.JoeYao.Math
{
    public class Triangle2D
    {
        private Vector2 _v0;
        private Vector2 _v1;
        private Vector2 _v2;

        public Triangle2D(Vector2 v0, Vector2 v1, Vector2 v2)
        {
            _v0 = v0;
            _v1 = v1;
            _v2 = v2;
        }

        public Vector2 V0
        {
            get { return _v0; }
        }

        public Vector2 V1
        {
            get { return _v1; }
        }

        public Vector2 V2
        {
            get { return _v2; }
        }

        public bool Contains(Vector2 point)
        {
            float s0 = Math2d.Cross(_v1 - _v0, point - _v0);
            float s1 = Math2d.Cross(_v2 - _v1, point - _v1);
            float s2 = Math2d.Cross(_v0 - _v2, point - _v2);

            return (s0 > 0 && s1 > 0 && s2 > 0)|| (s0 < 0 && s1 < 0 && s2 < 0);
        }
    }
}
