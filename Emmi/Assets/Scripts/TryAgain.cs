using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgain : MonoBehaviour
{
    public string beginningScene;
    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /**/
    }


    public void TaskOnClick()
    {
        if (Container.time <= 1)
        {
            SceneManager.LoadScene(beginningScene);
            Container.time = 300f;
        }
        else
        {
            SceneManager.LoadScene(Container.lastSceneName);
        }
    }
}
