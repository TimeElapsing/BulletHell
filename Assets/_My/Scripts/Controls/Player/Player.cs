///=====================================================
/// - FileName:      Player.cs
/// - NameSpace:     BulletHell
/// - Description:   高级定制脚本生成
/// - Creation Time: 2025/6/13 15:40:19
/// -  (C) Copyright 2008 - 2025
/// -  All Rights Reserved.
///=====================================================
using YukiFrameWork;
using UnityEngine;
using XFABManager;
namespace BulletHell
{

    public class Player : MonoBehaviour
    {
        [Header("角色设置")]
        [SerializeField]
        protected float health = 10f;
        [SerializeField]
        public bool isDead = false;
        [Header("发射点设置")]
        //以右侧为起始0度
        private GameObject shootPoint;
        public float radius = 0.5f;
        public float angleSpeed = 60f; // 每秒多少度
        public float minAngle = 30f;
        public float maxAngle = 150f;
        //同时也为刚开始的起始角度
        private float currentAngle = 30f;
        private int direction = 1;

        [Header("发射子弹设置")]
        private Transform bulletParent;
        //子弹预制体
        protected GameObject bulletPre;
        protected float bulletSpeed = 3f;
        [SerializeField]
        protected float maxDistance = 4.2f;
        protected float attackCoolDown = 1f;
        //计时器
        private float timer = 0f;


        protected virtual void Awake()
        {
            shootPoint = transform.GetChild(0).gameObject;
            bulletParent = GameObject.Find("BulletParent").transform;
        }

        void Update()
        {
            UpdateShootPos();
            if (CanShoot())
            {
                Shoot();
            }
            if (health < 0)
                isDead = true;
        }

        //更新射击方位
        private void UpdateShootPos()
        {
            currentAngle += direction * angleSpeed * Time.deltaTime;

            if (currentAngle >= maxAngle) direction = -1;
            else if (currentAngle <= minAngle) direction = 1;

            // 更新 shootPoint 的位置（极坐标转笛卡尔）
            Vector2 offset = new Vector2(
                Mathf.Cos(currentAngle * Mathf.Deg2Rad),
                Mathf.Sin(currentAngle * Mathf.Deg2Rad)
            ) * radius;

            shootPoint.transform.position = transform.position + (Vector3)offset;
        }

        private bool CanShoot()
        {
            if (attackCoolDown < Time.time - timer && !isDead) 
                return true;
            else
                return false;

        }

        private void Shoot()
        {
            var bullet = GameObjectLoader.Load(bulletPre, bulletParent).GetComponent<Bullet>();
            var dir = (shootPoint.transform.position - transform.position).normalized;

            bullet.Init(dir, bulletSpeed, shootPoint.transform.position, maxDistance, this);
            timer = Time.time;

        }


        //用于使子类扩展
        public virtual void UseSkill()
        {

        }
        public virtual void Injured(float _num)
        {
            health -= _num;
        }
    }
}
