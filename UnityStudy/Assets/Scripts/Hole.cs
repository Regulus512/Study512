using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private SpriteRenderer render;
    
    public Sprite[] open_sprites;
    public Sprite[] idle_sprites;
    public Sprite[] close_sprites;
    private Sprite[] sprites;

    //public Hole nextHole;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        sprites = open_sprites;
    }

    public void PlayAnimation()
    {
        StartCoroutine(changeImage ());
    }

    IEnumerator changeImage()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            print($"co routine: {i}");
            render.sprite = sprites[i];
            yield return null;
        }
        if      (sprites == open_sprites)   sprites = idle_sprites;
        else if (sprites == idle_sprites)   sprites = close_sprites;
        else if (sprites == close_sprites)  sprites = open_sprites;
        //PlayAnimation();
    }
}
