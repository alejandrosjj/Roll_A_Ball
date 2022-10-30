using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;
    public float threshold = -50f;
    public float jumpForce = 8f;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject btnSalir;
    public GameObject btnJugarReset;

    private int count;
   

    private float xInput;
    private float zInput;
    private AudioSource coin;
    bool  grounded; //Variable para que solo pueda saltar si detecta el suelo

   

    // Awake es un metodo que se ejecuta antes que el Start
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coin = GetComponent<AudioSource>();
        grounded = false;
        winTextObject.SetActive(false);
        btnJugarReset.SetActive(false);
        btnSalir.SetActive(false);
    }

    private void Start()
    {
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0, zInput) * moveSpeed);


        if (transform.position.y < threshold)
        {
            Reset();
        }

        if(Input.GetButtonDown("Jump") && grounded == true){
            Jump();
        }
       
       
    }


    private void Jump()
    {
        grounded = false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            

            coin.Play();
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
           
            
            

        }

        if (other.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }

        if (other.gameObject.CompareTag("Ground2"))
        {
            winTextObject.SetActive(true);
            btnSalir.SetActive(true);
            btnJugarReset.SetActive(true);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Reset();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }

        if (collision.gameObject.CompareTag("Ground2"))
        {
            grounded = true;
            
        }
    }

    private void Reset()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        count = 0;
        SetCountText();

       /* if (transform.position.y < threshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        

        
    }

    public void jugarDenuevo()
    {
        SceneManager.LoadScene(1); //Empieza en el nivel 1
    }


    public void Quit()
    {
        MainMenu menu = new MainMenu();
        menu.QuitGame(); //Ingresa al MainMenu para ejecutar el metodo QuitGame y salir del juego
    }

    
    


}
