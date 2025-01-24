using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngScene : MonoBehaviour
{
    private Sprite[] images = null;
    private int imgi = 0;

    public Sprite[] imgTypeA = null;
    public Sprite[] imgTypeB = null;
    public Sprite[] imgTypeC = null;
    public Sprite[] imgTypeD = null;


    SpriteRenderer[] holeRenders = null;
    private int ri = 0;

    // Start is called before the first frame update
    void Start()
    {
        holeRenders = new SpriteRenderer[3];
        for (int i = 0; i<3; i++)
        {
            holeRenders[i] = GameObject.Find($"Hole {i+1}").GetComponent<SpriteRenderer>();
        }
        images = imgTypeA;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        holeRenders[ri].sprite = images[imgi];
        imgi = (imgi + 1) % images.Length;
        if (imgi == 0)
        {
            // next hole
            ri = (ri + 1) % holeRenders.Length;


            // next imagesation type
            if      (images == imgTypeA) images = imgTypeB;
            else if (images == imgTypeB) images = imgTypeC;
            else if (images == imgTypeC) images = imgTypeD;
            else if (images == imgTypeD) images = imgTypeA;
        }
    }
}
