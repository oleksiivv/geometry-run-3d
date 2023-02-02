using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceland : MonoBehaviour
{
    public GameObject[] icelands;
    public GameObject[] plates;
    void Start()
    {
        StartCoroutine(game());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator game(){
        while(true){
            int v=Random.Range(0,Random.Range(0,icelands.Length));

            if(v==0){
                int id=Random.Range(0,icelands.Length);
                Instantiate(icelands[id],
                    new Vector3(icelands[id].transform.position.x,icelands[id].transform.position.y,icelands[id].transform.position.z+90),
                        icelands[id].transform.rotation);
                yield return new WaitForSeconds(3.45f);
            }

            
        }
    }
}
