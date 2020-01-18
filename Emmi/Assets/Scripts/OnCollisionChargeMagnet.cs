using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionChargeMagnet : MonoBehaviour
{
    public MagnetismManager mag;

    void OnTriggerStay(Collider collider)
    { 
        if (collider.tag == "Player" && Input.GetKey("space"))
        {
            mag.UpdateAmount(1);
        }
    }
}
