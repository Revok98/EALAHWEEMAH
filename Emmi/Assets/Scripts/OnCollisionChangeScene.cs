using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollisionChangeScene : MonoBehaviour
{
    public string SceneToGo;
    public GameObject target;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == target.tag)
        {
            Scene scene = SceneManager.GetActiveScene();
            Container.lastSceneName = scene.name;
            SceneManager.LoadScene(SceneToGo);
        }
    }
}
