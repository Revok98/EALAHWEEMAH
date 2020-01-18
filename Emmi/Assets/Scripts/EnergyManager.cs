using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                Fill -= 0.01f;
                /*volume.setVolume(volume.getVolume() - volume.getVolume());
                volume.transform.localScale = volume.getVolume();*/
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }
    }
}



