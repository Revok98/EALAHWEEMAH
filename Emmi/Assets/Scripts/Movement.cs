using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code produit en partie par Unity et remodelé par Alexandre Rousseau. Réutilisation avec son aimable accord. 
public class Movement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    private Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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
        movement = Camera.main.transform.TransformDirection(movement).normalized;//Penser à changer en fonction de la position de la caméra 
        movement.y = 0.0f;
        movement = movement * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
