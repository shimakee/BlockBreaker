using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrubtable : MonoBehaviour
{
    [SerializeField] Sprite[] sprite;
    SpriteRenderer spriteRenderer;
    int hits;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hits = sprite.Length;
        spriteRenderer.sprite = sprite[hits -1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hits > 1)
        {
            hits--;
            spriteRenderer.sprite = sprite[hits - 1];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
