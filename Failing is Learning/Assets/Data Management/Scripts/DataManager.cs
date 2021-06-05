using UnityEngine;

public class DataManager : MonoBehaviour
{
	public static DataManager instance{ get; private set; }
	void Awake(){ instance = this; }
	
	UserData _currentData;
	public UserData currentData{
		get{
			if(_currentData == null)
				_currentData = UserData.Load();
			
			return _currentData;
		}
		set{
			_currentData = value;
		}
	}
	
	public void CreateNew(){
		var newData = new UserData();
			newData.Save();
			
		currentData = newData;
	}
	
	
}