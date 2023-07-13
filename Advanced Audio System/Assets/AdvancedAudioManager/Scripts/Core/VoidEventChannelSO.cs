using UnityEngine;

namespace AdvancedAudioManager.Scripts.Core
{
    /// <summary>
    /// This class is used for Events that have no arguments (Example: Exit game event)
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Events/Void Event Channel")]
    public class VoidEventChannelSO : DescriptionBaseSO
    {
        public readonly EventRequest EventRequest = new();
    }
}