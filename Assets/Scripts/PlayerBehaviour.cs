using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float lenCube=0.6f;
    int dx=0;

    bool played=true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow)){
          if(dx>-1){


            dx--;
            played=false;

            if(!played){
              GetComponent<Animator>().SetBool("right",false);
              GetComponent<Animator>().SetBool("left",true);
              played=true;
              Invoke("cleanAnim",0.2f);
            }


          }
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)){
          if(dx<1){




            dx++;
            played=false;

            if(!played){
              GetComponent<Animator>().SetBool("left",false);
              GetComponent<Animator>().SetBool("right",true);
              played=true;
              Invoke("cleanAnim",0.2f);
            }

          }
        }




        transform.position=new Vector3(dx*lenCube,transform.position.y,transform.position.z);
    }

    void cleanAnim(){
      GetComponent<Animator>().SetBool("left",false);
      GetComponent<Animator>().SetBool("right",false);
    }




}
