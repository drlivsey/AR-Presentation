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

        public static bool IsPrefab(this GameObject gameObject)
        {
            return gameObject.scene.name is null && gameObject.scene.rootCount == 0;
        }

        public static float Sum(this Vector3 vector)
        {
            return vector.x + vector.y + vector.z;
        }
    }
}