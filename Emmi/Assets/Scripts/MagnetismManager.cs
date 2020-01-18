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
        Fill = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Fill;
    }

    public void UpdateAmount(float amount)
    {
        Fill += amount;
    }

    public float GetValue()
    {
        return Fill;
    }
}
