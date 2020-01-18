using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasingController : MonoBehaviour
{
    Vector3 CurrentVolume;
    public float PourcentageToDecrease;
    Vector3 Vect;
    public float DeadUnder;
    // Start is called before the first frame update
    void Start()
    {
        CurrentVolume = this.transform.localScale;
        Vect = new Vector3(PourcentageToDecrease, PourcentageToDecrease, PourcentageToDecrease); 
    }

    // Update is called once per frame
    void Update()
    {
        CurrentVolume = CurrentVolume - Vect;
        this.transform.localScale = CurrentVolume;
    }

    public bool isTooSmall() {
        if (CurrentVolume.x<= DeadUnder) {
            return true;
        }

        return false;
    }
}
