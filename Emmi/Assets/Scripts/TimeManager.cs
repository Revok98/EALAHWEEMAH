using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float time;
    public Text texte;

    // Start is called before the first frame update
    void Start()
    {
        time = 300f;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        Container.time = this.time;
        texte.text = "Temps restant : " + (Mathf.Round(time * 10f) / 10f) + " secondes";
        if (time < 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            Container.lastSceneName = scene.name;
            SceneManager.LoadScene("GameOver");
        }
    }
}
