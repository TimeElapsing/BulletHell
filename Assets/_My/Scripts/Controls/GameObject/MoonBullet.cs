///=====================================================
/// - FileName:      MoonBullet.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/14 4:32:35
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using System;
using XFABManager;
using UnityEngine.Tilemaps;
namespace BulletHell
{
    public class MoonBullet : Bullet
    {
          protected override void Awake()
        {
            base.Awake();
            targetTile = AssetBundleManager.LoadAsset<Tile>(ThreeStars.ProjectName, "BlueTile");

        }

        protected override void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
             if (collision.tag == "Enemy")
            {
                collision.GetComponent<Enemy>().Injured(1);
                OnDestroy();
            }
        }


    }
}
