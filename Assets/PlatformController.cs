using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
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
        if(!gameObject.name.Contains("sea") && other.gameObject.tag=="Enemy" && !other.gameObject.name.Contains("latform") || other.gameObject.tag=="x2"){
            if(other.gameObject.transform.parent!=gameObject.transform &&
             !other.gameObject.transform.parent.gameObject.name.Contains("latform") && !other.gameObject.name.Contains("latform")){
                 Destroy(other.gameObject);
             }
        }
        // if(other.gameObject.tag=="x2"){
        //     Destroy(other.gameObject);
        // }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="x2"){
            other.gameObject.SetActive(false);
        }
    }
}
