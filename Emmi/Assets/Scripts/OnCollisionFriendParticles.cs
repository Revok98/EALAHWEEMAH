using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionFriendParticles : MonoBehaviour
{
    public EnergyManager ener;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            ener.UpdateAmount(0.5f);
        }
    }
}
