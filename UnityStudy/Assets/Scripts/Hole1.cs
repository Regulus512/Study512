using System.Collections; // array
using UnityEngine;

public class Hole1 : MonoBehaviour
{
    private SpriteRenderer render;
    public Sprite[] sprites;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        StartCoroutine(changeImage());
    }

    IEnumerator changeImage()
    {
        for(int i=0; i<sprites.Length; i++)
        {
            render.sprite = sprites[i];
        }
        yield return null;
    }
}
