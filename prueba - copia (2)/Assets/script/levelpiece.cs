using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class levelpiece : MonoBehaviour
{
    public float velocidad = 5f;

    public float tamaño ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocidad * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limite")
        {

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "transport")
        {
            creadorniveles.Añadirpieza(transform.position - new Vector3(0,tamaño,0));
            //Instantiate(gameObject,new Vector3(0,-21,0),Quaternion.identity);

        }
    }    
    
  

}
   
