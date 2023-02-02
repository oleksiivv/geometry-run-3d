using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDecor : MonoBehaviour
{
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(Time.timeScale==1)transform.Translate(new Vector3(0,0,1)*-1/5);
    if(gameObject.transform.position.z <= -10){
      //Instantiate(gameObject,new Vector3(0,0,gameObject.transform.position.z+100*3),Quaternion.identity);
      Destroy(gameObject);
    }
  }

}
