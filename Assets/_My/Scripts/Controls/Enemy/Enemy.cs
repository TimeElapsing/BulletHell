///=====================================================
/// - FileName:      Enemy.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/14 16:05:47
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using System;
using XFABManager;
using UnityEngine.Tilemaps;
using System.Diagnostics.Contracts;
namespace BulletHell
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float health = 5;
        [SerializeField]
        private float curHealth;

        private Vector3 targetPos;

        private Tilemap targetTilemap;
        protected Tile targetTile;
        private Vector3 lastCell;


        private Rigidbody2D rb;

        [SerializeField]
        private float moveSpeed = 3f;
        protected virtual void Awake()
        {
            targetTilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
            targetTile = AssetBundleManager.LoadAsset<Tile>(ThreeStars.ProjectName, "WhiteTile");
            rb = GetComponent<Rigidbody2D>();
        }
        void OnEnable()
        {
            curHealth = health;
        }

        void Update()
        {
            // 获取当前位置的格子
            Vector3Int cellPos = targetTilemap.WorldToCell(transform.position);

            // 如果位置有变化
            if (cellPos != targetTilemap.WorldToCell(lastCell))
            {
                if (targetTilemap.HasTile(cellPos))
                {
                    targetTilemap.SetTile(cellPos, targetTile);
                    lastCell = transform.position;
                }
            }        
            
            if (curHealth < 0)
                OnDestroy();

        }
        public void Init(Vector3 _initialPos, Vector3 _targetPos)
        {
            transform.position = _initialPos;
            targetPos = _targetPos;
            rb.velocity = (targetPos - transform.position).normalized * moveSpeed;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Player>().Injured(curHealth);
                OnDestroy();
            }
        }

        public void Injured(float _num)
        {
            curHealth -= _num;
        }


        protected void OnDestroy()
        {
            GameObjectLoader.UnLoad(this.gameObject);
        }

    }


    
}
