using System;
using Godot;

namespace ShengChao.Codes.Core.Util;

public class RandomUtil
{
    public static Vector2 insidenCircle()
    {
        var theta = new Random().Next(0, 360);
        var k = new Random().NextDouble();
        var r = Math.Sqrt(k);
        var x = r * Math.Sin(theta);
        var y = r * Math.Cos(theta);
        return new Vector2((float)x, (float)y);
    }

}