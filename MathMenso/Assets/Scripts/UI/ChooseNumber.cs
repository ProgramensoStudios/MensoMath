using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChooseNumber : MonoBehaviour
{
    private int _value;
    
    [SerializeField] public LevelManager levelManager;
    [SerializeField] private LevelSettings levelSettings;
    private TMP_Text _text;
    private PoolingManager pool;
    
    
    public void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>().GetComponent<LevelManager>();
        levelSettings = FindAnyObjectByType<LevelSettings>().GetComponent<LevelSettings>();
        pool = FindAnyObjectByType<PoolingManager>().GetComponent<PoolingManager>();
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

    [ContextMenu("Simulate Change Pos Neg")]

    public void ChangePosNeg()
    {
        _value *= (-1);
        ShowNumber();
    }

    public void GetNumberOnScene()
    {
        pool.AskForObject(_value);
    }
}
