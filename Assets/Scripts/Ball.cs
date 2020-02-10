using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour{
    public Vector3 pongVector=new Vector3(0f, 0f, 0f);
    public float speedofBall=20f;
    public Rigidbody rigibP;
    public float x, y;
    public int scoreValue1;
    public int scoreValue2;
    public AudioSource audioSour;
    public AudioClip sourSound;
    public AudioClip shootingStarSound;
   // public Text scoreL;
    //public Text scoreR;
    //public Text myText;
    //int test = 0;




    void Start(){
        //scoreL = GetComponent<Text> ();
        float ballX = Random.Range(1,3)==1?-2:2;
        float ballY = Random.Range(1,3)==1?-2:2;
        rigibP = GetComponent<Rigidbody>();
        rigibP.velocity = new Vector3(speedofBall*ballX, speedofBall*ballY, 0f);
        audioSour = GetComponent<AudioSource>();
        //scoreValue1 =0;
        //scoreValue2 =0;
        audioSour.clip = sourSound;
        audioSour.PlayOneShot(audioSour.clip);
       // scoreL.text = " ";
        //scoreR.text = " ";

    }
    void Update(){
        x=rigibP.velocity.x;
        y=rigibP.velocity.y;
        //scoreL.text = "Score: ";
       // myText.text = test.ToString();

    }
    void OnCollisionEnter(Collision collision){
        float speedofYaxis;
        speedofBall = speedofBall + 2f;
        if (y < 0){speedofYaxis = -speedofBall;}
        else{speedofYaxis = speedofBall;}
        if (collision.gameObject.name == "PaddleL"){
            audioSour.PlayOneShot(audioSour.clip);
            rigibP.velocity = new Vector3(speedofBall, speedofYaxis, 0f);}
        if (collision.gameObject.name == "PaddleR"){
            audioSour.PlayOneShot(audioSour.clip);
            rigibP.velocity = new Vector3(-speedofBall, speedofYaxis, 0f);}
        if(collision.gameObject.name == "WallL"){
            //Destroy(collision.gameObject);
            //test++;
            this.transform.position = new Vector3(0f, 0f, 0f);
            rigibP.velocity = new Vector3(-25, -10f, 0f);
            //speedofBall = speedofBall + 20;
        }
        if(collision.gameObject.name == "WallR"){
           // scoreValue2++;
          // Destroy(collision.gameObject);
           //test++;
           this.transform.position = new Vector3(0f, 0f, 0f);
           rigibP.velocity = new Vector3(25, 10f, 0f);
           //speedofBall = speedofBall + 20;
        }
    }
    void OnTriggerEnter(Collider collison){
        if(speedofBall > 1){
            audioSour.clip = shootingStarSound;
            audioSour.PlayOneShot(audioSour.clip);

        }
        if(collison.name == "Powerp1"){
            speedofBall=speedofBall+50;
            if(x>0){
                rigibP.velocity = new Vector3(speedofBall, 0, 0f);
            }else{
                rigibP.velocity = new Vector3(speedofBall, 0, 0f);
            }
        }
        if(collison.name == "Powerp2"){
            this.transform.position = new Vector3(0f, 0f, 0f);
            rigibP.velocity = new Vector3(-50, -10f, 0f);
            /*
            if(x>0){
                rigibP.velocity = new Vector3(speedofBall, 0, 0f);
            }else{
                rigibP.velocity = new Vector3(speedofBall, 0, 0f);
            }
             */
        }
    }
}
