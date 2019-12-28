using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        int index = (int)UnityEngine.Random.Range(0, audioClips.Length - 1);
        audioSource.PlayOneShot(audioClips[index]);
    }
}
