using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComponent : MonoBehaviour
{
    public float thershold;
    
    void FixedUpdate(){

        if(transform.position.y < thershold){
            transform.position = new Vector3(0f,1.405f,0f);
        }
    }
}
