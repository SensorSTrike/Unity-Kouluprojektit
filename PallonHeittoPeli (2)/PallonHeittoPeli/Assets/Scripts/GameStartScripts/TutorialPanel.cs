using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{

    public GameObject tutorialPanel;

    public void ToggleTutorialPanel()
    {
        tutorialPanel.SetActive(!tutorialPanel.activeSelf); 
    }
}
