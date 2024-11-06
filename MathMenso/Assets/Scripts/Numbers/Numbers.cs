using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    [SerializeField] public LevelManager levelManager;
    [SerializeField] private LevelSettings levelSettings;

    /// <summary>
    /// Value of this number
    /// </summary>
    public int value;
    /// <summary>
    /// Bool that determines if the value is positive or negative
    /// </summary>
    public bool isPositive;
    /// <summary>
    /// Calculates the mathematical operation between the two numbers.
    /// Takes the other value, <param name="otherValue"> and sums or substracts depending on the isPositive bool value.</param>
    /// </summary>
    public virtual void ProcessOpertion(int otherValue, bool isPos) { }
    /// <summary>
    /// Returns the number to the ObjectPool and disables it, making sure there is only one in the scene.
    /// </summary>
    public virtual void Dissolve() { }
    /// <summary>
    /// Manages if the number is positive or negative.
    /// </summary>
    public virtual void ChangeValue() { }

    public virtual void ChooseValue() 
    {
        var sets = levelSettings.levelSetts;
        Debug.Log("Entre a Choose Value");
       
        switch (levelManager.level) 
        {
            case 1: value = Random.Range(sets.level1MinValue, sets.level1MaxValue); break;
            case 2: value = Random.Range(sets.level2MinValue, sets.level2MaxValue); break;
            case 3: value = Random.Range(sets.level3MinValue, sets.level3MaxValue); break;
            case 4: value = Random.Range(sets.level4MinValue, sets.level4MaxValue); break;
            case 5: value = Random.Range(sets.level5MinValue, sets.level5MaxValue); break;
            case 6: value = Random.Range(sets.level6MinValue, sets.level6MaxValue); break;
            case 7: value = Random.Range(sets.level7MinValue, sets.level7MaxValue); break;
        }

    }

    public void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>().GetComponent<LevelManager>();
        ChooseValue();
    }

    public virtual void LevelUp()
    {
        ChooseValue();
    }
}
