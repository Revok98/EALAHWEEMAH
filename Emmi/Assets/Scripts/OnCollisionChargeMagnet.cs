using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (nbiter % 45 == 0)
            {
                mag.UpdateAmount(1);
            }
            if(nbiter > 450)
            {
                player.IsActiveMoving = true;
                Destroy(gameObject);
            }
        }
    }



    void OnTriggerStay(Collider collider)
    { 
        if (collider.tag == "Player" && Input.GetMouseButton(1))
        {
            player.IsActiveMoving = false;
            startPosRotate = Vector3.Angle(transform.position,collider.transform.position);

        }
    }
}
