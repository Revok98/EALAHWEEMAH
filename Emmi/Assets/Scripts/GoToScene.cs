using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string initial_scene = "";
    public string control_scene = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoTo() {
        Container.lastSceneName = initial_scene;
        SceneManager.LoadScene(initial_scene);
    }
    public void control()
    {
        SceneManager.LoadScene(control_scene);
    }
    public void Stop() {
        Application.Quit();
        //  UnityEditor.EditorApplication.isPlaying = false;
    }
}
