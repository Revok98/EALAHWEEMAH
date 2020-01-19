using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public int circleRadius;
    Vector3 truePosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        truePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 diff = player.GetComponent<Rigidbody>().transform.position - truePosition;
        if (Mathf.Pow(diff.x,2) + Mathf.Pow(diff.z,2) <= circleRadius) {
            Move();
        }
    }
    private void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector3.MoveTowards(transform.position, player.GetComponent<Rigidbody>().transform.position, speed);
    }
}
