///=====================================================
/// - FileName:      StarBullet.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/14 3:53:57
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using XFABManager;
using UnityEngine.Tilemaps;
namespace BulletHell
{
    public class StarBullet : Bullet
    {

        protected override void Awake()
        {
            base.Awake();
            targetTile = AssetBundleManager.LoadAsset<Tile>(ThreeStars.ProjectName, "YellowTile"); 

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
