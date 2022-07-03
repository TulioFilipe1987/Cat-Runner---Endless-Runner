using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockScript : MonoBehaviour
{
    [HideInInspector]
    public bool moveLikeYoyo ;


    
    void Start(){
        if (moveLikeYoyo){
            transform.DOLocalMoveY(-0.1f, 0.5f).SetLoops(-1, LoopType.Yoyo); // yoyo efeito

        }
        
    }

    void FallBlock(){  // INVOCAR EESE COMANDO 

        CancelInvoke("FallBlock");
        transform.DOLocalMoveY(-3f, 0.5f);
        Destroy(gameObject, 0.5f);
    }

     void OnCollisionEnter(Collision target){
        if(target.gameObject.name == "Cat") {

           if (moveLikeYoyo) {
           Invoke("FallBlock", 0.25f);
           }

            //Invoke ("FallBlock",0.25f);

            
        }
        
    }



}
