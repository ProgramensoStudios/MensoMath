using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChooseNumber : MonoBehaviour
{
    private int _value;

    [SerializeField] public LevelManager levelManager;
    [SerializeField] private LevelSettings levelSettings;
    private TMP_Text _text;
    private PoolingManager pool;
    private RootNumber _rootNumber;
    public bool isPositive = true;
    [SerializeField] private Image[] onOffSprites;
    
    
    public void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>().GetComponent<LevelManager>();
        levelSettings = FindAnyObjectByType<LevelSettings>().GetComponent<LevelSettings>();
        pool = FindAnyObjectByType<PoolingManager>().GetComponent<PoolingManager>();
        _rootNumber = FindAnyObjectByType<RootNumber>();
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        ChooseValue(0);
    }

    private void OnEnable()
    {
        _rootNumber.OnProcessOperation += ChooseValue;
    }
    private void OnDisable()
    {
        _rootNumber.OnProcessOperation -= ChooseValue;
    }

    private void ChooseValue(int value) 
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
        if (!isPositive)
        {
            _value *= (-1);
        }
        ShowNumber();
    }

    private void ShowNumber()
    {
        _text.text = _value.ToString();
    }

    [ContextMenu("Simulate Change Pos Neg")]

    public void ChangePosNeg()
    {
        switch (isPositive)
        {
            case true: isPositive = false; break;
            case false: isPositive = true; break;   
        }
        _value *= (-1);
        ShowNumber();
        ShowPosNegBTN();
    }

    public void ShowPosNegBTN()
    {
        switch (isPositive)
        {
            case true: onOffSprites[0].enabled = false; onOffSprites[1].enabled = true;  break;
            case false: onOffSprites[1].enabled = false; onOffSprites[0].enabled = true; break;
        }
    }

    public void GetNumberOnScene()
    {
        pool.AskForObject(_value);
    }
}
