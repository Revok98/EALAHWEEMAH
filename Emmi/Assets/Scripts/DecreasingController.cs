using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasingController : MonoBehaviour
{
    public Vector3 CurrentVolume;
    public float PourcentageToDecrease;
    Vector3 Vect;
    public float DeadUnder;
    void Start()
    {
        CurrentVolume = new Vector3(2f, 2f, 2f);
        this.transform.localScale = CurrentVolume;
        Vect = new Vector3(PourcentageToDecrease, PourcentageToDecrease, PourcentageToDecrease);

    }

    // Update is called once per frame
    void Update()
    {
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
