using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision other){
        if(!other.gameObject.name.ToLower().Contains("player") && !other.gameObject.name.ToLower().Contains("ground")){
            Destroy(other.gameObject);
        }
    }


    void OnTriggerEnter(Collider other){
        if(!other.gameObject.name.ToLower().Contains("player") && !other.gameObject.name.ToLower().Contains("ground")){
            Destroy(other.gameObject);
        }
    }

    
}
