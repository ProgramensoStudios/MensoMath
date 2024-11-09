using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNumber : Numbers
{
    public SpriteRenderer sRenderer;
    public delegate void ProcessOperationEv(int value);
    public ProcessOperationEv OnProcessOperation;

    public Color green;
    public Color red;
    [SerializeField] HandleNextLevel nextLevelHandle;

    private void OnEnable()
    {
        nextLevelHandle.OnHandleNextLevel += ResetGame;
    }
    private void OnDisable()
    {
        nextLevelHandle.OnHandleNextLevel -= ResetGame;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != 6) return;
        var fallingNumber = other.gameObject.GetComponent<FallingNumbers>();
        ProcessOperation(fallingNumber.value, fallingNumber.isPositive);
    }
    public override void ProcessOperation(int otherValue, bool isPos)
    {
        value += otherValue;
        OnProcessOperation?.Invoke(value);
        CheckIfValueIsPositive();
    }

    private void CheckIfValueIsPositive()
    {
        isPositive = value > 0;
        ChangeColor();
    }

    private void ChangeColor()
    {
        sRenderer.color = isPositive switch
        {
            true => green,
            false => red
        };
    }

    private void ResetGame()
    {
        value = 0;
        OnProcessOperation?.Invoke(value);
    }
}
