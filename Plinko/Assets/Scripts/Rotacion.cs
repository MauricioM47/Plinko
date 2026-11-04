using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidad = 100f;

    public Vector3 ejeDeRotacion = new Vector3(1f, 0f, 0f);

    void Update()
    {
        transform.Rotate(ejeDeRotacion * velocidad * Time.deltaTime);
    }
}
