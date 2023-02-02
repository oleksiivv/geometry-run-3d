using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalController : MonoBehaviour
{
  public GameObject loadingPanel;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("finishStudy",2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void finishStudy(){
      loadingPanel.SetActive(true);
      Application.LoadLevel(0);
    }
}
