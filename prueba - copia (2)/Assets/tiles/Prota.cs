using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]
public class NewMonoBehaviourScript : MonoBehaviour
{

    Rigidbody2D rb;
    float velocidad = 4.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //condicion que indica que el persoanje se muecve pa lña derecha

        if (Input.GetKeyDown(KeyCode.D))
        {
           // transform.Translate(velocidad * Time.deltaTime, 0, 0);
           rb.linearVelocityX = velocidad;

        }
        else if (Input.GetKeyUp (KeyCode.D))//detecta que ya no esta tocando la tecla
        {
            rb.linearVelocityX= 0; // cuando ya no lo esta tocando y es 0
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // transform.Translate(-velocidad * Time.deltaTime, 0, 0);
            rb.linearVelocityX = -velocidad;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.linearVelocityX = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Suelo")
        {
        
         Destroy(gameObject);
        
        
        }
    }
}
