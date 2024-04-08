using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void LoadLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }    
}
