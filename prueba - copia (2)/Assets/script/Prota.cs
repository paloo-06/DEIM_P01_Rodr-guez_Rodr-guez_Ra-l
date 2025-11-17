using TMPro;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent (typeof(Rigidbody2D))]
public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField]  //para mostrar algo en el impector que esta oculto 
    private int bestscore; //variable para tener la maxima puntuación
    public TMP_Text Marcadorpuntos;
    public static int Puntos =5;
    Rigidbody2D rb;
    float velocidad = 4.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Puntos = 0;
        rb =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // condicion que indica que el persoanje se muecve pa lña derecha

        if (Input.GetKeyDown(KeyCode.D))
        {
             transform.Translate(velocidad * Time.deltaTime, 0, 0);
           rb.linearVelocityX = velocidad;

        }
        else if (Input.GetKey(KeyCode.D))//detecta que ya no esta tocando la tecla
        {
            rb.linearVelocityX = 0; // cuando ya no lo esta tocando y es 0
        }

        if (Input.GetKeyDown(KeyCode.A))
       {
             transform.Translate(-velocidad * Time.deltaTime, 0, 0);
           rb.linearVelocityX = -velocidad;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocityX = 0;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            checkbestscore();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Suelo")
        {
        
         Destroy(gameObject);
        
        
        }
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "moneda")
        {
            Destroy(collision.gameObject);
            Puntos ++;
            Marcadorpuntos.text = ":" + Puntos;
        }
    }
    private void checkbestscore() 
    {//para guardar la maxikma puntuacion de manera local no de manera online 
        if(Puntos >=PlayerPrefs.GetInt("bestscore"))
        {
            //Guarda la maxima puntiacion en el computador 
            PlayerPrefs.SetInt("bestscore", Puntos);
            //bestscore = Puntos;
        }
    
    }

    
} 
