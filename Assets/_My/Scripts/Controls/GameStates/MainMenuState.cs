///=====================================================
/// - FileName:      MainMenu.cs
/// - NameSpace:     BulletHell
/// - Description:   YUKI 有限状态机构建状态类
/// - Creation Time: 2025/6/12 15:53:05
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork.Machine;
using UnityEngine;
using YukiFrameWork;
using System.Threading.Tasks;
using YukiFrameWork.UI;
using BulletHell.UI;
namespace BulletHell
{
	public class MainMenuState : StateBehaviour
	{
		public override async void OnEnter()
		{
			base.OnEnter();
			await SceneTool.XFABManager.LoadSceneAsync("MainMenu");
			var panel = UIKit.OpenPanel<MainMenuPanel>();
			UIKit.HidePanel<LoadingPanel>();

			panel.OnClickStart(() =>
			{
				SetInt("GameState", (int)GameState.Gameing);
				UIKit.ShowPanel<LoadingPanel>();

			});
			panel.OnClickExit(() =>
			{
				Debug.Log("点击了退出");
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();				
#endif
			});
		}
		public override void OnExit()
		{
			base.OnExit();
			UIKit.ClosePanel<MainMenuPanel>();
			UIKit.ShowPanel<LoadingPanel>();
        }
	}
}
