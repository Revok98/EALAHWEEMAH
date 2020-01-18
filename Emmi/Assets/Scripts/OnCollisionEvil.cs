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
            SceneManager.LoadScene("GameOver");
        }
    }
}
