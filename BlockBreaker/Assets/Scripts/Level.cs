using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class Level : MonoBehaviour
{
    private int _score;
    public int _currentLevel = 1;
    [Range(.1f, 3f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI displayScore;
    [SerializeField] TextMeshProUGUI displayLevel;

    //private List<Vector2> objectPositions = new List<Vector2>();
    //[SerializeField] int blockIncrement = 5;
    //[SerializeField] int obstacleIncrement = 2;
    //[SerializeField] GameObject[] destructables;
    //[SerializeField] GameObject[] obstacles;

    private void Awake()
    {
        int count = FindObjectsOfType<Level>().Length;
        if(count > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        displayScore.text = _score.ToString();
        displayLevel.text = _currentLevel.ToString();

        if (Input.GetMouseButtonDown(1))
        {
            _currentLevel++;
            NextLevel();
        }
    }

    public void LevelReset()
    {
        _currentLevel = 1;
        _score = 0;
    }
    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneChanger.SceneChange(index);
    }

    public void GameOver()
    {
        LevelReset();
        SceneChanger.SceneChange(2);
    }

    public void addLevel()
    {
        _currentLevel++;
    }

    public void reduceLevel()
    {
        if (_currentLevel >= 1)
        {
            _currentLevel--;
        }
    }

    public void addScore(int score)
    {
        _score += score;
    }
}
