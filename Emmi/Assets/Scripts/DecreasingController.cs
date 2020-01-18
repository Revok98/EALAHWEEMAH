using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasingController : MonoBehaviour
{
    public Vector3 CurrentVolume;
    public float PourcentageToDecrease;
    public GameObject Orb;
    Vector3 Vect;
    public float DeadUnder;
    void Start()
    {
        CurrentVolume = new Vector3(1f, 1f, 1f);
        this.transform.localScale = CurrentVolume;
        Vect = new Vector3(PourcentageToDecrease, PourcentageToDecrease, PourcentageToDecrease);

    }

    // Update is called once per frame
    void Update()
    {
        int h = EnergyManager.health;
        int mh = EnergyManager.maxHealth;
        int volume = h * 22000 / mh;
        this.GetComponent<AudioLowPassFilter>().cutoffFrequency = volume;
        Orb.transform.localScale = CurrentVolume;
        //Debug.Log(this.GetComponent<AudioLowPassFilter>().cutoffFrequency);
        //Debug.Log(CurrentVolume);
        //Debug.Log(Vect.x);
        //Debug.Log((CurrentVolume - Vect).x);
    }

    public bool isTooSmall() {
        if (CurrentVolume.x<= DeadUnder) {
            return true;
        }

        return false;
    }

    public Vector3 getVolume()
    {
        return CurrentVolume;
    }
    public void setVolume(Vector3 vect)
    {
        CurrentVolume = vect;
    }

    public Vector3 getVect()
    {
        return Vect;
    }

    public float PercentToDecrease()
    {
        return PourcentageToDecrease;
    }
}
