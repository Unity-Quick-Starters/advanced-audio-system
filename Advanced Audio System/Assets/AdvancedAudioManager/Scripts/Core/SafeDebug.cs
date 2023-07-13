using UnityEngine;

namespace AdvancedAudioManager.Scripts.Core
{
    public static class SafeDebug
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public static void LogError(object message)
        {
#if UNITY_EDITOR
            Debug.LogError(message);
#endif
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public static void LogWarning(object message)
        {
#if UNITY_EDITOR
            Debug.LogError(message);
#endif
        }
    }
}