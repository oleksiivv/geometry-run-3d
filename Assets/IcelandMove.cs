using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcelandMove : MonoBehaviour
{
    int instPos=-20,speed=1;
  bool once=false;
  // Start is called before the first frame update
  void Start()
  {
    once=false;
    //Invoke("checkSpeed",3f);

  }

  // Update is called once per frame
  void Update()
  {
      if(Time.timeScale==1){
        //transform.Translate(new Vector3(0,0,1)*1 /5);
        gameObject.transform.position=Vector3.MoveTowards(gameObject.transform.position,new Vector3(transform.position.x,transform.position.y,instPos),0.2f*speed);


      }
      if(gameObject.transform.position.z <= instPos){
        Destroy(gameObject);
      }
  }

}
