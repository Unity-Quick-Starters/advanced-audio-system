using AdvancedAudioManager.Scripts.Audio.AudioData;
using AdvancedAudioManager.Scripts.Core;
using UnityEngine;

namespace AdvancedAudioManager.Scripts.Audio
{
    /// <summary>
    /// Event on which <c>AudioCue</c> components send a message to play SFX and music. <c>AudioManager</c> listens on these events, and actually plays the sound.
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Events/AudioCue Event Channel")]
    public class AudioCueEventChannelSO : DescriptionBaseSO
    {
        public readonly EventRequest<AudioCuePlayAction, AudioCueKey> AudioCuePlay = new();
        public readonly EventRequest<AudioCueKey> AudioCueStop = new();
        public readonly EventRequest<AudioCueKey> AudioCueFinish = new();

        public AudioCueKey RaisePlayEvent(AudioCueSO audioCue, AudioConfigurationSO audioConfiguration,
            Vector3 positionInSpace = default)
        {
            var audioCueKey = AudioCueKey.Invalid;

            if (AudioCuePlay != null)
            {
                audioCueKey = AudioCuePlay.RaiseEvent(
                    new AudioCuePlayAction(audioCue, audioConfiguration, positionInSpace)
                );
            }

            return audioCueKey;
        }
    }

    public struct AudioCuePlayAction
    {
        public AudioCueSO AudioCue { get; private set; }
        public AudioConfigurationSO AudioConfiguration { get; private set; }
        public Vector3 PositionInSpace { get; private set; }

        public AudioCuePlayAction(AudioCueSO audioCue, AudioConfigurationSO audioConfiguration,
            Vector3 positionInSpace)
        {
            AudioCue = audioCue;
            AudioConfiguration = audioConfiguration;
            PositionInSpace = positionInSpace;
        }
    }
}