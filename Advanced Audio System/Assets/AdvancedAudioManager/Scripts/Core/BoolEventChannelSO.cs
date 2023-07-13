using UnityEngine;

namespace AdvancedAudioManager.Scripts.Core
{
	/// <summary>
	/// This class is used for Events that have a bool argument.
	/// Example: An event to toggle a UI interface
	/// </summary>

	[CreateAssetMenu(menuName = "Game/Events/Bool Event Channel")]
	public class BoolEventChannelSO : DescriptionBaseSO
	{
		public readonly EventRequest<bool> EventRequest = new();
	}
}
