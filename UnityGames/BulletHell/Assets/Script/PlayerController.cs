using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IFightable
{
    [SerializeField] InputController inputController = null;
    [SerializeField] HP_UIController hpController = null;

    [SerializeField] float speed = 3.0f; // 이동 속도
    int hp = 10, life = 3;
    [SerializeField] int maxHp = 10;
    [SerializeField] int maxLife = 3;


    [SerializeField] float shot_delay_itv = 0.5f; // 공격 후 딜레이 간격(interval)
    bool can_attack = false; // 공격 가능 상태

    private void Awake()
    {
        if (!inputController)
        {
            inputController = GetComponent<InputController>();
        }
        inputController.InitInputController(speed);
        hpController.InitHp(maxHp);
        hp = maxHp;
    }
    public void GameStart()
    {
        can_attack = true;
    }
    public void GameOver()
    {
        can_attack = false;
        hp = maxHp;
        life = maxLife;
        hpController.InitHp(maxHp);
        CancelInvoke();
    }

    // 공격
    public void Attack()
    {
        Invoke("ShotDelay", shot_delay_itv);
        BulletPool.GetBullet(eBulletType.PLAYER_BULLET).transform.position = 
            new Vector2(transform.position.x, transform.position.y + 0.5f);

        //Debug.Log("[PlayerC] Shot");
    }
    // 공격 시 탄환이 여러 발 나가지 않게 공격 후 딜레이를 실행합니다.
    void ShotDelay()
    {
        can_attack = true;
        //Debug.Log($"[PlayerC] Delay : {shot_delay_itv}");
    }

    public void Damaged(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            life--;
            hp = maxHp;
            hpController.ChangeHP();
        }
        else
        {
            hpController.MinusHP(hp);
        }

        if (life <= 0)
        {
            can_attack = false;
            GameManager.GetInstance().GameOver();
            return;
        }
        //Debug.Log($"[PlayerC] Damaged() left life : {life}");
    }


    private void FixedUpdate()
    {
        if(can_attack)
        {
            can_attack = false;
            Attack();
        }
    }
}
