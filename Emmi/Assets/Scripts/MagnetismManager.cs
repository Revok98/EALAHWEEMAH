using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagnetismManager : MonoBehaviour
{
    public Image Bar;
    public float Fill;
    // Start is called before the first frame update
    void Start()
    {
        Fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Fill;
        Fill = Fill - 0.01f;
    }
}
