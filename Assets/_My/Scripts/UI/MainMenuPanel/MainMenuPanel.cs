///=====================================================
/// - FileName:      MainMenuPanel.cs
/// - NameSpace:     BulletHell.UI
/// - Description:   框架自定BasePanel
/// - Creation Time: 2025/6/12 16:07:43
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork.UI;
using YukiFrameWork;
using UnityEngine.Events;
namespace BulletHell.UI
{
	public partial class MainMenuPanel : BasePanel
	{

		public void OnClickStart(UnityAction action) => Start.AddListenerPure(action);
		public void OnClickExit(UnityAction action) => Exit.AddListenerPure(action);
		
		
	}
}
