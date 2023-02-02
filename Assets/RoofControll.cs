using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofControll : MonoBehaviour
{
  public GameObject pausePanel,restartPanel,bg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-2){
          bg.SetActive(true);
          restartPanel.SetActive(true);
        }
    }
}
