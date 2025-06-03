using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Q04
{
    public enum eMOLETYPE { TYPE_B, TYPE_C };
    public class MngGame : MonoBehaviour
    {
        public GameObject molePrefab, parent;
        public Mole[] ms;

        public Sprite[] animationB, animationC;

        void Awake()
        {
            Application.targetFrameRate = 60;
            Init();
            Count();
        }
        void Init()
        {
            int[] x = { -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6 };
            int[] y = { 4, 3, 2, 1, 0, -1, -2, -3};
            ms = new Mole[x.Length * y.Length];
            print("ms Length=" + ms.Length); // 116

            for (int i = 0; i < y.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    GameObject obj = Instantiate(molePrefab, parent.transform);
                    obj.transform.position = new Vector2(x[j], y[i]);
                    Mole mole = obj.GetComponent<Mole>();
                    ms[i * x.Length + j] = mole;
                    mole.Init();
                }
                
            }
        }
        int count = 0;
        int max = 1;

        // mole sendmessage -> count()
        void Count()
        {
            int limit = ms.Length; //28
            count++;
            //print($"Count - {count}");
            if (count == max)
            {
                //print($"Count Max - {max}");
                while (count > 0)
                {
                    count = (max < limit) ? count - 1 : count - 2;
                    MakeMole();
                }
                print($"B: {Global.B}, C: {Global.C}");
                if (max < limit)
                {
                    max = (max*2>limit)? limit : max*2;
                }
            }
        }
        
        void MakeMole()
        {
            // play mole b
            Mole moleB = getRandMole();
            if(moleB!=null)
            StartCoroutine(moleB.PlayAnimation(eMOLETYPE.TYPE_B, animationB));

            // play mole c
            Mole moleC = getRandMole();
            if (moleC != null)
                StartCoroutine(moleC.PlayAnimation(eMOLETYPE.TYPE_C, animationC));

        }

        Mole getRandMole()
        {
            List<int> emptyMole = new List<int>();
            string empty = "";
            for (int i = 0; i < ms.Length; i++)
            {
                if (ms[i].gameObject.activeSelf == false)
                {
                    empty += i + " ";
                    emptyMole.Add(i);
                }
            }
            //print(empty+ "\n->"+emptyMole[ri]);

            int ri = 0;
            ri = Random.Range(0, emptyMole.Count);
            
            if (emptyMole.Count == ri)
            {
                //print("none");
                return null;
            }
                
            Mole m = ms[emptyMole[ri]];
            m.gameObject.SetActive(true);

            return m;
        }
    }
}
    
