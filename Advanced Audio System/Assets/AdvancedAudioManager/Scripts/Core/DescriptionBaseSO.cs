using UnityEditor;
using UnityEngine;

namespace AdvancedAudioManager.Scripts.Core
{
    /// <summary>
    /// Base class for ScriptableObjects that need a public description field.
    /// </summary>
    public class DescriptionBaseSO : SerializableScriptableObject
    {
        [TextArea] public string description;
    }


    public class SerializableScriptableObject : ScriptableObject
    {
        [SerializeField, HideInInspector] private string _guid;
        public string Guid => _guid;

#if UNITY_EDITOR
        private void OnValidate()
        {
            var path = AssetDatabase.GetAssetPath(this);
            _guid = AssetDatabase.AssetPathToGUID(path);
        }
#endif
    }
}