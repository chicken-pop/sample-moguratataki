using UnityEngine;

namespace Utility
{
    public class DebugUtility
    {
        public static void Log<T>(T message)
        {
            Debug.Log(message);
        }

        public static void LogWarning<T>(T message)
        {
            Debug.LogWarning(message);
        }

        public static void LogError<T>(T message)
        {
            Debug.LogError(message);
        }
    }
}


