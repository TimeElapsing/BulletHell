///=====================================================
/// - FileName:      Main.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/12 7:26:53
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using System;
using System.Threading.Tasks;
using XFABManager;
using YukiFrameWork.Machine;
namespace BulletHell
{
    public class Main : ViewController
    {
        protected override async void Awake()
        {
            base.Awake();

            //等待框架开始
            await ThreeStarts.StartUp();

            var core = await AssetBundleManager.LoadAssetAsync<RuntimeStateMachineCore>(ThreeStarts.ProjectName, "Game");
            StateManager.StartMachine("Game", core, typeof(ThreeStarts));
        }


    }
    public enum GameState
    {
        MainMenu = 0,
        Gameing = 1
        
    }
}
