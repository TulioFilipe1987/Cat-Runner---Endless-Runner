using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 0.3f, height =  0.5f;

    private BlockManager blockManager;

    [SerializeField]
    private AudioClip catDie;
    private AudioSource audioManager;

    private Animator anim;

    ArrayList keyArray = new ArrayList();

    private bool isDead;   // falso ou verdade

    private GameObject waterFX; //  não funciona POR NAO TER O EFEITO

    void Awake() {

        blockManager = GameObject.Find("Block Manager").GetComponent<BlockManager>();
        anim = GetComponentInChildren<Animator>();
        audioManager = GetComponent<AudioSource>();

        waterFX = GameObject.Find("BigSplash_Size_A");
        waterFX.SetActive(false);



        

        // later on here we will code the water FX

        
    }

    void Start(){

        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
    
    }



  
    void Update(){
        
        if (!isDead  && blockManager.catLandedBlock != null){
             CheckInpunt();

        }


        if (transform.position.y < 0) { /// exlosiation water 
            if (!waterFX.activeInHierarchy){
                audioManager.clip = catDie;
                audioManager.Play();

                LeanTween.rotateAroundLocal(gameObject,Vector3.left, 90f ,0.5f);
                // GetComponent<>
                isDead = true;

                waterFX.SetActive(true);
                waterFX.transform.position = new Vector3(transform.position.x, -0.5f,
                    transform.position.z);




            }
                    

        }
         
                
                //GetComponent<BoxCollider>().isTrigger = true;
               

                


            
            
           
        
    }

    void CheckInpunt(){

        if (Input.GetKeyDown(KeyCode.UpArrow))
            keyArray.Add(KeyCode.UpArrow);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            keyArray.Add(KeyCode.DownArrow);
 

        if (Input.GetKeyDown(KeyCode.RightArrow))
            keyArray.Add(KeyCode.RightArrow);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            keyArray.Add(KeyCode.LeftArrow);


        if(keyArray.Count > 0){

            MoveTheCat();

            keyArray.RemoveAt(0);
        }


    }

    void MoveTheCat()
    {

        KeyCode key = (KeyCode)keyArray[0];

        if (key == KeyCode.UpArrow){
            audioManager.Play();
            anim.Play("ready");

            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y,
                 transform.position.z + 1f);

            transform.DOJump(pos, height, 1 , speed);

            blockManager.LeaveLandedBlock(); // 1
            anim.SetTrigger("jump");

        }

        // segundo

        if (key == KeyCode.DownArrow){
            audioManager.Play();
            anim.Play("ready");

            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y,
                 transform.position.z - 1f);

            transform.DOJump(pos, height, 1, speed);

            blockManager.LeaveLandedBlock();//2
            anim.SetTrigger("jump");

        }

        // terceiro  

        if (key == KeyCode.RightArrow){
            audioManager.Play();
            anim.Play("ready");

            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            Vector3 pos = new Vector3(transform.position.x + 1f, transform.position.y,
                 transform.position.z);

            transform.DOJump(pos, height, 1, speed);

            blockManager.LeaveLandedBlock(); //3
            anim.SetTrigger("jump");

        }

        // quarto

        if (key == KeyCode.LeftArrow){
            audioManager.Play();
            anim.Play("ready");

            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            Vector3 pos = new Vector3(transform.position.x - 1f, transform.position.y,
                 transform.position.z + 1f);

            transform.DOJump(pos, height, 1, speed);

            blockManager.LeaveLandedBlock(); //4 ATIVOU ?
            anim.SetTrigger("jump");

        }

    }


        void OnCollisionEnter(Collision target){  
        if(target.gameObject.name == "Block"){    // O ERRO ESTAVA AQUI TEM QUE SER IGUAL AO  BLOCCO QUE VAI TOCAR
            blockManager.catLandedBlock = target.gameObject;
           
        }
       
    }

}// class
