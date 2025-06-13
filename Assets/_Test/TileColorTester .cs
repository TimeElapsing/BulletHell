///=====================================================
/// - FileName:      TileColorTester .cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/13 5:55:27
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;
namespace BulletHell
{
    public class TileColorTester  : MonoBehaviour
    {
        public Tile tile;
        public Tilemap tilemap => GameObject.Find("Tilemap").GetComponent<Tilemap>();

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cell = tilemap.WorldToCell(worldPos);

                if (tilemap.HasTile(cell))
                {
                    tilemap.RemoveTileFlags(cell, TileFlags.LockColor);
                    // tilemap.SetColor(cell, Color.red);
                    // tilemap.RefreshTile(cell);
                    // Debug.Log("染色成功：" + cell);

                    tilemap.SetTile(cell, tile);
                    tilemap.RefreshTile(cell);
                    Debug.Log("染色成功：" + cell);
                }

            }
        }

    }
}
