using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Destrubtable : MonoBehaviour
{

    public static int totalDestructable;

    [SerializeField] public Sprite[] sprite;
    [SerializeField] public AudioClip audioClip;
    [SerializeField] public int pointsWorthOnHit = 1;
    [SerializeField] public int pointsWorthOnDestroy = 1;
    private AudioSource audioSource;
    private Level level;

    private SceneChanger sceneChanger;
    private SpriteRenderer spriteRenderer;
    private int hits;

    // Start is called before the first frame update
    void Start()
    {

        totalDestructable++;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        hits = sprite.Length;
        spriteRenderer.sprite = sprite[hits -1];
        level = FindObjectOfType<Level>();
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
            level.addScore(pointsWorthOnHit);
            spriteRenderer.sprite = sprite[hits - 1];
            audioSource.PlayOneShot(audioClip);
        }
        else
        {

            level.addScore(pointsWorthOnDestroy);
            totalDestructable--;
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);

            if (totalDestructable <= 0)
            {
                Debug.Log("You win.");
                level.addLevel();
                Thread.Sleep(1500);
                level.NextLevel();
            }

            Destroy(gameObject);
        }
    }
}
