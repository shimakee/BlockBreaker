﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    
    [SerializeField] float CameraUnitWidth= 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;
    [SerializeField] int paddleSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float xPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * CameraUnitWidth, minX, maxX);

        Vector2 vector = new Vector2(xPosition, 0);
        transform.position = vector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        int index = (int)UnityEngine.Random.Range(0, audioClips.Length -1);
        audioSource.PlayOneShot(audioClips[index]);
    }
}
