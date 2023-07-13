namespace AdvancedAudioManager.Scripts.Core
{
    public class EventRequest<T, TR>
    {
        public delegate TR UpdateValue(T newValue);

        public UpdateValue Updated;
        
        public TR RaiseEvent(T newValue)
        {
            return Updated != null ? Updated(newValue) : default;
        }
    }
    
    public class EventRequest<T> : EventRequest<T, bool>
    {
    }
    
    public class EventRequest
    {
        public delegate bool UpdateValue();

        public UpdateValue Updated;

        public bool RaiseEvent()
        {
            return Updated?.Invoke() ?? false;
        }
    }
}