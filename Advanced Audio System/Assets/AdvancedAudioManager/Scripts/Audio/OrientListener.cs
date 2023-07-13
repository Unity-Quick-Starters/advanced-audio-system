using UnityEngine;

// Orient the listener to point in the same direction as the camera.
namespace AdvancedAudioManager.Scripts.Audio
{
	public class OrientListener : MonoBehaviour
	{
		// Reference to the camera transform determine listener orientation
		[SerializeField] private Transform _cameraTransform;

		private void LateUpdate()
		{
			if(_cameraTransform)
				transform.forward = _cameraTransform.forward;
		}
	}
}
