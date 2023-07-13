using System.Collections;
using AdvancedAudioManager.Scripts.Audio.AudioData;
using UnityEngine;

namespace AdvancedAudioManager.Scripts.Audio
{
	/// <summary>
	/// Simple implementation of a MonoBehaviour that is able to request a sound being played by the <c>AudioManager</c>.
	/// It fires an event on an <c>AudioCueEventSO</c> which acts as a channel, that the <c>AudioManager</c> will pick up and play.
	/// </summary>
	public class AudioCue : MonoBehaviour
	{
		[Header("Sound definition")]
		[SerializeField] private AudioCueSO _audioCue;
		[SerializeField] private bool _playOnStart;

		[Header("Configuration")]
		[SerializeField] private AudioCueEventChannelSO _audioCueEventChannel;
		[SerializeField] private AudioConfigurationSO _audioConfiguration;

		private AudioCueKey _controlKey = AudioCueKey.Invalid;

		private void Start()
		{
			if (_playOnStart)
				StartCoroutine(PlayDelayed());
		}

		private void OnDisable()
		{
			_playOnStart = false;
			StopAudioCue();
		}

		private IEnumerator PlayDelayed()
		{
			//The wait allows the AudioManager to be ready for play requests
			yield return new WaitForSeconds(1f);

			//This additional check prevents the AudioCue from playing if the object is disabled or the scene unloaded
			//This prevents playing a looping AudioCue which then would be never stopped
			if (_playOnStart)
				PlayAudioCue();
		}

		public void PlayAudioCue()
		{
			_controlKey = _audioCueEventChannel.RaisePlayEvent(_audioCue, _audioConfiguration, transform.position);
		}

		public void StopAudioCue()
		{
			if (_controlKey == AudioCueKey.Invalid) return;
		
			if (!_audioCueEventChannel.AudioCueStop.RaiseEvent(_controlKey))
			{
				_controlKey = AudioCueKey.Invalid;
			}
		}

		public void FinishAudioCue()
		{
			if (_controlKey == AudioCueKey.Invalid) return;
		
			if (!_audioCueEventChannel.AudioCueFinish.RaiseEvent(_controlKey))
			{
				_controlKey = AudioCueKey.Invalid;
			}
		}
	}
}
