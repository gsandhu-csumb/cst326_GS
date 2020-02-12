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
    public Text scoreL;
    public Text scoreR;
    public Text myText;
   // int test = 0;




    void Start(){
        //scoreL = GetComponent<Text> ();
        float ballX = Random.Range(1,3)==1?-2:2;
        float ballY = Random.Range(1,3)==1?-2:2;
        rigibP = GetComponent<Rigidbody>();
        rigibP.velocity = new Vector3(speedofBall*ballX, speedofBall*ballY, 0f);
        audioSour = GetComponent<AudioSource>();
        scoreValue1 =0;
        scoreValue2 =0;
        audioSour.clip = sourSound;
        audioSour.PlayOneShot(audioSour.clip);
        //scoreL.text = scoreValue1.ToString();
        //scoreR.text = scoreValue2.ToString();

    }
    void Update(){
        x=rigibP.velocity.x;
        y=rigibP.velocity.y;
        //scoreL.text = "Score: ";
        //myText.text = test.ToString();

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
            scoreValue2 = scoreValue2 + 1;
            scoreL.text = scoreValue2.ToString();
            this.transform.position = new Vector3(0f, 0f, 0f);
            rigibP.velocity = new Vector3(-25, -10f, 0f);
            //speedofBall = speedofBall + 20;
        }
        if(collision.gameObject.name == "WallR"){
           // scoreValue2++;
          // Destroy(collision.gameObject);
           //test++;
           scoreValue1 = scoreValue1 + 1;
           scoreR.text = scoreValue1.ToString();
           this.transform.position = new Vector3(0f, 0f, 0f);
           rigibP.velocity = new Vector3(25, 10f, 0f);
           //speedofBall = speedofBall + 20;
        }
        //GetComponent<Text>().color = Color.gray
        if(scoreValue1 == 3){
                   //myText.text = "Winner Player 1";
                   //this.transform.position = new Vector3(0f, 0f, 0f);
                   //rigibP.velocity = new Vector3(0f, 0f, 0f);
                   scoreR.color = Color.red;
        }
        if(scoreValue2 == 3){
                   //myText.text = "Winner Player 2";
                   //this.transform.position = new Vector3(0f, 0f, 0f);
                   //rigibP.velocity = new Vector3(0f, 0f, 0f);
                   scoreL.color = Color.blue;
        }
        if(scoreValue1 == 11){
            myText.text = "Winner Player 1";
            this.transform.position = new Vector3(0f, 0f, 0f);
            rigibP.velocity = new Vector3(0f, 0f, 0f);


        }
        if(scoreValue2 == 11){
            myText.text = "Winner Player 2";
            this.transform.position = new Vector3(0f, 0f, 0f);
            rigibP.velocity = new Vector3(0f, 0f, 0f);


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
                rigibP.velocity = new Vector3(speedofBall, 0f, 0f);
            }else{
                rigibP.velocity = new Vector3(speedofBall, 0f, 0f);
            }
        }
        if(collison.name == "Powerp2"){
            this.transform.position = new Vector3(0f, 0f, 0f);
            rigibP.velocity = new Vector3(-50f, -10f, 0f);
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
