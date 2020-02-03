using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour{
    public Vector3 pongVector=new Vector3(0f, 0f, 0f);
    public float speedofBall=20f;
    public Rigidbody rigibP;
    public float x, y;
    void Start(){
        float ballX = Random.Range(1,3)==1?-2:2;
        float ballY = Random.Range(1,3)==1?-2:2;
        rigibP = GetComponent<Rigidbody>();
        rigibP.velocity = new Vector3(speedofBall*ballX, speedofBall*ballY, 0f);
    }
    void Update(){
        x=rigibP.velocity.x;
        y=rigibP.velocity.y;
    }
    void OnCollisionEnter(Collision collision){
        float speedofYaxis;
        speedofBall = speedofBall + 2f;
        if (y < 0){speedofYaxis = -speedofBall;}
        else{speedofYaxis = speedofBall;}
        if (collision.collider.name == "P1"){
            rigibP.velocity = new Vector3(speedofBall, speedofYaxis, 0f);}
        if (collision.collider.name == "P2"){
            rigibP.velocity = new Vector3(-speedofBall, speedofYaxis, 0f);}
    }
}
