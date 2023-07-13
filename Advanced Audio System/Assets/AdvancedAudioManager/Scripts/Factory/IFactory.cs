namespace AdvancedAudioManager.Scripts.Factory
{
	/// <summary>
	/// Represents a factory.
	/// </summary>
	/// <typeparam name="T">Specifies the type to create.</typeparam>
	public interface IFactory<out T>
	{
		T Create();
	}
}
