using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Q04
{
    public class MngGame : MonoBehaviour
    {
        int cMax = 116;
        int cB = 0, cC = 0;

        public Mole[] moles;
        public Sprite[] animationB, animationC;

        void Awake()
        {
            Application.targetFrameRate = 60;
            Init();
            MakeMole();
        }
        void Init()
        {
            foreach (var m in moles)
            {
                m.Init();
            }
        }

        void MakeMole()
        {
            //if(cB == cMax) 
            print($"B: {cB}, C: {cC}");
            // play mole b
            StartCoroutine(moles[getRandMole()].PlayAnimation(animationB));
            cB++;
            // play mole c
            StartCoroutine(moles[getRandMole()].PlayAnimation(animationC));
            cC++;
        }

        int getRandMole()
        {
            print("getRandMole()");
            List<int> emptyMole = new List<int>();

            for (int i = 0; i < moles.Length; i++)
            {
                if (moles[i].gameObject.activeSelf == false)
                    emptyMole.Add(i);
            }
            print("find empty, count :" + emptyMole.Count);

            int ri = Random.Range(0, emptyMole.Count);
            print(string.Format("random id : {0} pos : ", ri, emptyMole[ri]));
            return ri;
        }
    }



}
