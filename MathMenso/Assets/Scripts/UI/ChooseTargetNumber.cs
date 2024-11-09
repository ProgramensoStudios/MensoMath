using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseTargetNumber : MonoBehaviour
{
    private TMP_Text _text;
    private int _value;
    [SerializeField] public LevelManager levelManager;
    [SerializeField] private LevelSettings levelSettings;
    private RootNumber _rootNumber;

    [SerializeField] private Canvas nextLevelCanvas;
    [SerializeField] HandleNextLevel nextLevelHandle;


    public void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>().GetComponent<LevelManager>();
        levelSettings = FindAnyObjectByType<LevelSettings>().GetComponent<LevelSettings>();
        _text = GetComponent<TMP_Text>();
        _rootNumber = FindAnyObjectByType<RootNumber>();
    }

    private void OnEnable()
    {
        _rootNumber.OnProcessOperation += ValidateTargetNumber;
        nextLevelHandle.OnHandleNextLevel += ChooseValue;
    }
    private void OnDisable()
    {
        _rootNumber.OnProcessOperation -= ValidateTargetNumber;
        nextLevelHandle.OnHandleNextLevel -= ChooseValue;
    }

    private void ValidateTargetNumber(int value)
    {
        if (value != _value) return;
        {
            nextLevelCanvas.enabled = true;
        }
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
