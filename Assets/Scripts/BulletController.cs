using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyBullet", 2.0f);
    }

    //Evento que se activa cuando dos rigidbody entran en contacto
    private void OnCollisionEnter(Collision collision)
    {
        //Primero comprueba con que he chocado
        if (collision.gameObject.tag == "Player") 
        {
            //Hemos chocado con el jugador, quitamos vida
            collision.gameObject.GetComponent<RobotController>().DealDamage();
            //Eliminamos la bala
            this.destroyBullet();
        }
    }

    private void destroyBullet()
    {
        Destroy(this.gameObject);
    }
}
