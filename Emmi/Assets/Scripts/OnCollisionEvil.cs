using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnCollisionEvil : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("Energy Bar"));
            Scene scene = SceneManager.GetActiveScene();
            Container.lastSceneName = scene.name;
            SceneManager.LoadScene("GameOver");
        }
    }
}
