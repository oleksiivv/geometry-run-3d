using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMove : MonoBehaviour
{
    private MoveEnemy moveEnemy;

    public float speedCoef = 1.3f;

    void Start(){
        moveEnemy = gameObject.GetComponent<MoveEnemy>();
        moveEnemy.speedCoef = speedCoef == 1.3f ? 1.3f : Random.Range(1.2f, 2f);

        //StartCoroutine(Jump());
    }

    IEnumerator Jump(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*20);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.name!="Player" && !other.gameObject.name.Contains("latform")){
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            //gameObject.transform.position += new Vector3(0, 2, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*200);
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward*-200);
        }

        if(other.gameObject.tag.Equals("coin")){
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("coin")){
            Destroy(other.gameObject);
        }
    }
}
