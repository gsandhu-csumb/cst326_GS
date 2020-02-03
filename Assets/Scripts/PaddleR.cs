using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
        public float speed = 20f;
    
        void Update () {
            Vector3 pos = transform.position;
    
            if (Input.GetKey ("o")) {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey ("l")) {
                pos.x -= speed * Time.deltaTime;
            }
            transform.position = pos;
        }
}
