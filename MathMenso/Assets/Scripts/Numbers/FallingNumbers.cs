using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Interfaces;
using Random = UnityEngine.Random;

public class FallingNumbers : Numbers, IChooseFace, IChooseColor
{
    public new SpriteRenderer renderer;
    public Color[] colors;

    public Sprite[] faces;

    public delegate void StartMerge(Transform targetPosition);
    public StartMerge OnStartMerge;

    public new void Start()
    {
        ChooseColor();
        //ChooseFace();
    }
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

    private void OnCollision2DEnter(Collision2D collision)
    {
        Dissolve();
    }

    public override void Dissolve() 
    {
        OnStartMerge?.Invoke(this.gameObject.transform);
        this.gameObject.SetActive(false);
    }

    public void ChooseFace()
    {
        var chosenFace = Random.Range(0, faces.Length);
        var newFace =  Instantiate(faces[chosenFace]);
       
        
    }

    public void ChooseColor()
    {
        var chosenColor = Random.Range(0, colors.Length);
        renderer.color = colors[chosenColor];
    }
}
