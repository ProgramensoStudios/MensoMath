using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChooseTargetNumber : MonoBehaviour
{
    private TMP_Text _text;
    private int _value;
    [SerializeField] public LevelManager levelManager;
    [SerializeField] private LevelSettings levelSettings;

    
    public void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>().GetComponent<LevelManager>();
        levelSettings = FindAnyObjectByType<LevelSettings>().GetComponent<LevelSettings>();
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        ChooseValue();
    }

    private void ChooseValue() 
    {
        var sets = levelSettings.levelSetts;

        _value = levelManager.level switch
        {
            1 => Random.Range(sets.level1MinValue, sets.level1MaxValue),
            2 => Random.Range(sets.level2MinValue, sets.level2MaxValue),
            3 => Random.Range(sets.level3MinValue, sets.level3MaxValue),
            4 => Random.Range(sets.level4MinValue, sets.level4MaxValue),
            5 => Random.Range(sets.level5MinValue, sets.level5MaxValue),
            6 => Random.Range(sets.level6MinValue, sets.level6MaxValue),
            7 => Random.Range(sets.level7MinValue, sets.level7MaxValue),
            _ => _value
        };
        ShowNumber();
    }

    private void ShowNumber()
    {
        _text.text = _value.ToString();
    }
}
