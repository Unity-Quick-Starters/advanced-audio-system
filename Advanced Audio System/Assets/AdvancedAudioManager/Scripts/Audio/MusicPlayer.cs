using AdvancedAudioManager.Scripts.Audio.AudioData;
using UnityEngine;

namespace AdvancedAudioManager.Scripts.Audio
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] private AudioCueSO _musicTrack;
        [SerializeField] private AudioCueEventChannelSO _playMusicOn;
        [SerializeField] private AudioConfigurationSO _audioConfig;

        private AudioCueKey _emitterKey;

        private void Start()
        {
            _emitterKey = _playMusicOn.RaisePlayEvent(_musicTrack, _audioConfig);
        }

        private void OnDisable()
        {
            if (_emitterKey != AudioCueKey.Invalid)
                _playMusicOn.AudioCueStop.RaiseEvent(_emitterKey);
        }
    }
}