using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackMove : MonoBehaviour
{
  int instPos=-20,speed=1;
  bool once=false;
  // Start is called before the first frame update
  void Start()
  {
    once=false;

}

// Update is called once per frame
void Update()
{
    if(Time.timeScale==1){
      //transform.Translate(new Vector3(0,0,1)*1 /5);
      gameObject.transform.position=Vector3.MoveTowards(gameObject.transform.position,new Vector3(transform.position.x,transform.position.y,instPos),0.2f*speed);

      if(((int)(1f / Time.unscaledDeltaTime))< 31){
        if(!once){
          speed=2;
          once=false;
        }
      }
      else{
        if(!once){
          once=true;
          speed=1;
        }
    }
  }
    if(gameObject.transform.position.z <= instPos){
      if(Time.timeScale==1){
        Instantiate(gameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z+200),gameObject.transform.rotation);

      }
      Destroy(gameObject);
    }
}
}
