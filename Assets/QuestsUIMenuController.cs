using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsUIMenuController : MonoBehaviour
{
    public Animator questsButton;

    void Start(){
        questsButton.enabled=false;

        if(PlayerPrefs.GetInt("is_not_first_menu_open", 0) == 1){
            questsButton.enabled=true;
        } else if(PlayerPrefs.GetInt("is_not_first_menu_open", 0) == 0){
            PlayerPrefs.SetInt("is_not_first_menu_open", 1);
        }

        //PlayerPrefs.SetInt("current_quest_id", PlayerPrefs.GetInt("current_quest_id", 0) + 1);
    }
}
