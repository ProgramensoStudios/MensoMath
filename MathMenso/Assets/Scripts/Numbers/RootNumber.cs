using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNumber : Numbers
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        var fallingNumber = collision.gameObject.GetComponent<FallingNumbers>();
        ProcessOpertion(fallingNumber.value, fallingNumber.isPositive);
    }
    public override void ProcessOpertion(int otherValue, bool isPos)
    {
        if (isPos)
        {
            value += otherValue;
        }
        else 
        {
            value -= otherValue;
        }
    }
}
