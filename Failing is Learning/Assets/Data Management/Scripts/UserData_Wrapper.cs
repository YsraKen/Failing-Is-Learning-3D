[System.Serializable]
public class UserData_Wrapper{ // just a user data, but levels array are excluded for file organization
	
	// Serializables
		public int
			currentLevelIndex,
			livesRemaining = defaultLifeAmount;

		public LevelData[] levels;
	
	#region Constructor
	
		public UserData_Wrapper(){
			currentLevelIndex = 0;
			livesRemaining = defaultLifeAmount;
			
			int length = UserData.maxLevelIndex + arrayOffset;
			levels = new LevelData[length];
			
			for(int i = 0; i < length; i++)
				levels[i] = new LevelData();
		}
		
		public UserData_Wrapper(UserData data){
			currentLevelIndex = data.currentLevelIndex;
			livesRemaining = data.livesRemaining;
			
			// levels = data.levels; // don't save levels here, they can save themselves
		}
		
	#endregion
	
	#region Magic Variables
	
		const string dataFileName = "UserData";
		
		const int
			arrayOffset = 1, // public modifier: used in MainMenu.OnResume_Button()
			defaultLifeAmount = 20;
		
	#endregion
			
	public void Save(){
		// don't save levels here, they can save themselves
		levels = null;
			
		SaveManager.Save(this, dataFileName);
	}
	
	public static UserData_Wrapper Load(){
		var data = SaveManager.Load<UserData_Wrapper>(dataFileName);
		
		if(data != null){
			int length = UserData.maxLevelIndex + arrayOffset;
			data.levels = new LevelData[length];
			
			for(int i = 0; i < length; i++)
				data.levels[i] = LevelData.Load(i);
		}
		
		return data;
	}
	
	public UserData Unwrap(){
		var unwrappedData = new UserData(this);
		return unwrappedData;
	}
}