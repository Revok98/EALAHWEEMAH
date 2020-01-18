using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class OnCollisionChargeMagnet : MonoBehaviour
{
    public MagnetismManager mag;
    public Movement player;
    private float startPosRotate;
    private int nbiter = 0;


    private void Update()
    {
        if (!player.IsActiveMoving)
        {
            player.gameObject.transform.RotateAround(transform.position, Vector3.up, 90f * Time.deltaTime);
            nbiter++;
            Debug.Log(startPosRotate - Vector2.Angle(transform.position, player.transform.position));
            if(nbiter > 450)
            {
                player.IsActiveMoving = true;
            }
        }
    }



    void OnTriggerStay(Collider collider)
    { 
        if (collider.tag == "Player" && Input.GetKey("space"))
        {
            player.IsActiveMoving = false;
            mag.UpdateAmount(1);
            startPosRotate = Vector3.Angle(transform.position,collider.transform.position);

        }
    }
}
