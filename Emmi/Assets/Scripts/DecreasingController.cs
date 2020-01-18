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
        CurrentVolume = Vect;
    }

    public Vector3 getVect()
    {
        return Vect;
    }
}
