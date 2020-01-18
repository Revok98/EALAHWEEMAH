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
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        /**/
    }

    void TaskOnClick()
    {
        if (Container.time <= 1)
        {
            SceneManager.LoadScene(beginningScene);
        }
        else
        {
            SceneManager.LoadScene(Container.lastSceneName);
        }
    }
}
