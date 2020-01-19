using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagnetismManager : MonoBehaviour
{
    public Image Bar;
    public Text texte;

    // Start is called before the first frame update
    void Start()
    {
        Container.maxMagnetism = 20;
        Container.magnetism = 0;
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = PercentMagnetism();
        texte.text = Container.magnetism + "/" + Container.maxMagnetism;
    }

    public float PercentMagnetism()
    {
        return (float)Container.magnetism / (float)Container.maxMagnetism;
    }
    public void UpdateAmount(int amount)
    {
        if (Container.magnetism + amount < Container.maxMagnetism)
        {
            Container.magnetism += amount;
        }
        else
        {
            Container.magnetism = Container.maxMagnetism;
        }
    }

    public float GetValue()
    {
        return Container.magnetism;
    }
}
