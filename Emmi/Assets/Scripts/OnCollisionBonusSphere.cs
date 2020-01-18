using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionBonusSphere : MonoBehaviour
{
    public EnergyManager ener;
    public int BonusHealth;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            ener.IncreseMaxHealth(BonusHealth);
            Destroy(this);
        }
    }
}
