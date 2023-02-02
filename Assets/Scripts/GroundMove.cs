using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{


    int instPos=-12;
    private int speed=1;
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
        transform.Translate(new Vector3(0,0,1)*-1 /5 *speed);


      }

        if(gameObject.transform.position.z <= instPos){
          if(Time.timeScale==1)Instantiate(gameObject,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z+10.2f*9),gameObject.transform.rotation);
          Destroy(gameObject);
        }
    }


    void checkSpeed(){
      if(((int)(1f / Time.unscaledDeltaTime))< 31){
        if(!once){
          speed=2;
          once=true;
        }
      }
      else{
        if(!once){
          once=true;
          speed=1;
        }
      }
    }
}
