using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IFightable
{
    [SerializeField] InputController inputController = null;
    [SerializeField] HP_UIController hpController = null;

    [SerializeField] float speed = 3.0f; // �̵� �ӵ�
    int hp = 10, life = 3;
    [SerializeField] int maxHp = 10;
    [SerializeField] int maxLife = 3;


    [SerializeField] float shot_delay_itv = 0.5f; // ���� �� ������ ����(interval)
    bool can_attack = false; // ���� ���� ����

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

    // ����
    public void Attack()
    {
        Invoke("ShotDelay", shot_delay_itv);
        BulletPool.GetBullet(eBulletType.PLAYER_BULLET).transform.position = 
            new Vector2(transform.position.x, transform.position.y + 0.5f);

        //Debug.Log("[PlayerC] Shot");
    }
    // ���� �� źȯ�� ���� �� ������ �ʰ� ���� �� �����̸� �����մϴ�.
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
