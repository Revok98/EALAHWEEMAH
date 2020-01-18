using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public void UpdateRange(int value)
    {
        Light lt = this.gameObject.GetComponent<Light>();
        lt.range = value;
    }
}
