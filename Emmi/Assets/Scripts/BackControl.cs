using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackControl : MonoBehaviour
{

    public string menu_scene = "";
    public void getBack() {
        SceneManager.LoadScene(menu_scene);
    }
}
