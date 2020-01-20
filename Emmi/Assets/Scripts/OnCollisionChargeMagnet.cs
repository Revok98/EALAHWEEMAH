using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionChargeMagnet : MonoBehaviour
{
    public MagnetismManager mag;
    public Movement player;
    private float startPosRotate;
    private int nbiter = 0;
    float speed = 180f;
    private  Vector3 pos;
    private bool me = false;

    private void Start()
    {
        pos = transform.position;
    }
    private void Update()
    {
        if (!player.IsActiveMoving &&  me)
        {
            pos = transform.position;
            player.gameObject.transform.RotateAround(pos, Vector3.up, speed * Time.deltaTime);
            nbiter++;
            if (nbiter % 45 == 0)
            {
                mag.UpdateAmount(2);
            }
            if (nbiter > 225)
            {
                player.IsActiveMoving = true;
                me = false;
                Destroy(gameObject);
            }
        }
    }



    void OnTriggerStay(Collider collider)
    { 
        if (collider.tag == "Player" && Input.GetMouseButton(1))
        {
            me = true;
            pos = transform.position;
            player.IsActiveMoving = false;
            startPosRotate = Vector3.Angle(transform.position,collider.transform.position);

        }
    }
}
