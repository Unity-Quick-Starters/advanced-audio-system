using UnityEngine;

namespace AdvancedAudioManager.Scripts.Core
{
	/// <summary>
	/// This class is used for Events that have one int argument.
	/// Example: An Achievement unlock event, where the int is the Achievement ID.
	/// </summary>
	[CreateAssetMenu(menuName = "Game/Events/Float Event Channel")]
	public class FloatEventChannelSO : DescriptionBaseSO
	{
		public readonly EventRequest<float> EventRequest = new();
	}
}
