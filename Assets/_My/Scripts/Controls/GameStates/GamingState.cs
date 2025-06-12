///=====================================================
/// - FileName:      Gaming.cs
/// - NameSpace:     BulletHell
/// - Description:   YUKI 有限状态机构建状态类
/// - Creation Time: 2025/6/12 20:22:18
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork.Machine;
using UnityEngine;
using YukiFrameWork;
namespace BulletHell
{
	public class GamingState : StateBehaviour
	{
		public override void OnEnter()
		{
			//TODO 制作全局设置
			Debug.Log("进入");

		}
		public override void OnUpdate()
		{
			//TODO 制作游戏的整体时间检测
		}
		public override void OnExit()
		{
			Debug.Log("当退出状态");
			//TODO 归位整个游戏系统
		}

	}
}
