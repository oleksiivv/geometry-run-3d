using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    public MovePlayer pl;
    
    private float yOffset;
    private Rigidbody plRb;
    private float startPosY;
    // Start is called before the first frame update
    void Start()
    {
        startPosY=transform.position.y;
        yOffset=transform.position.y-player.transform.position.y;
        plRb=player.GetComponent<Rigidbody>();

        latePosY=player.transform.position.y;
        pl=player.GetComponent<MovePlayer>();

        
    }

    private float latePosY;
    // Update is called once per frame
    void Update()
    {
        //transform.position=new Vector3(transform.position.x,player.transform.position.y+yOffset,transform.position.z);
        if(pl.jump){
            transform.position=Vector3.MoveTowards(transform.position,
            new Vector3(transform.position.x,player.transform.position.y+yOffset,transform.position.z),0.1f);
        }
        else{
            Vector3.MoveTowards(transform.position,
            new Vector3(transform.position.x,startPosY,transform.position.z),0.5f);
        }

        transform.position=Vector3.MoveTowards(transform.position,
            new Vector3(player.transform.position.x,transform.position.y,transform.position.z),0.1f);

        // if(pl.jump){
        //     transform.position=Vector3.MoveTowards(transform.position,
        //     new Vector3(transform.position.x,(float)((float)player.transform.position.y+yOffset),transform.position.z),0.6f);
            
        // }
        
    }

    void LateUpdate(){
        latePosY=player.transform.position.y;
    }
}
