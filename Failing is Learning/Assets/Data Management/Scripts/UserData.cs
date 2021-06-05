[System.Serializable]
public class UserData
{
	public int
		currentLevelIndex,
		livesRemaining;
		
	public LevelData[] levels;
	
	public const int maxLevelIndex = 9; // used in UserData_Wrapper and MainMenu.OnResume_Button().
	
	#region Constructor
	
		public UserData(){
			// create a new dataWrapper (it creates variables)
				var dataWrapper = new UserData_Wrapper();
			
			// manual unwrapping
				currentLevelIndex = dataWrapper.currentLevelIndex;
				livesRemaining = dataWrapper.livesRemaining;
				levels = dataWrapper.levels;
		}
		
		public UserData(UserData_Wrapper dataWrapper){
			currentLevelIndex = dataWrapper.currentLevelIndex;
			livesRemaining = dataWrapper.livesRemaining;
			levels = dataWrapper.levels;
		}
	
	#endregion
	
	public static UserData Load(){
		var dataWrapper = UserData_Wrapper.Load();
		return dataWrapper?.Unwrap();
	}
	
	public void Save(){
		var dataWrapper = new UserData_Wrapper(this);
			dataWrapper.Save();
			
		for(int i = 0; i < levels.Length; i++)
			levels[i].Save(i);
	}
}