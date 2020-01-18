using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public void UpdateRateOverTime(int value)
    {
        ParticleSystem ps = this.gameObject.GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.rateOverTime = value;
    }
}
