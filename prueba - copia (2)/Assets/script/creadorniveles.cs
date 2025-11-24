using UnityEngine;
using System.Collections.Generic;

public class creadorniveles : MonoBehaviour
{
    private static creadorniveles instance; //se crea un static creadorniveles para generar niveles
    public List<GameObject> piece;   //referencia a la pieza
    private void Awake()
    {
        //inicializacion del singleton
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Añadirpieza(Vector3 spawnposition)
    {
        Instantiate(instance.piece[Random.Range(0,instance.piece.Count)], spawnposition, Quaternion.identity);
    }
}
