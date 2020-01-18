using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionFriendParticles : MonoBehaviour
{
    public EnergyManager ener;
    public int Heal;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            ener.UpdateAmount(Heal);
            Destroy(this.gameObject);
        }
    }
}
