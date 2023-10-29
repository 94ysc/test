using System;
using Godot;

namespace ShengChao.Codes.Core.Base;

public class NoiseRandom
{
    public static FastNoiseLite fastNoiseLite = new FastNoiseLite();
    public Vector2 _cellSize { get; set; }

    public double _width { get; set; }

    public double _height { get; set; }

    public NoiseRandom(Vector2 cellSize, double width, double height)
    {
        _cellSize = cellSize;
        _width = width;
        _height = height;
    }

    public NoiseRandom()
    {
    }

    static NoiseRandom()
    {
        GD.Randomize();
        fastNoiseLite.NoiseType = FastNoiseLite.NoiseTypeEnum.SimplexSmooth;
        fastNoiseLite.Seed = (int)GD.Randi();
        fastNoiseLite.FractalOctaves = 4;
    }

    public double getnx(double xValue)
    {
        if (_cellSize ==Vector2.Zero || _width == 0)
        {
            return 1;
        }

        xValue += xValue * _cellSize.X + (_cellSize.X / 2);
        return (2 * xValue) / _width - 1;
    }


    public double getny(double yValue)
    {
        if (_cellSize ==Vector2.Zero || _width == 0)
        {
            return 1;
        }

        yValue += yValue * _cellSize.Y + (_cellSize.Y / 2);
        return (2 * yValue) / _height - 1;
    }


    public double calDistance(double x, double y)
    {
        var nx = getnx(x);
        var ny = getny(y);
        if (nx == 1 && ny == 1)
        {
            return 1;
        }

        return Math.Min(1, (nx * nx + ny * ny) / Math.Sqrt(2));
    }


    public double getIslandNoise(float x, float y)
    {
        var noiseValue = (fastNoiseLite.GetNoise2D(x, y) + 1) / 2;
        var d = calDistance(x, y);
        if (d == 1)
        {
            return noiseValue;
        }
        noiseValue = (float)((noiseValue + (1 - d)) / 2);
        return noiseValue;
    }
}