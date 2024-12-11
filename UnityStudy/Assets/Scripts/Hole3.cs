using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole3 : MonoBehaviour
{
    public Sprite[] image;
    private int index = 0;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        render.sprite = image[index];
        index = (index + 1) % image.Length;
    }
}
