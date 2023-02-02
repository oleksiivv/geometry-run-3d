using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoJumpAbilityLabelController : MonoBehaviour
{
    public GameObject noJumpLabel;

    private void Start() {
        if(PlayerPrefs.GetInt("NoJumpLabelShowedTimesAt"+Application.loadedLevel.ToString(), 0)>=3){
            noJumpLabel.gameObject.SetActive(false);
        }
        else{
            noJumpLabel.gameObject.SetActive(true);
            PlayerPrefs.SetInt("NoJumpLabelShowedTimesAt"+Application.loadedLevel.ToString(), PlayerPrefs.GetInt("NoJumpLabelShowedTimesAt"+Application.loadedLevel.ToString(), 0)+1);
        }
    }
}
