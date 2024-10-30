using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingNumbers : Numbers
{
    public delegate void StartMerge(Transform targetPosition);
    public StartMerge OnStartMerge;
    public override void ChangeValue() 
    {
        if (isPositive)
        { 
            isPositive = false; 
        }
        else if (!isPositive)
        {
            isPositive = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Dissolve();
    }

    public override void Dissolve() 
    {
        OnStartMerge?.Invoke(this.gameObject.transform);
    }
}
