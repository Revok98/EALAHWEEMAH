using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code produit en partie par Unity et remodelé par Alexandre Rousseau. Réutilisation avec son aimable accord. 
public class Movement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    private Rigidbody playerRigidbody;
    public float levitationHeight;
    public float elevatingForce;
    private float tosin;
    private float targetPosition;
    private bool descending = false;
    private bool playerAscencion = true;
    public float amplitude;
    private bool mont;
    private int mult = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        targetPosition = playerRigidbody.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
    }

    void Move(float h, float v) {
        movement.Set(h, 0f, v);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        float toAdd = 0.0f;
        if (Physics.Raycast(transform.position, -transform.up, out hit, levitationHeight+amplitude))
        {
            if (playerRigidbody.useGravity) {
                descending = true;
            }
            /*if (descending && playerRigidbody.position.y <= targetPosition) {
                toAdd = 0.01f;
            }*/
            playerRigidbody.useGravity = false;
            if (!descending)
            {
                if (playerAscencion)
                {
                    toAdd = 0.01f * mult;
                    mult = 1;
                }
                else
                {
                    toAdd = -0.01f * mult;
                    mult = 1;
                }
                /*if (hit.distance < (levitationHeight - amplitude))
                {
                    Debug.Log(playerRigidbody.useGravity);
                    toAdd = (levitationHeight - amplitude) - hit.distance;
                    targetPosition += toAdd;
                    playerAscencion = true;
                    toAdd = toAdd + 0.01f;
                }*/
            }
            /*elevation = targetPosition - hit.distance - 1;
            float diff1 = Mathf.Sin(tosin);
            tosin = tosin + 0.1f;
            float diff2 = Mathf.Sin(tosin);
            diff = diff2 - diff1;
            this.playerRigidbody.AddForce(transform.up * (elevatingForce));// (hit.distance / 2));*/
        }
        else
        {
            targetPosition = playerRigidbody.position.y;
            playerRigidbody.useGravity = true;
            toAdd = 0f;
        }

        movement = Camera.main.transform.TransformDirection(movement).normalized;//Penser à changer en fonction de la position de la caméra 
        movement = movement * speed * Time.deltaTime;
        movement.y = toAdd;
        if (hit.distance >= levitationHeight + amplitude / 2 && !descending)
        {
            mult = 5;
            playerAscencion = false;
        }
        if (hit.distance <= levitationHeight - amplitude / 2)
        {
            //Debug.Log(hit.distance);
            playerAscencion = true;
            descending = false;
            mult = 5;
        }
        playerRigidbody.MovePosition(transform.position + movement);
    }

}
