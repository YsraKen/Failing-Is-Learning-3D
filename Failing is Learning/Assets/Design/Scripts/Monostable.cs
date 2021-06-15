using UnityEngine.Events;

// responsible for making a single-frame call for a bool that is constantly updating every frame
	// eg: ground check, input hold

[System.Serializable]
public class Monostable
{
	#region Events
		
		[System.Serializable]
		public class EventWrapper{ // containing all event variables for cleaner Editor Inspector
		
			// Unity Event
			public UnityEvent
				_onRise = new UnityEvent(), // rise: when a bool became "true"
				_onFall = new UnityEvent(), // fall: when a bool became "false"
				_onDual = new UnityEvent(); // dual: both rise and fall
				
			// Delegate
			public delegate void OnEdgeUpdate();
			public OnEdgeUpdate onRise, onFall, onDual;
			
			public void OnRise(){
				_onRise?.Invoke();
				onRise?.Invoke();
			}
			
			public void OnFall(){
				_onFall?.Invoke();
				onFall?.Invoke();
			}
			
			public void OnDual(){
				_onDual?.Invoke();
				onDual?.Invoke();
			}
		}

		public EventWrapper events = new EventWrapper();
		
	#endregion
	
	#region Main Logic
	
		bool _pulse;
		bool pulse{
			get{ return _pulse; }
			set{
				if(value != _pulse){
					_pulse = value;
					
					// On Rise
					if(_pulse) events.OnRise();
					
					// On Fall
					else events.OnFall();
					
					// On Dual
					events.OnDual();
				}
			}
		}
	
		// Input
		public void Update(bool continuous){
			pulse = continuous;
		}
	
	#endregion
}