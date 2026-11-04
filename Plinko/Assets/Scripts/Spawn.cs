using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject esfera;

    [Header("Propiedades de la Esfera:")]
    [Space(5)]

    [Header("Distancia de Spawn")]
    [SerializeField] float yPosition;

    [SerializeField] float distanciaDesdeCamara = 10f;

    public Vector3 areaDeAparicion = new Vector3(8f, 1f, 1f);

    [Header("Velocidad de la esfera al moverse con teclado")]
    [SerializeField] public float velocidadMovimiento = 5f;

    [Header("Fuerza del salto al utilizar el espacio")]
    [SerializeField]  float fuerzaSalto = 7f;

    private GameObject esferaActual;

    [Space(10)]
    public AudioSource sfxAudio;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            esferaActual = Instantiate(esfera);

            Vector3 posicionMouseConProfundidad = Input.mousePosition;
            posicionMouseConProfundidad.z = distanciaDesdeCamara;

            esferaActual.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(posicionMouseConProfundidad).x, yPosition, 0);

            sfxAudio.Stop();

            sfxAudio.Play();

        }

        if (esferaActual != null)
        {
            float movimientoX = Input.GetAxis("Horizontal");

            esferaActual.transform.Translate(Vector3.right * movimientoX * velocidadMovimiento * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody rb = esferaActual.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, areaDeAparicion);
    }
}
