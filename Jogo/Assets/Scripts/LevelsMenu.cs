using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public MenuButtons menu;
    public Animator transition;
    public float transitiontime = 1f;
    public void LoadLevel(string SceneName)
    {
        menu.Levels.SetActive(false);
        StartCoroutine(Load(SceneName));
    }    

    IEnumerator Load(string SceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(SceneName);
    }
}
