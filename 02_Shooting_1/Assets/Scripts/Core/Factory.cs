using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

public enum PoolObjectType
{
    PlayerBullet = 0,
    HitEffect,
    ExplosionEffect,
    Enemy
}
public class Factory: Singleton<Factory>
{
    BulletPool bullet;
    HitEffectPool hit;
    ExplosionEffectPool explosion;
    EnemyPool enemy;

    protected override void OnInitailize()
    {
        base.OnInitailize();
        
        bullet = GetComponentInChildren<BulletPool>();  //나와 내 자식 오브젝트에서 컴포넌트 찾음
        if(bullet != null )
        {
            bullet.Initialize();
        }
        hit = GetComponentInChildren<HitEffectPool>();
        if (hit != null)
        {
            hit.Initialize();
        }
        explosion = GetComponentInChildren<ExplosionEffectPool>();
        if(explosion != null)
        {
            explosion.Initialize();
        }
        enemy = GetComponentInChildren<EnemyPool>();
        if(enemy != null)
        {
            enemy.Initialize();
        }
    }

    public GameObject GetObject(PoolObjectType type)
    {
        GameObject result;
        switch (type)
        {
            case PoolObjectType.PlayerBullet:
                result = bullet.GetObject().gameObject;
                break;
            case PoolObjectType.HitEffect:
                result = hit.GetObject().gameObject;
                break;
            case PoolObjectType.ExplosionEffect:
                result = explosion.GetObject().gameObject;
                break;
            case PoolObjectType.Enemy:
                result = enemy.GetObject().gameObject;
                break;
            default:
                result = null;
                break;
        }
        return result;
    }

    public GameObject GetObject(PoolObjectType type, Vector3 position)
    {
        GameObject obj = GetObject(type);
        obj.transform.position = position;

        return obj;
    }

    public Bullet GetBullet()
    {
        return bullet.GetObject();
    }

    public Bullet GetBullet(Vector3 position)
    {
        Bullet bulletComp = bullet.GetObject();
        bulletComp.transform.position = position;
        return bulletComp;
    }
    public Explosion GetExplosionEffect()
    {
        return explosion.GetObject();
    }
    public Explosion GetExplosionEffect(Vector3 position)
    {
        Explosion explosionComp = explosion.GetObject();
        explosionComp.transform.position = position;
        return explosionComp;
    }
    public Explosion GetHitEffect()
    {
        return hit.GetObject();
    }
    public Explosion GetHitEffect(Vector3 position)
    {
        Explosion hitComp = hit.GetObject();
        hitComp.transform.position = position;
        return hitComp;
    }
    public Enemy GetEnemy()
    {
        return enemy.GetObject();
    }
    public Enemy GetEnemy(Vector3 position)
    {
        Enemy enemyComp = enemy.GetObject();
        enemyComp.transform.position = position;
        return enemyComp;
    }
}
