using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] public levelSettings levelSetts;
}

[System.Serializable]
public struct levelSettings
{
    public int level1MinValue;
    public int level1MaxValue;

    public int level2MinValue;
    public int level2MaxValue;

    public int level3MinValue;
    public int level3MaxValue;

    public int level4MinValue;
    public int level4MaxValue;

    public int level5MinValue;
    public int level5MaxValue;

    public int level6MinValue;
    public int level6MaxValue;

    public int level7MinValue;
    public int level7MaxValue;
}
