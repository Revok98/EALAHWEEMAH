using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagnetismManager : MonoBehaviour
{
    public Image Bar;
    public float Fill;
    public int magnetism;
    public int maxMagnetism;
    public Text texte;

    // Start is called before the first frame update
    void Start()
    {
        maxMagnetism = 20;
        magnetism = 0;
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = PercentMagnetism();
    }

    public float PercentMagnetism()
    {
        return (float)magnetism / (float)maxMagnetism;
    }
    public void UpdateAmount(int amount)
    {
        if (magnetism + amount < maxMagnetism)
        {
            magnetism += amount;
        }
        else
        {
            magnetism = maxMagnetism;
        }
    }

    public float GetValue()
    {
        return magnetism;
    }
}
