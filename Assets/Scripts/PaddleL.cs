using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    public float speed = 25f;
     void Update () {
         Vector3 pos = transform.position;
 
         if (Input.GetKey ("w")) {
             pos.y += speed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.y -= speed * Time.deltaTime;
         }
        
         transform.position = pos;
         
         if(transform.position.y < -35){
                     transform.position = new Vector3(-65f, -35f, 0f);
            }
        if(transform.position.y > 35){
                     transform.position = new Vector3(-65f, 35f, 0f);
        }
     }
}
