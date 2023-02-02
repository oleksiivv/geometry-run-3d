using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    public GameObject studyPanel;

    public void setStudyPanelActive(bool active){
        studyPanel.SetActive(active);
    }
}
