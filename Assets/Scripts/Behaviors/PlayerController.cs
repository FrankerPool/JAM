﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
    //variable encargada de gestionar la velocidad del jugador
    public float speed = 0.1f;
    //esta variable contiene el numero vidas
    private int lifes = 5;
    //instancia de gamemanager para acceder a los metodos
    private GameManager gameManagerInstancia;
    //texto que mostrara las vidas del jugador
    public Text lifesTxt;
    //Utilizamos un vector3 para obetener la posicion inicial
    private Vector3 startPosition;
    //esta instancia sirve para acceder a los metodos de los boosters
    private BoosterScript boosterScriptInstancia;
    //Esta variable sirve para acceder al animator del jugador para gersionar las animaciones
    private Animator animator;
    //aqui buscamos el objeto de tipo gamemanager para poder inicializarlo
    void Start(){
        boosterScriptInstancia = FindObjectOfType<BoosterScript>();
        gameManagerInstancia = FindObjectOfType<GameManager>();
    }
    //este metodo se encarga de cuando el jugador muere regresarlo al principio
    public void dead(){
        gameManagerInstancia.GameOver();
        this.transform.position = startPosition;
    }
    public void again(){
        gameManagerInstancia.Menu();
        this.transform.position = startPosition;
    }
    public void restLife(){
        this.lifes -= 1;
        print(lifes);
    }
    //porque ? el awake despierta antes que cualquier metodo
    void Awake(){
        startPosition = this.transform.position;  
        animator = GetComponent<Animator>();
    }
    //metod que gestiona el movimiento del jugador 10/09/20 aun este se mueve cuando esta en pausa se tiene que revisar a mas tardar para ma;ana si no seguir adelante si toma mas de un dia y dejar para luego
    public void movPc(){
        if(gameManagerInstancia.currentGameState == GameState.inGame){
            print("en juego");
            GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x,speed);
//            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            // transform.Translate (Vector3.up *1 * speed * Time.deltaTime);
            Vector2 movement = Vector2.zero;
            if(Input.GetKeyDown(KeyCode.A)){
                if(transform.position.x > -1.3f){
                    transform.position = new Vector2(transform.position.x - 1.3f, transform.position.y);
                    animator.SetBool("left",true);
                    animator.SetBool("right",false);
                    animator.SetBool("midle",false);
                }
            }

            if(Input.GetKeyDown(KeyCode.D)){
                if(transform.position.x < 1.3f){
                    animator.SetBool("right",true);
                    animator.SetBool("midle",false);
                    animator.SetBool("left",false);
                    transform.position = new Vector2(transform.position.x + 1.3f, transform.position.y);
                }
            }

            if(transform.position.x == 0.0f){
                animator.SetBool("midle",true);
                animator.SetBool("left",false);
                animator.SetBool("right",false);
            }

            animator.SetFloat("speed",Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y));
        }else{
            GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x,0);
        }
    }

    //este metodo sirve para mostrar las vidas del jugador
    public void showLifes(){
        lifesTxt.text = lifes.ToString();
    }
    //aun estoy probando esto /*10/10/20*/
    public void movMovil(){
        if(gameManagerInstancia.currentGameState == GameState.inGame){
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began){
                if (touch.position.x < Screen.width / 2 && transform.position.x > -0.3f)
                    transform.position = new Vector2(transform.position.x - 1.75f, transform.position.y);
                if (touch.position.x > Screen.width / 2 && transform.position.x < 0.3f)
                    transform.position = new Vector2(transform.position.x + 1.75f, transform.position.y);
            }
        }
    }

    //comprobar si esta vivo
    public void comprobateLifes(){
        if(lifes == 0){
            lose();
        }
    }
    //gameOver
    public void lose(){
        gameManagerInstancia.GameOver();
    }
    // Update is called once per frame
    void Update(){
        comprobateLifes();
        showLifes();
        movPc();
    }
    //para obtener la distancia rrecorrida
    public float getDistanceR(){
        float travelerDistance = Vector2.Distance(new Vector2(0,startPosition.y),new Vector2(0,this.transform.position.y));
        return travelerDistance;
    }
    //en caso de chocar y tener aun mas de 0 vidas restara en caso contrario se muere
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Dead"){
            restLife();
        }
        if(other.gameObject.tag == "Booster"){
            print("si");
            if(other.gameObject.name == "bota"){
                //no mucho que explicar ya estas comentados en su respectiva clase xd
                print("si bota");
                boosterScriptInstancia.boosterVelocity(2.0f,5.0f,this.GetComponent<Rigidbody2D>(),speed);
            }
            if(other.gameObject.name == "cruz"){
                //lo mismo solo que en este caso this.gameobject ser refiere a este objeto
                boosterScriptInstancia.boosterInvisible(4.0f,this.gameObject);
            }
            if(other.gameObject.name == ""){
                //no recuerdo este xd pero creo que ya lo hize sin querer
            }
        }
    }
}
