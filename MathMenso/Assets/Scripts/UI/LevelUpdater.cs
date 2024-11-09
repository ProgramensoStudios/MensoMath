using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpdater : MonoBehaviour
{
    [SerializeField] HandleNextLevel nextLevelHandle;
    [SerializeField] LevelManager levelManager;
    [SerializeField] TMP_Text text;

    private void OnEnable()
    {
        nextLevelHandle.OnHandleNextLevel += UpdateLevel;
    }

    private void OnDisable()
    {
        nextLevelHandle.OnHandleNextLevel -= UpdateLevel;
    }

    private void UpdateLevel()
    {
        text.text = "Level " + levelManager.level;
    }


}
