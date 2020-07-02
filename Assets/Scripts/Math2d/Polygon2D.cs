using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Com.JoeYao.Math
{
    public class Polygon2D
    {
        private List<Vector2> _verts;

        public Polygon2D(Vector2[] verts)
        {
            _verts = new List<Vector2>();
            _verts.AddRange(verts);
        }

        public bool Contains(Vector2 point)
        {
            return false;
        }
    }
}
