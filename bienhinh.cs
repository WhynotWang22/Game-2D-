using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bienhinh : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public  Sprite SmileSprite, SabSprite;

    // Start is called before the first frame update
    void Start()
    {
       SpriteRenderer = this.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.V))
        {
            if (SpriteRenderer.sprite != SabSprite)
            {
                SpriteRenderer.sprite = SabSprite;
            }
             else 
            {
                SpriteRenderer.sprite = SmileSprite;
            }
        }
    }
}
