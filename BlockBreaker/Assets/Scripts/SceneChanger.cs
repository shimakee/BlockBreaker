﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void SceneChange(int index)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        Debug.Log(sceneCount);

        if (index >= sceneCount)
            index = sceneCount - 1;

        SceneManager.LoadScene(index);
    }
    public void ChangeScene(int index)
    {
        SceneChange(index);
    }
}
