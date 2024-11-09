using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   private static LevelManager instance;
   public int level;
   
    
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                SetUpInstance();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void SetUpInstance()
    {
        instance = FindObjectOfType<LevelManager>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "LevelManager";
            instance = gameObj.AddComponent<LevelManager>();
            DontDestroyOnLoad(gameObj);
        }
    }

}
