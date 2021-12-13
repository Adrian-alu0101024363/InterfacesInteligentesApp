using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometro : MonoBehaviour
{
  private Rigidbody rb;
  private float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del móvil
        Vector3 tilt = Input.acceleration;
        //Cambiar a landscape
        tilt = Quaternion.Euler(90,0,0)* tilt;
        rb.AddForce(tilt * speed);
    }
}
