using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array
{
    static public T ArrayRandomElement<T>(T[] arr)
    {
        int idx = UnityEngine.Random.Range(0, arr.Length - 1);
        return arr[idx];
    }

    static public int RandomNumberWithExcept(int min, int max, int[] except)
    {
        List<int> tmpArr = new List<int>();
        List<int> exceptArr = new List<int>();
        exceptArr.AddRange(except);
        for(int i = min; i <= max; i++)
        {
            if (exceptArr.Contains(i))
            {
                continue;
            }
            tmpArr.Add(i);
        }
        int randIdx = UnityEngine.Random.Range(0, tmpArr.Count);
        return tmpArr[randIdx];
    }
}
