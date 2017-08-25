using System.Collections.Generic;
using UnityEngine;

public static class Factory
{
    public static bool GenerateRandomMatrix { get; set; }
    private static List<GameObject> _squareList = new List<GameObject>();

    public static List<GameObject> GetSquareList()
    {
        return _squareList;
    }
}