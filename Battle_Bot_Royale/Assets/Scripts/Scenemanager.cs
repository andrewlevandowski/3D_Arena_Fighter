using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SceneLoding(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    public void OnShowObj(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void OnDisObj(GameObject obj)
    {
        obj.SetActive(false);
    }
}