using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public Sprite[] open_sprites;
    public Sprite[] idle_sprites;
    public Sprite[] close_sprites;

    public Hole nextHole;

    private SpriteRenderer render;
    private int nState = 0;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    public IEnumerator animation()
    {
        print($"{gameObject.name}'s co routine");

        Sprite[] sprites = null;
        if      (nState == 0) sprites = open_sprites;
        else if (nState == 1) sprites = idle_sprites;
        else                  sprites = close_sprites;

        for (int i = 0; i < sprites.Length; i++)
        {
            render.sprite = sprites[i];
            yield return null;
        }

        nState = (nState + 1) % 3;
        StartCoroutine(nextHole.animation());
    }
}
