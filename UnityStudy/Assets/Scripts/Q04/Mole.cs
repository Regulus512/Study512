using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public SpriteRenderer render;
    public void Init()
    {
        render = GetComponent<SpriteRenderer>();
    }

    public IEnumerator PlayAnimation(Sprite[] clip)
    {
        gameObject.SetActive(true);
        print($"{name} PlayAnimation({clip[0].name})");

        for (int i=0; i<clip.Length; i++)
        {
            render.sprite = clip[i];
            yield return null;
        }
        gameObject.SetActive(false);
        GameObject.Find("MngGame").SendMessage("MakeMole", SendMessageOptions.RequireReceiver);
    }
}
