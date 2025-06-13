///=====================================================
/// - FileName:      ThreeStarts.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/12 7:28:15
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using System;
using YukiFrameWork.UI;
namespace BulletHell
{
    public class ThreeStars : Architecture<ThreeStars>
    {

        //可以填写默认进入的场景名称，在架构准备完成后，自动进入
        public override (string, SceneLoadType) DefaultSceneName => default;
        public override string OnProjectName => "ThreeStars";

        public override void OnInit()
        {
            UIKit.Init(OnProjectName);
            SceneTool.XFABManager.Init(OnProjectName);

        }
        //配表构建，通过ArchitectureTable可以在架构中缓存部分需要的资源,例如TextAssets ScriptableObject
        protected override ArchitectureTable BuildArchitectureTable() => default;

        //当架构准备完成后触发，当架构加载失败抛出异常则不会执行
        public override void OnCompleted()
        {

        }


    }
}
