using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Loose : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;
    public Level level;
    private int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int index = (int)UnityEngine.Random.Range(0, audioClips.Length - 1);
        audioSource.PlayOneShot(audioClips[index]);
        //AudioSource.PlayClipAtPoint(audioClips[index], level.transform.position);
        level.GameOver();
    }

}
