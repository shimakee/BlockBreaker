using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoader : MonoBehaviour
{
    private int currentLevel = 1;
    private Level level;
    [SerializeField] int blockIncrement = 5;
    [SerializeField] int obstacleIncrement = 2;
    [SerializeField] GameObject[] destructables;
    [SerializeField] GameObject[] obstacles;
    private List<Vector2> objectPositions = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        CreateBlock();
        CreateObstracle();
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        currentLevel = level._currentLevel;
    }

    public void CreateBlock()
    {
        int numberOfBlocks = currentLevel * blockIncrement;
        Debug.Log(numberOfBlocks);
        for (int i = 0; i < numberOfBlocks; i++)
        {
            if (objectPositions.Count > 44)
                return;

            int index = UnityEngine.Random.Range(0, destructables.Length - 1);
            Instantiate(destructables[index], GenerateValidPosition(), transform.rotation);

        }

    }

    public void CreateObstracle()
    {
        int numberOfObstacles = currentLevel * obstacleIncrement;
        for (int i = 0; i < numberOfObstacles; i++)
        {
            if (objectPositions.Count > 44)
                return;

            int index = UnityEngine.Random.Range(0, obstacles.Length - 1);
            Instantiate(obstacles[index], GenerateValidPosition(), transform.rotation);
        }
    }

    private Vector2 GenerateValidPosition()
    {
        Vector2 position;
        do
        {
            position = GenerateVector2();
        } while (objectPositions.Contains(position));

        objectPositions.Add(position);
        return position;
    }

    private Vector2 GenerateVector2()
    {
        int x = (int)Math.Round((double)UnityEngine.Random.Range(0, 15));
        int y;

        do
        {
            y= (int)Math.Round((double)UnityEngine.Random.Range(5, 11));
        } while (y%2 == 0);

        Vector2 position = new Vector2(x, y);
        return position;
    }
}
