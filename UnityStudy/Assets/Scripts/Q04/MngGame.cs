using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Q04
{
    public enum eMOLETYPE { TYPE_B, TYPE_C };
    public class MngGame : MonoBehaviour
    {

        public Mole[] moles;
        public Sprite[] animationB, animationC;

        void Awake()
        {
            Application.targetFrameRate = 60;
            Init();
            Count();
        }
        void Init()
        {
            foreach (var m in moles)
            {
                m.Init();
            }
        }
        int count = 0;
        int max = 1;
        int limit = 16;

        void Count()
        {
            count++;
            //print($"Count - {count}");
            if (count==max)
            {
                //print($"Count Max - {max}");
                
                print($"B: {max}, C: {max}");
                while(count>0)
                {
                    count=(max<limit)?count-1:count-2;
                    MakeMole();
                }
                if(max < limit)
                    max *= 2;

            }
                
        }

        void MakeMole()
        {
            // play mole b
            Mole moleB = getRandMole();
            StartCoroutine(moleB.PlayAnimation(eMOLETYPE.TYPE_B, animationB));

            // play mole c
            Mole moleC = getRandMole();
            StartCoroutine(moleC.PlayAnimation(eMOLETYPE.TYPE_C, animationC));

        }

        Mole getRandMole()
        {
            List<int> emptyMole = new List<int>();
            string empty = "";
            for (int i = 0; i < moles.Length; i++)
            {
                if (moles[i].gameObject.activeSelf == false)
                {
                    empty += i + " ";
                    emptyMole.Add(i);
                }
            }

            int ri = 0;
            if (emptyMole.Count > 0)
                ri = Random.Range(0, emptyMole.Count);
            //print(empty+ "\n->"+emptyMole[ri]);
            Mole m = moles[emptyMole[ri]];
            m.gameObject.SetActive(true);

            return m;
        }
    }
}
    
