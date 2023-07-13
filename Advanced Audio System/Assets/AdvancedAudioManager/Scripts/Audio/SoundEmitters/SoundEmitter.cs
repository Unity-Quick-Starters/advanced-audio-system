using System;
using System.Collections;
using AdvancedAudioManager.Scripts.Audio.AudioData;
using UnityEngine;
using UnityEngine.Events;

namespace AdvancedAudioManager.Scripts.Audio.SoundEmitters
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEmitter : MonoBehaviour
    {
        private AudioSource _audioSource;

        public event UnityAction<SoundEmitter> OnSoundFinishedPlaying;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
        }

        /// <summary>
        /// Instructs the AudioSource to play a single clip, with optional looping, in a position in 3D space.
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="settings"></param>
        /// <param name="hasToLoop"></param>
        /// <param name="position"></param>
        public void PlayAudioClip(AudioClip clip, AudioConfigurationSO settings, bool hasToLoop, Vector3 position = default)
        {
            _audioSource.clip = clip;
            settings.ApplyTo(_audioSource);
            _audioSource.transform.position = position;
            _audioSource.loop = hasToLoop;
            //Reset in case this AudioSource is being reused for a short SFX after being used for a long music track
            _audioSource.time = 0f; 
            _audioSource.Play();

            if (!hasToLoop)
            {
                StartCoroutine(FinishedPlaying(clip.length));
            }
        }

        public void FadeMusicIn(AudioClip musicClip, AudioConfigurationSO settings,
            float duration, float startTime = 0f)
        {
            PlayAudioClip(musicClip, settings, true);
            _audioSource.volume = 0f;

            //Start the clip at the same time the previous one left, if length allows
            //TODO: find a better way to sync fading songs
            if (startTime <= _audioSource.clip.length)
                _audioSource.time = startTime;

            //if you want you can use DOTween instead of the coroutine
            //_audioSource.DOFade(settings.Volume, duration); 
            StartCoroutine(Fade(settings.Volume, duration));
        }

        public float FadeMusicOut(float duration)
        {
            //if you want you can use DOTween instead of the coroutine
            //_audioSource.DOFade(0f, duration).onComplete += OnFadeOutComplete;
            StartCoroutine(Fade(0f, duration, OnFadeOutComplete));

            return _audioSource.time;
        }

        private void OnFadeOutComplete()
        {
            NotifyBeingDone();
        }

        /// <summary>
        /// Used to check which music track is being played.
        /// </summary>
        public AudioClip GetClip()
        {
            return _audioSource.clip;
        }

        /// <summary>
        /// Used when the game is unpaused, to pick up SFX from where they left.
        /// </summary>
        public void Resume()
        {
            _audioSource.Play();
        }

        /// <summary>
        /// Used when the game is paused.
        /// </summary>
        public void Pause()
        {
            _audioSource.Pause();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public void Finish()
        {
            if (!_audioSource.loop) return;
        
            _audioSource.loop = false;
            var timeRemaining = _audioSource.clip.length - _audioSource.time;
            StartCoroutine(FinishedPlaying(timeRemaining));
        }

        public bool IsPlaying()
        {
            return _audioSource.isPlaying;
        }

        public bool IsLooping()
        {
            return _audioSource.loop;
        }

        private IEnumerator FinishedPlaying(float clipLength)
        {
            yield return new WaitForSeconds(clipLength);

            NotifyBeingDone();
        }

        private void NotifyBeingDone()
        { 
            // The AudioManager will pick this up
            OnSoundFinishedPlaying?.Invoke(this);
        }
    
        private IEnumerator Fade(float targetVolume, float fadeDuration, Action callback = null)
        {
            var timer = 0.0f;
            var startVolume = _audioSource.volume;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, timer / fadeDuration);
                yield return null;
            }

            // Ensure the volume is set to the target value at the end of the fade
            _audioSource.volume = targetVolume;
        
            callback?.Invoke();
        }
    }
}