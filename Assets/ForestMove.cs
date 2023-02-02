using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMove : MonoBehaviour
{
    static float speed=1f;
  bool once=false;

  [HideInInspector]
  public float speedCoef = 1f;
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
        transform.Translate(new Vector3(0,0,1)*-1*speed*speedCoef /4);
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
      if(other.gameObject.name.Contains("latf") || other.gameObject.name.Contains("endgame")){
        Destroy(gameObject);
      }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name.Contains("latf") || other.gameObject.name.Contains("endgame")){
            Destroy(gameObject);
        }
        if(other.gameObject.tag.Equals("coin")){
            Destroy(other.gameObject);
        }
    }
}
