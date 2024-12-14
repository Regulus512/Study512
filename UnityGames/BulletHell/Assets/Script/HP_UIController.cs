using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_UIController : MonoBehaviour
{
    [SerializeField] Image curHPBar = null;

    // 남은 체력에 따라 바뀔 스프라이트
    [SerializeField] Image[] hpImgs;
    int id = 0;

    float maxHP = 100;

    public void InitHp(int _maxHp)
    {
        maxHP = _maxHp;
        curHPBar = hpImgs[0];
        curHPBar.gameObject.SetActive(true);
        curHPBar.fillAmount = 1;
    }

    public void ChangeHP()
    {
        // hp image change
        if (id < hpImgs.Length - 1) 
        {
            id++;
            curHPBar = hpImgs[id];
            hpImgs[id-1].gameObject.SetActive(false);
        }
    }

    public void MinusHP(int hp)
    {
        curHPBar.fillAmount = hp / maxHP;
    }
}
