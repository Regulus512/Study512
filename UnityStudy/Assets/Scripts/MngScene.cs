using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngScene : MonoBehaviour
{
    private Sprite[] anim = null;
    private int animID = 0;

    public Sprite[] animTypeA = null;
    public Sprite[] animTypeB = null;
    public Sprite[] animTypeC = null;
    public Sprite[] animTypeD = null;


    SpriteRenderer[] holeRenders = null;
    private int holeID = 0;

    // Start is called before the first frame update
    void Start()
    {
        holeRenders = new SpriteRenderer[3];
        for (int i = 0; i<3; i++)
        {
            holeRenders[i] = GameObject.Find($"Hole {i+1}").GetComponent<SpriteRenderer>();
        }
        anim = animTypeA;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        holeRenders[holeID].sprite = anim[animID];
        animID = (animID + 1) % anim.Length;
        if (animID == 0)
        {
            // next hole
            holeID = (holeID + 1) % holeRenders.Length;


            // next animation type
            if      (anim == animTypeA) anim = animTypeB;
            else if (anim == animTypeB) anim = animTypeC;
            else if (anim == animTypeC) anim = animTypeD;
            else if (anim == animTypeD) anim = animTypeA;
        }
    }
}
