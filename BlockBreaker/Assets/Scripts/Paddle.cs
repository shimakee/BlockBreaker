using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Paddle : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] float CameraUnitWidth= 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * CameraUnitWidth, minX, maxX);

        Vector2 vector = new Vector2(xPosition, 1);
        transform.position = vector;

        if(timer > 0)
            timer -= Time.deltaTime;
        if(timer <= 0)
            spriteRenderer.sprite = sprites[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        timer = .3f;
        spriteRenderer.sprite = sprites[1];
        int index = (int)UnityEngine.Random.Range(0, audioClips.Length -1);
        audioSource.PlayOneShot(audioClips[index]);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}