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
    public bool IsActiveMoving = true;

    public int maxVelocityChange = 10;
    private Vector3 forward;
    private Vector3 right;
    // Start is called before the first frame update
    void Start()
    {
        /*forward = Camera.main.transform.forward;
        right = Quaternion.Euler(new Vector3(0,90,0))*forward;
        forward.y = 0;
        movement = Vector3.Normalize(forward);*/


        playerRigidbody = GetComponent<Rigidbody>();
        targetPosition = playerRigidbody.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActiveMoving)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (!playerRigidbody.useGravity) {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
            Move(h, v);
        }
    }

    public void Moving(float h, float v) {
        movement = new Vector3(h, 0, v);
        Vector3 rightm = right * speed * Time.deltaTime * h;
        Vector3 forwardm = forward * speed * Time.deltaTime * v;
        Vector3 heading = Vector3.Normalize(rightm + forwardm);
        transform.forward = heading;
        transform.position += rightm;
        transform.position += forwardm;
    }

    public void Move(float h, float v) {
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
            playerAscencion = true;
            descending = false;
            mult = 5;
        }
        playerRigidbody.MovePosition(transform.position + movement);
    }

}
