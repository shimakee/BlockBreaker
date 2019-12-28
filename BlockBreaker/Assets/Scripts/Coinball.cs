using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinball : MonoBehaviour
{

    [SerializeField] bool lockStart = true;
    //[SerializeField] AudioClip[] audioClips;
    [Range(0.1f, 10f)][SerializeField] float ballPositionY = 2;
    [Range(0.1f, 50f)][SerializeField] float speed = 2f;
    Paddle paddle;

    Vector2 velocity = new Vector2(0,0);
    Vector2 position = new Vector2(0,0);
    Rigidbody2D rigidBody;
    //AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        paddle = FindObjectOfType<Paddle>();
        position.y = ballPositionY;
        velocity.y = speed;
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lockStart || Input.GetKey(KeyCode.Space) && lockStart)
        {
            lockStart = false;
            rigidBody.velocity = velocity;
        };

        if (lockStart)
        {
            position.x = paddle.transform.position.x;
            transform.position = position;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    int index = (int)UnityEngine.Random.Range(0, audioClips.Length - 1);
    //    audioSource.PlayOneShot(audioClips[index]);
    //}
}
