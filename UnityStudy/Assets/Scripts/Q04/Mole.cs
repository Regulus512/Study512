using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Q04
{
    public class Mole : MonoBehaviour
    {
        public SpriteRenderer render;

        //eMOLETYPE moleType;
        public void Init()
        {
            render = GetComponent<SpriteRenderer>();
        }

        public IEnumerator PlayAnimation(eMOLETYPE type, Sprite[] clip)
        {
            if (type == eMOLETYPE.TYPE_B) Global.B++;
            else Global.C++;
            //gameObject.SetActive(true);
            //print($"{name} PlayAnimation({clip[0].name})");

            for (int i = 0; i < clip.Length; i++)
            {
                render.sprite = clip[i];
                yield return null;
            }
            gameObject.SetActive(false);
            if (type == eMOLETYPE.TYPE_B) Global.B--;
            else Global.C--;
            GameObject.Find("MngGame").SendMessage("Count", SendMessageOptions.RequireReceiver);
        }

        public void Die()
        {
            //

            gameObject.SetActive(false);
        }
    }

}
