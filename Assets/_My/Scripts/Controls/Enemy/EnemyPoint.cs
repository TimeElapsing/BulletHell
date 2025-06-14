///=====================================================
/// - FileName:      EnemyPoint.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/14 16:16:41
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using System;
using XFABManager;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
namespace BulletHell
{
    public class EnemyPoint : MonoBehaviour
    {
        private Dictionary<string, Coroutine> curCor = new Dictionary<string, Coroutine>();
        private Player sunPlayer, starPlayer, moonPlayer;
        private GameObject enemyPre;
        private float produceCoolDown = 1f;
        //生成半径
        [SerializeField]
        private float radius = 4.5f;

        void Awake()
        {
            enemyPre = AssetBundleManager.LoadAsset<GameObject>(ThreeStars.ProjectName, "Enemy");
            curCor.Add("Sun", StartCoroutine(SpawnEnemyOnCircle(radius, 30, 150)));
            curCor.Add("Star", StartCoroutine(SpawnEnemyOnCircle(radius, -90, 30)));
            curCor.Add("Moon", StartCoroutine(SpawnEnemyOnCircle(radius, -210, -90)));
            sunPlayer = GameObject.Find("Player_Sun").GetComponent<SunPlayer>();
            starPlayer = GameObject.Find("Player_Star").GetComponent<StarPlayer>();
            moonPlayer = GameObject.Find("Player_Moon").GetComponent<MoonPlayer>();
        }

        void Update()
        {
            if (sunPlayer.isDead)
            {
                StopCoroutine(curCor["Sun"]);
            }
            if (starPlayer.isDead)
                StopCoroutine(curCor["Star"]);
            if (moonPlayer.isDead)
                StopCoroutine(curCor["Moon"]);
        }

        /// <summary>
        /// 在圆的指定角度边界随机生成怪物
        /// </summary>
        /// <param name="center">圆心</param>
        /// <param name="radius">半径</param>
        /// <param name="minAngle">最小角度（度）</param>
        /// <param name="maxAngle">最大角度（度）</param>
        /// <param name="monsterPrefab">怪物预制体</param>
        private IEnumerator SpawnEnemyOnCircle(float radius, float minAngle, float maxAngle)
        {
            while (true)
            {
                float angle = UnityEngine.Random.Range(minAngle, maxAngle); // 随机角度（度）
                float rad = angle * Mathf.Deg2Rad; // 转为弧度

                Vector3 pos = transform.position + new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * radius;

                var enemy = GameObjectLoader.Load(enemyPre, transform).GetComponent<Enemy>();
                enemy.Init(pos, transform.position);

                yield return new WaitForSeconds(produceCoolDown);
            }
        }

    }
}
