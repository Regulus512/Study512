using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    // 사용중인 bullet의 부모 트랜스폼
    [SerializeField] Transform usingBullet;
    // bullet 오브젝트의 부모 트랜스폼
    [SerializeField] Transform playerbpool_transform, bossbpool_transform_A, bossbpool_transform_B, bossbpool_transform_C;

    [SerializeField] Bullet player_bullet_prefab;
    [SerializeField] Bullet boss_bullet_prefab_A, boss_bullet_prefab_B, boss_bullet_prefab_C;

    // 플레이어 총알 풀 사이즈
    [SerializeField] int player_bpool_count = 100; 
    Queue<Bullet> playerBulletQueue = new Queue<Bullet>();

    // 보스 총알 패턴 A 풀 사이즈
    [SerializeField] int boss_bpool_a_count = 100;
    [SerializeField] int boss_bpool_b_count = 100;
    [SerializeField] int boss_bpool_c_count = 100;


    // 총알 큐
    Queue<Bullet> bossBulletQueue_A = new Queue<Bullet>();

    Queue<Bullet> bossBulletQueue_B = new Queue<Bullet>();

    Queue<Bullet> bossBulletQueue_C = new Queue<Bullet>();


    public void GameOver()
    {
        foreach(Bullet b in usingBullet.GetComponentsInChildren<Bullet>())
        {
            ReturnBullet(b);
        }
    }

    void Awake()
    {
        instance = this;

        InitPool(playerBulletQueue, player_bpool_count, player_bullet_prefab, playerbpool_transform);
        InitPool(bossBulletQueue_A, boss_bpool_a_count, boss_bullet_prefab_A, bossbpool_transform_A);
        InitPool(bossBulletQueue_B, boss_bpool_b_count, boss_bullet_prefab_B, bossbpool_transform_B);
        InitPool(bossBulletQueue_C, boss_bpool_c_count, boss_bullet_prefab_C, bossbpool_transform_C);
        
    }

    
    // 풀 초기화
    void InitPool(Queue<Bullet> bullet_pool, int initCount, Bullet bullet_prefab, Transform parent)
    {
        for(int i = 0; i<initCount; i++)
        {
            bullet_pool.Enqueue(CreateNewBullet(bullet_prefab, parent));
        }
    }

    // 최초에만 생성될 총알 오브젝트
    Bullet CreateNewBullet(Bullet bullet_prefab, Transform parent)
    {
        Bullet newBullet = Instantiate(bullet_prefab).GetComponent<Bullet>();
        newBullet.gameObject.SetActive(false);
        newBullet.transform.SetParent(parent);
        return newBullet;
    }

    public static Bullet GetBullet(eBulletType bulletType)
    {
        Bullet bullet = null;
        switch (bulletType)
        {
            case eBulletType.PLAYER_BULLET:
                bullet = instance.playerBulletQueue.Dequeue();
                break;
            case eBulletType.BOSS_BULLET_A:
                bullet = instance.bossBulletQueue_A.Dequeue();
                break;
            case eBulletType.BOSS_BULLET_B:
                bullet = instance.bossBulletQueue_B.Dequeue();
                break;
            case eBulletType.BOSS_BULLET_C:
                bullet = instance.bossBulletQueue_C.Dequeue();
                break;
        }
        //AddForce를 초기화
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        bullet.CancelInvoke();
        bullet.transform.SetParent(instance.usingBullet);
        // override가 있는 경우 bullet초기화
        bullet.InitBullet();
        bullet.gameObject.SetActive(true);
        return bullet;
    }



    public static void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        switch (bullet.getBulletType())
        {
            case eBulletType.PLAYER_BULLET:
                instance.playerBulletQueue.Enqueue(bullet);
                bullet.transform.SetParent(instance.playerbpool_transform);
                break;
            case eBulletType.BOSS_BULLET_A:
                instance.bossBulletQueue_A.Enqueue(bullet);
                bullet.transform.SetParent(instance.bossbpool_transform_A);
                break;
            case eBulletType.BOSS_BULLET_B:
                instance.bossBulletQueue_B.Enqueue(bullet);
                bullet.transform.SetParent(instance.bossbpool_transform_B);
                break;
            case eBulletType.BOSS_BULLET_C:
                instance.bossBulletQueue_C.Enqueue(bullet);
                bullet.transform.SetParent(instance.bossbpool_transform_C);
                break;
            default:
                Debug.Log($"[BulletPool] ReturnBullet() eBulletType default");
                break;
        }
    }

}