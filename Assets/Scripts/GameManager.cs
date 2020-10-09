using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//este es un enum contiene los estados del juego que se encargaran de llevar el juego
public enum GameState{
    menu,inGame,GameOver,GamePause
}

public class GameManager : MonoBehaviour{
    //Necesitaremos los cambas los cuales seran para que se muestren desde el menu hasta la pantalla de gameover
    public Canvas canvasGameover,canvasMenu,canvasInGame,canvasPause,canvasConfirm;
    //estas variables mostraran el tiempo y la cuenta regresiva
    public Text regresiveTxt,cronomeTxt;
    //de igual modo tenemos que inicializar una variable para gestionar los estados de la partida
    public GameState currentGameState = GameState.menu;
    //estas se encargan de gestionar el tiempo de las cuentas
    public float timeLeft = 3.0f;
    public float timeGame = 30.0f;
    private bool go = false;
    
    //ahora siguen los metodos que nos muestran los menus y todo eso
    //este metodo muestra la pantalla de menu
    public void showMenu(){
        canvasMenu.enabled = true;
        canvasGameover.enabled = false;
        canvasInGame.enabled = false;
        canvasPause.enabled = false;
    }
    //este metodo muestra la pantalla de pausa
    public void inPause(){
        canvasPause.enabled =true;
        canvasGameover.enabled = false;
        canvasMenu.enabled = false;
        canvasInGame.enabled = false;
    }
    //este metodo muestra la pantalla en juego
    public void inGame(){
        canvasInGame.enabled = true;
        canvasGameover.enabled = false;
        canvasMenu.enabled = false;
        canvasPause.enabled = false;
    }
    //este metodo muestra la pantalla en game over
    public void gameOver(){
        canvasGameover.enabled = true;
        canvasInGame.enabled = false;
        canvasMenu.enabled = false;
        canvasPause.enabled = false;
    }
    //este metodo es para mostrar la advertencia de confirmarcion
    public void confirmar(){
        canvasConfirm.enabled = true;
        canvasInGame.enabled = false;
        canvasGameover.enabled = false;
        canvasMenu.enabled = false;
        canvasPause.enabled = false;
    }
    //este metodo se encarga de ocultar el panel de advertencia
    public void hideConfirmar(){
        canvasMenu.enabled = true;
        canvasConfirm.enabled = false;
        canvasInGame.enabled = false;
        canvasGameover.enabled = false;
        canvasPause.enabled = false;
    }
    //este metodo muestra el conteo de 3,2,1,go!
    public void goTimer(){
        canvasMenu.enabled = false;
        canvasConfirm.enabled = false;
        canvasInGame.enabled = true;
        timeLeft -= Time.deltaTime;
        regresiveTxt.text = (timeLeft).ToString("0");
        if (timeLeft < 0){
            regresiveTxt.enabled = false;
            showTimeGame();
        }
    }
    //este metodo cuenta de 60 y resta hasta llegar a 0
    public void showTimeGame(){
        InGame();
        cronomeTxt.enabled = true;
        timeGame -= Time.deltaTime;
        cronomeTxt.text = (timeGame).ToString("0");
        if (timeGame < 0){
            cronomeTxt.enabled = false;
            gameOver();
        }
    }
    //este metodo cambia el estadp de go!
    public void goGame(){
        go = true;
    }
    //este metodo cambia el estado de go! para reiniciar la partida
    public void noGo(){
        go = false;
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
    //al iniciar el juego es cambiado a en menu
    void Start(){
        setGameState(GameState.menu);
    }
    //cambia los estados del juego
    public void setGameState(GameState newGameState){
        if(newGameState == GameState.menu){
            showMenu();
        }else if(newGameState == GameState.inGame){
            inGame();
        }else if(newGameState == GameState.GameOver){
            gameOver();
        }else if(newGameState == GameState.GamePause){
            inPause();
        }
        this.currentGameState = newGameState;
    }

    // Update is called once per frame
    void Update(){
        if(go == true){
            goTimer();
        }
    }
}
