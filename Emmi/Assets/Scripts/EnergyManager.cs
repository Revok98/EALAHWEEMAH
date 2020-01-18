using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergyManager : MonoBehaviour
{
    public Image Bar;
    public float Fill;
    public DecreasingController volume;

    // Start is called before the first frame update
    void Start()
    {
        Fill = 1f;
        StartCoroutine(LoseEnergy());
        volume.transform.localScale = volume.getVolume();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Fill;
    }

    IEnumerator LoseEnergy()
    {
        while (true)
        { 
            if (Fill > 0)
            {
                Fill -= volume.PercentToDecrease();
                volume.setVolume(volume.getVolume() - volume.getVect());
                volume.transform.localScale = volume.getVolume();
                yield return new WaitForSeconds(1);
            }
            else
            {
                SceneManager.LoadScene("GameOver");
                yield return null;
            }
        }
    }

    public void UpdateAmount(float amount)
    {
        Fill += amount;
    }
}



