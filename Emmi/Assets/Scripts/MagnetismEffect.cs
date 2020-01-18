using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetismEffect : MonoBehaviour
{
    public float speed;
    public void effect(Transform Player)
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed);
    }
}
