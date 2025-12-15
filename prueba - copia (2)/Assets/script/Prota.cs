using TMPro;

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
    public GameObject sombra;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Puntos = 0;
        rb =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del peeosnaje qwue sigue eld edo
        FingerMovement();
        //Movimiento en la pantalla tactil
       // ScreenBorderMovement();
        // el jugador toca la pantalla
        
        if (Input.GetKeyDown(KeyCode.D))
        {
             transform.Translate(velocidad * Time.deltaTime, 0, 0);
           //rb.linearVelocityX = velocidad;

        }
        

        if (Input.GetKeyDown(KeyCode.A))
        {
             transform.Translate(-velocidad * Time.deltaTime, 0, 0);
           //rb.linearVelocityX = -velocidad;
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

        if (collision.gameObject.tag == "rampa")
        {

            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Invoke("FinSalto", 0.5f);
            sombra.SetActive(true);
            velocidad = 0;
            transform.Translate(velocidad * Time.deltaTime, 0, 0);
           
            
        }
       
         

        
            if (collision.gameObject.tag == "moneda")
            {
            Destroy(collision.gameObject);
            Puntos++;
            Marcadorpuntos.text = ":" + Puntos;
            }
    }

    private void FingerMovement()
    {
        if (Input.touchCount > 0)
        {
            float FingerMovementX = Input.touches[0].deltaPosition.x;

            //movimiento (transform)
            transform.Translate(FingerMovementX * velocidad * Time.deltaTime, 0, 0);
            
        }




    }
    private void ScreenBorderMovement()
    {
        if (Input.touchCount > 0)
        {
            //para saber en que posicion de la x estaqmos tocando 
            float touchscreenpositionx = Input.touches[0].position.x;
            //para saber cual es el centro de la pantalla
            float screencenter = Screen.width / 2;
            if (touchscreenpositionx > screencenter)
            {

                transform.Translate(velocidad * Time.deltaTime, 0, 0);
            }
            if (touchscreenpositionx < screencenter)
            {

                transform.Translate(-velocidad * Time.deltaTime, 0, 0);
            }
        }




    }
    private void checkbestscore() 
    {//para guardar la maxikma puntuacion de manera local no de manera online 
        if(Puntos >=PlayerPrefs.GetInt("bestscore"))
        {
            //Guarda la maxima puntiacion en el computador 
            PlayerPrefs.SetInt("bestscore", Puntos);
            //bestscore = Puntos;
            PlayerPrefs.DeleteKey("bestscore");
        }
    
    }
    private void FinSalto()
    {

        transform.localScale = new Vector3(1, 1, 1);
        sombra.SetActive(false);
        velocidad = 4;
    }

    
} 
