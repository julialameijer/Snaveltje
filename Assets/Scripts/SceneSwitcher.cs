 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    
    public string currentScene;
    public void newElement(GameObject newElement)
    {
        newElement.SetActive(true);
    }

    public void oldElement(GameObject oldElement)
    {
        oldElement.SetActive(false);
    }

    public void switchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
