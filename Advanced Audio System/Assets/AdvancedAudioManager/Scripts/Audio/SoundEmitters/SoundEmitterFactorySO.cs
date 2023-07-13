using AdvancedAudioManager.Scripts.Factory;
using UnityEngine;

namespace AdvancedAudioManager.Scripts.Audio.SoundEmitters
{
	[CreateAssetMenu(fileName = "NewSoundEmitterFactory", menuName = "Game/Factory/SoundEmitter Factory")]
	public class SoundEmitterFactorySO : FactorySO<SoundEmitter>
	{
		public SoundEmitter prefab;

		public override SoundEmitter Create()
		{
			return Instantiate(prefab);
		}
	}
}
