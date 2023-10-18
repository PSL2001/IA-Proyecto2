using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RobotController : MonoBehaviour
{
    private int m;
    private int r;
    private Rigidbody rb;
    public int vMovimiento;
    public int vRotacion;

    //Variable de vida
    public int HP;
    //Vector de la posicion inicial
    private Vector3 initialPos;
    //Vida inicial como referencia
    private int initialHP;
    //Movimiento inicial como referencia
    private int initialMovementSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = this.transform.position;
        initialHP = HP;
        initialMovementSpeed = vMovimiento;
    }

    // Update is called once per frame
    void Update()
    {
        m = 0;
        r = 0;

        if (Input.GetKey(KeyCode.A))
        {
            r = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            r = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m = -1;
        }
    }

    private void FixedUpdate()
    {
        Quaternion rotacion = Quaternion.Euler(this.transform.up * r * vRotacion * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * rotacion);

        rb.MovePosition(rb.position + this.transform.forward * m * vMovimiento * Time.fixedDeltaTime);
    }

    public void DealDamage()
    {
        //Quitamos vida
        HP--;
        // Quitamos movimiento
        vMovimiento--;
        //Reiniciamos la velocidad angular (para evitar mareos de control)
        rb.angularVelocity = Vector3.zero;

        //Si la vida llega a 0 devolvemos a la posicion inicial y reiniciamos stats
        if (HP == 0)
        {
            //rb.velocity = Vector3.zero

            //rb.ResetCenterOfMass();
            //rb.ResetInertiaTensor()

            this.transform.position = initialPos;
            HP = initialHP;
            vMovimiento = initialMovementSpeed;
        }
    }
}
