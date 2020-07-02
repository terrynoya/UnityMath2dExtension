using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Helper
{
    public static Vector2 GetVector2(Transform t)
    {
        Vector3 p = t.position;
        return new Vector2(p.x, p.y);
    }
}
