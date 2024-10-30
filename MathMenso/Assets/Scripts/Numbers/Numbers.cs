using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Numbers : MonoBehaviour
{
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
}
