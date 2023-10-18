using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclecontroller : MonoBehaviour
{
    //Posicion Inicial Z
    public float initialZPosition;
    //Posicion Final Z
    public float finalZPosition;
    //El sentido del transporte si va a izquierda o derecha
    public int sentido;
    //La velocidad a la que va
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeSpeed");
    }

    IEnumerator ChangeSpeed()
    {
        while (true)
        {
            float randomTime = Random.Range(2.0f, 8.0f);
            yield return new WaitForSeconds(randomTime);
            speed = Random.Range(1.0f, 5.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z <= initialZPosition && sentido == -1)
        {
            sentido = 1;
        }
        else if (this.transform.position.z >= finalZPosition && sentido == 1)
        {
            sentido = -1;
        }
        this.transform.position = this.transform.position + this.transform.forward * sentido * speed * Time.deltaTime;
    }
}
