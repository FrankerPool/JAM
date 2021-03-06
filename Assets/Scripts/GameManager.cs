﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//este es un enum contiene los estados del juego que se encargaran de llevar el juego
public enum GameState{
    menu,inGame,GameOver,GamePause,GameEnd,CinematicTime
}

public class GameManager : MonoBehaviour{
    //Necesitaremos los cambas los cuales seran para que se muestren desde el menu hasta la pantalla de gameover
    public Canvas canvasGameover,canvasMenu,canvasInGame,canvasPause,canvasConfirm,canvasEnd,canvasPlay;
    //estas variables mostraran el tiempo y la cuenta regresiva
    public Text regresiveTxt,cronomeTxt;
    //de igual modo tenemos que inicializar una variable para gestionar los estados de la partida
    public GameState currentGameState = GameState.menu;
    //estas se encargan de gestionar el tiempo de las cuentas
    public float timeLeft = 3.0f;
    public float timeGame = 30.0f;
    //esta variable se encarga de acceder alos metodos del jugador
    PlayerController playerControllerInstancia;
    //estas contiene ambos jugadores
    public GameObject playerGirl,playerBoy;
    //para ingresar al metod de sonido
    private ManagerAudio managerAudioInstancia;
    //
    private Obstacule obstaculeInstancia;
    //
    private BoosterScript boosterScriptInstancia;
    //
    public Image boyLife,girlLife;
    //
    public Image winH,winM;
    //ahora siguen los metodos que nos muestran los menus y todo eso
    //este metodo muestra la pantalla de menu
    public void showMenu(){
        canvasMenu.enabled = true;
        canvasGameover.enabled = false;
        canvasInGame.enabled = false;
        canvasPause.enabled = false;
        canvasEnd.enabled = false;
    }
    //este metodo muestra la pantalla de pausa
    public void inPause(){
        canvasPause.enabled =true;
        canvasGameover.enabled = false;
        canvasMenu.enabled = false;
        canvasInGame.enabled = false;
        canvasEnd.enabled = false;
    }
    //este metodo muestra la pantalla en juego
    public void inGame(){
        canvasInGame.enabled = true;
        canvasGameover.enabled = false;
        canvasEnd.enabled = false;
        canvasMenu.enabled = false;
        canvasPause.enabled = false;
        managerAudioInstancia.zone1Soung();
    }
    //este metodo muestra la pantalla en game over
    public void gameOverScreen(){
        canvasGameover.enabled = true;
        canvasInGame.enabled = false;
        canvasMenu.enabled = false;
        canvasPause.enabled = false;
        canvasEnd.enabled = false;
    }
    //este metodo es para mostrar la advertencia de confirmarcion
    public void confirmar(){
        canvasConfirm.enabled = true;
        canvasInGame.enabled = false;
        canvasGameover.enabled = false;
        canvasMenu.enabled = false;
        canvasPause.enabled = false;
        canvasEnd.enabled = false;
    }
    //este metodo se encarga de ocultar el panel de advertencia
    public void hideConfirmar(){
        canvasMenu.enabled = true;
        canvasConfirm.enabled = false;
        canvasInGame.enabled = false;
        canvasGameover.enabled = false;
        canvasPause.enabled = false;
        canvasEnd.enabled = false;
    }
    public void endGame(){
        canvasEnd.enabled = true;
        canvasMenu.enabled = false;
        canvasConfirm.enabled = false;
        canvasInGame.enabled = false;
        canvasGameover.enabled = false;
        canvasPause.enabled = false;
    }
    //esto reinica todo como al principio
    public void playAgain(){
        regresiveTxt.enabled = true;
        this.timeGame = 60;
        playerControllerInstancia.again();
        managerAudioInstancia.pushButton();
    }
    //este metodo muestra el conteo de 3,2,1,go!
    IEnumerator goTimerT(){
        canvasMenu.enabled = false;
        canvasConfirm.enabled = false;
        canvasInGame.enabled = true;
        yield return new WaitForSeconds(1.0f);
        regresiveTxt.text = "3";
        yield return new WaitForSeconds(1.0f);
        regresiveTxt.text = "2";
        yield return new WaitForSeconds(1.0f);
        regresiveTxt.text = "1";
        yield return new WaitForSeconds(1.0f);
        regresiveTxt.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        regresiveTxt.enabled = false;
        InGame();
        showTimeGame();
    }
    //llamo a la corutina en este metodo
    public void goTimer(){
        StartCoroutine(goTimerT());
        //esto si funciona pero su uso es muchoa mas complejo de lo que parece
        // canvasMenu.enabled = false;
        // canvasConfirm.enabled = false;
        // canvasInGame.enabled = true;
        // timeLeft -= Time.deltaTime;
        // regresiveTxt.text = (timeLeft).ToString("0");
        // if (timeLeft < 0){
        //     regresiveTxt.enabled = false;
        //     showTimeGame();
        // }
    }
    //este metodo cuenta de 60 y resta hasta llegar a 0
    public void showTimeGame(){
         if(currentGameState == GameState.inGame){
            cronomeTxt.enabled = true;
            timeGame -= Time.deltaTime;
            cronomeTxt.text = (timeGame).ToString("0");
                if (timeGame < 0){
                cronomeTxt.enabled = false;
                GameOver();
            }
        }
    }
    //este metodo cambia el estado enum del juego a pause
    public void InPause(){
        setGameState(GameState.GamePause);
    }
    //este metodo cambia el estado a ingame
    public void InGame(){
        setGameState(GameState.inGame);
    }
    //este metodo cambia el estado del juego a menu
    public void Menu(){
        setGameState(GameState.menu);
    }
    //este metodo cambia el estado del juego a game over
    public void GameOver(){
        setGameState(GameState.GameOver);
    }
    //
    public void EndGame(){
        setGameState(GameState.GameEnd);
    }
    //metod para el sonido del boton
    public void click(){
        managerAudioInstancia.pushButton();
    }
    //metod para seleccionar al chico
    public void chooceGirl(){
        managerAudioInstancia.pushButton();
        playerGirl.gameObject.SetActive(true);
        playerBoy.gameObject.SetActive(false);
        winH.enabled = false;
        winM.enabled = true;
        girlLife.enabled = true;
        boyLife.enabled = false;
    }

    public void chooceBoy(){
        winH.enabled = true;
        winM.enabled = false;
        managerAudioInstancia.pushButton();
        playerBoy.gameObject.SetActive(true);
        playerGirl.gameObject.SetActive(false);
        boyLife.enabled = true;
        girlLife.enabled = false;
    }
    //metodo para seleccionar a la chica
    //al iniciar el juego es cambiado a en menu
    void Start(){
        boosterScriptInstancia = FindObjectOfType<BoosterScript>();
        obstaculeInstancia = FindObjectOfType<Obstacule>();
        managerAudioInstancia = FindObjectOfType<ManagerAudio>();
        playerControllerInstancia = FindObjectOfType<PlayerController>();
        setGameState(GameState.menu);
        chooceBoy();
    }
    //cambia los estados del juego
    public void setGameState(GameState newGameState){
        if(newGameState == GameState.menu){
            canvasPlay.enabled = true;
            showMenu();
        }else if(newGameState == GameState.inGame){
            inGame();
        }else if(newGameState == GameState.GameOver){
            gameOverScreen();
        }else if(newGameState == GameState.GamePause){
            inPause();
        }else if(newGameState == GameState.GameEnd){
            endGame();
        }
        this.currentGameState = newGameState;
    }
    public void play(){
        canvasPlay.enabled = false;
        managerAudioInstancia.pushButton();
    }
    // Update is called once per frame
    void Update(){
        showTimeGame();
    }
}
