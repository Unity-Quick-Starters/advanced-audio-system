using System.Collections.Generic;
using AdvancedAudioManager.Scripts.Audio.AudioData;

namespace AdvancedAudioManager.Scripts.Audio.SoundEmitters
{
    public class SoundEmitterVault
    {
        private int _nextUniqueKey;
        private readonly List<AudioCueKey> _emittersKey = new();
        private readonly List<SoundEmitter[]> _emittersList = new();

        public AudioCueKey GetKey(AudioCueSO cue)
        {
            return new AudioCueKey(_nextUniqueKey++, cue);
        }

        public void Add(AudioCueKey key, SoundEmitter[] emitter)
        {
            _emittersKey.Add(key);
            _emittersList.Add(emitter);
        }

        public AudioCueKey Add(AudioCueSO cue, SoundEmitter[] emitter)
        {
            var emitterKey = GetKey(cue);

            _emittersKey.Add(emitterKey);
            _emittersList.Add(emitter);

            return emitterKey;
        }

        public bool Get(AudioCueKey key, out SoundEmitter[] emitter)
        {
            var index = _emittersKey.FindIndex(x => x == key);

            if (index < 0)
            {
                emitter = null;
                return false;
            }

            emitter = _emittersList[index];
            return true;
        }

        public bool Remove(AudioCueKey key)
        {
            var index = _emittersKey.FindIndex(x => x == key);
            return RemoveAt(index);
        }

        private bool RemoveAt(int index)
        {
            if (index < 0)
            {
                return false;
            }

            _emittersKey.RemoveAt(index);
            _emittersList.RemoveAt(index);

            return true;
        }
    }
}