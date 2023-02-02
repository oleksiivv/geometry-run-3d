using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    static float speed=1f;
  bool once=false;
  // Start is called before the first frame update
  void Start()
  {
    once=false;

      //StartCoroutine(incrSpeed());
      //Invoke("checkSpeed",3f);

    }

    // Update is called once per frame
    void Update()
    {
      if(Time.timeScale==1){
        transform.Translate(new Vector3(0,0,1)*1*speed /4);


      }
      if(gameObject.transform.position.z <= -8 && !gameObject.name.Contains("latform") && !gameObject.name.Contains("sea")){
        //Instantiate(gameObject,new Vector3(0,0,gameObject.transform.position.z+100*3),Quaternion.identity);
        //Destroy(gameObject);
        gameObject.SetActive(false);
      }
      else if(gameObject.name.Contains("latform") && gameObject.transform.position.z <= -15){
        gameObject.SetActive(false);
      }

      else if(gameObject.name.Contains("sea") && gameObject.transform.position.z <= -35){
        gameObject.SetActive(false);
      }
    }

    IEnumerator incrSpeed(){

      Debug.Log(speed);
      if(speed<1.9f)speed+=0.04f;
      yield return new WaitForSeconds(4);

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

    void OnCollisionEnter(Collision other){
      if(other.gameObject.name.Contains("latf")){
        Destroy(gameObject);
      }
    }
}
