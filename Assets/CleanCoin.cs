using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other){
      if(other.gameObject.name!="Player" && !other.gameObject.name.Contains("endgame") && other.gameObject.name.Contains("forest") && !other.gameObject.name.Contains("latform") && !other.gameObject.name.Contains("dino") && Application.loadedLevel!=6 && Application.loadedLevel!=12){
        Destroy(other.gameObject);
      }
      if(other.gameObject.name.Contains("latform")){
        Destroy(gameObject);
      }
    }
}
