using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBird : MonoBehaviour
{
  public GameObject[] frames;
  // Start is called before the first frame update
  void Start()
  {
      StartCoroutine(animateBird());
  }

  // Update is called once per frame
  void Update()
  {

  }
  int currentFrame = 0;

  IEnumerator animateBird()
  {
      while (true)
      {
          frames[currentFrame%frames.Length].SetActive(true);

          for (int i = 0; i < frames.Length; i++)
          {
              if (i == currentFrame%frames.Length)
              {
                  continue;
                  //frames[i].SetActive(true);
              }
             frames[i].SetActive(false);

          }
          currentFrame++;

          yield return new WaitForSeconds(0.1f);
      }

  }
}
