using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MessageIndex
{
    public static int Index = 0;
}

namespace ARPresentation.Debuging
{
    

    public class EventsDebuger : MonoBehaviour
    {
        public void Print(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        public void Print(int message) 
        {
            UnityEngine.Debug.Log(message);
        }

        public void Print(object message)
        {
            UnityEngine.Debug.Log(message);
        }
    }
}