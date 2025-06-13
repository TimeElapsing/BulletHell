///=====================================================
/// - FileName:      Bullet.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/13 5:05:46
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using UnityEngine;
using UnityEngine.Tilemaps;
using XFABManager;
namespace BulletHell
{
    public abstract class Bullet : MonoBehaviour
    {
        private Player player;
        private Tilemap targetTilemap;
        protected Tile targetTile;
        private Vector3 lastCell;
        private Rigidbody2D rb;
        private float maxDistance;
        protected virtual void Awake()
        {
            targetTilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();

            rb = GetComponent<Rigidbody2D>();
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
            if (Vector2.Distance(player.transform.position, transform.position) > maxDistance)
                OnDestroy();
        

        }
        public void Init(Vector2 _dir, float _speed, Vector2 _initialPos, float _maxDistance, Player _player)
        {
            transform.position = _initialPos;
            rb.velocity = _dir * _speed;
            player = _player;
            maxDistance = _maxDistance;
        }

        protected void OnDestroy()
        {
            GameObjectLoader.UnLoad(this.gameObject);
        }

    }
}
