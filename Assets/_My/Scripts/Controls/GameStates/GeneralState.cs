///=====================================================
/// - FileName:      GeneralState.cs
/// - NameSpace:     BulletHell
/// - Description:   YUKI 有限状态机构建状态类
/// - Creation Time: 2025/6/12 20:37:08
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
	public class GeneralState : StateBehaviour
	{
		public override async void OnEnter()
		{
			await SceneTool.XFABManager.LoadSceneAsync("Game");
			UIKit.HidePanel<LoadingPanel>();
			// 打开主要场景UI
			UIKit.ShowPanel<ForegroundPanel>();
			var panel = UIKit.OpenPanel<UIPanel>();
		}
		public override void OnExit()
		{
			Debug.Log("当退出状态");
		}

	}
}
