using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array
{
    static public T ArrayRandomElement<T>(T[] arr)
    {
        int idx = Random.Range(0, arr.Length - 1);
        return arr[idx];
    }
}
