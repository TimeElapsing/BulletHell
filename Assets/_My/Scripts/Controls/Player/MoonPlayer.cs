///=====================================================
/// - FileName:      MoonPlayer.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/14 4:18:59
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using System;
using XFABManager;
namespace BulletHell
{
    public class MoonPlayer : Player
    {
        protected override async void Awake()
        {
            base.Awake();
            bulletPre = await AssetBundleManager.LoadAssetAsync<GameObject>(ThreeStars.ProjectName, "MoonBullet");
        }


    }
}
