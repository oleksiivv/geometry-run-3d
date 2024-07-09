using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestOpenLevel : MonoBehaviour
{
    public QuestsController questsController;

    public string levelName;

    void Start(){
        Invoke(nameof(CompleteQuestCurrentLevel), 6);
    }

    void CompleteQuestCurrentLevel(){
        questsController.CompleteQuest("open_level_"+levelName);
    }
}
