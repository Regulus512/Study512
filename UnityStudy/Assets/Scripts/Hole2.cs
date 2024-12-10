using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole2 : MonoBehaviour
{
    public SpriteRenderer renderer1 = null;
    public SpriteRenderer renderer2 = null;
    public Sprite changeImage = null;

    // Start is called before the first frame update
    void Start()
    {
        // find host gameObject
        GameObject obj = GameObject.Find("Hole 1");

        // get component instance's address
        renderer1 = obj.GetComponent<SpriteRenderer>();

        renderer1.sprite = changeImage;
        renderer2.sprite = changeImage;
    }

}
