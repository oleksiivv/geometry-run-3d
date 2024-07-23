using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
    public GameObject slot;

    public Animation animation;

    public Image icon;
    public Text name;
    public Text description;

    public int targetLevel=1;

    public void SetQuest(Quest quest, int level=1){
        if(targetLevel != level){
            //return;
        }

        slot.gameObject.SetActive(true);
        animation.Play("ShowQuest");

        icon.sprite = quest.icon;
        name.text = quest.name;
        description.text = "<b>New quest: </b>" + quest.description;
    }

    public void Hide(){
        animation.Play("HideQuest");

        Invoke(nameof(SetQuestSlotActiveFalse), 1f);
    }

    void SetQuestSlotActiveFalse(){
        slot.gameObject.SetActive(false);
    }
}
