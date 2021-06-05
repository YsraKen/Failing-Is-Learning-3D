using UnityEngine;

public class InGamePopups : WindowUI
{
	protected static InGamePopups_Manager _mgr;
	protected static InGamePopups_Manager mgr{
		get{
			if(!_mgr)
				_mgr = InGamePopups_Manager.instance;
			
			return _mgr;
		}
	}
	
	public override void Open(){
		base.Open();
		mgr.OnPopupOpen(this);
	}
	
	public override void Close(){
		base.Close();
		mgr.OnPopupClose(this);
	}
}