using AdvancedAudioManager.Scripts.Factory;
using AdvancedAudioManager.Scripts.Pool;
using UnityEngine;

namespace AdvancedAudioManager.Scripts.Audio.SoundEmitters
{
	[CreateAssetMenu(fileName = "NewSoundEmitterPool", menuName = "Game/Pool/SoundEmitter Pool")]
	public class SoundEmitterPoolSO : ComponentPoolSO<SoundEmitter>
	{
		[SerializeField] private SoundEmitterFactorySO _factory;

		public override IFactory<SoundEmitter> Factory
		{
			get => _factory;
			set => _factory = value as SoundEmitterFactorySO;
		}
	}
}
