using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCube : MonoBehaviour
{
  public Material[] skin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      /*
      switch(PlayerPrefs.GetInt("current")){
        case 0:

        break;

        case 1:
        break;

        case 2:
        break;

        case 3:
        break;

        case 4:
        break;

        case 5:
        break;
      }
      */
      gameObject.GetComponent<MeshRenderer>().material=skin[PlayerPrefs.GetInt("current")];
        transform.Rotate(0,1,0);
    }
}
