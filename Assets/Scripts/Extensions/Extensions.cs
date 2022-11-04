using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ARPresentation.Extensions
{
    public static class Extensions
    {
        public static void Fill<T>(this T[] array, T value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
    }
}