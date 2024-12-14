using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IFightable
{
    [SerializeField] Transform target = null; // �÷��̾� �ǽð� ��ġ
    [SerializeField] HP_UIController hpController = null;


    [SerializeField] float attack_itv = 3.0f; // ���� ���� ���ݱ����� ���� ��Ÿ��
    int hp = 10, life = 2;
    [SerializeField] int maxHp = 10;
    [SerializeField] int maxLife = 2;

    [Range(0f, 3f)]
    [SerializeField] float moveSpeed_Min, moveSpeed_Max = 1.0f; // ������ �̵��� ���� �ӵ�
    float moveSpeed = 0f;
    [SerializeField] float changeVec_itv = 1.0f; // �̵� ���� ���� ����(��)
    bool can_move = false;
    Vector2 moveVec = Vector2.zero;


    [SerializeField] Pattern[] patterns; // ������ ����ϴ� ����
    public float lookAngle { get; set; }

    [SerializeField] ScoreController scoreController;
    [SerializeField] int bossScore = 15;

    private void Awake()
    {
        hpController.InitHp(maxHp);
        hp = maxHp;
    }
    public void GameStart()
    {
        Invoke("Attack", attack_itv);
    }
    public void GameOver()
    {
        CancelInvoke();
        hp = maxHp;
        life = maxLife;
        hpController.InitHp(maxHp);

        foreach (var p in patterns)
        {
            p.CancelInvoke();
            p.StopAllCoroutines();
        }
    }
    public void Attack()
    {
        // ���� ���� ���
        int i = Random.Range(0, patterns.Length);
        patterns[i].Attack();
    }

    public void AttackEnd() //attack_itv��ŭ�� ��Ÿ�� �� �ٽ� Attack
    {
        Invoke("Attack", attack_itv);
    }
    
    public void Damaged(int damage)
    {
        // add score
        scoreController.AddScore(bossScore);
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
            GameManager.GetInstance().GameClear();
            return;
        }
        
        if (!can_move && life == 1 && hp <= 50)
        {
            can_move = true;
            ChangeMoveVec();
            //Debug.Log($"[Boss] life danger! : {hp}");
        }
        //Debug.Log($"[Boss] Damaged() left life : {hp}");

        


    }
    void ChangeMoveVec()
    {
        Vector2 randVec;
        do
        {
            randVec = new Vector2(Random.Range(-10, 10) % 2, Random.Range(-10, 10) % 2);
        }
        while (randVec == Vector2.zero);

        moveSpeed = Random.Range(moveSpeed_Min, moveSpeed_Max);
        moveVec = randVec;
        Debug.Log($"[BossC] ChangeMoveVec : {moveVec}");
        Invoke("ChangeMoveVec", changeVec_itv);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = new Vector2(
                transform.position.x - target.position.x,
                transform.position.y - target.position.y);
            lookAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // 180�� ȸ���Ͽ� �Ʒ��� ���� �����Ƿ� -(90+180)
            Quaternion angleAxis = Quaternion.AngleAxis(lookAngle - 270f, Vector3.forward);
            transform.rotation = angleAxis;
        }
        if(can_move)
        {
            transform.Translate(moveVec * moveSpeed*Time.deltaTime);
        }
    }

}
