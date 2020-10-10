using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallBack : MonoBehaviour{
    //esta variable referencia si ya ha sido actualizado la ecena
    private bool isFirstUpdate = true;
    //en cuanto este la carga
    private void Update(){
        if(isFirstUpdate){
            isFirstUpdate = false;
            Loader.LoaderCallBack();
        }       
    }
}
