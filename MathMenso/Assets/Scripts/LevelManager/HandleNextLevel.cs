using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleNextLevel : MonoBehaviour
{
    public delegate void HandleNextLevelCallback();
    public HandleNextLevelCallback OnHandleNextLevel;

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    public void NextLevel()
    {
        levelManager.level += 1;
        OnHandleNextLevel?.Invoke();
    }
}
