using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    //Instancia de la bala
    public GameObject bullet;
    //Instancia de la boquilla del cañon
    private GameObject boquilla;
    // Start is called before the first frame update
    void Start()
    {
        //la boquilla está en el padre en su segunda posicion y este tiene la boquilla como primer hijo
        boquilla = this.transform.GetChild(1).transform.GetChild(0).transform.gameObject;
        //Corrutina de Disparo
        StartCoroutine("Disparar");
    }

    IEnumerator Disparar()
    {
        while (true)
        {
            float randomCooldown = Random.Range(0.5f, 4.0f);
            Debug.Log(randomCooldown);
            yield return new WaitForSeconds(randomCooldown);

            GameObject bala = Instantiate(bullet, boquilla.transform.position, Quaternion.identity);
            bala.GetComponent<Rigidbody>().AddForce(boquilla.transform.up * 400);
        }
    }
}
