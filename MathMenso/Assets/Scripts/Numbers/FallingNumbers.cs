using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Interfaces;
using Random = UnityEngine.Random;

public class FallingNumbers : Numbers, IChooseFace, IChooseColor
{
    public new SpriteRenderer renderer;
    public SpriteRenderer faceRenderer;
    public Sprite[] faces;
    public PoolingManager pool;
    [SerializeField] private TMP_Text text;
    public Color green;
    public Color red;
    

   /// <summary>
   /// Custom Event 
   /// </summary>
   // public delegate void StartMerge(Transform targetPosition);
   // public StartMerge OnStartMerge;
   private Camera mainCamera;

   private Rigidbody2D rb;
   [SerializeField] private Transform leftLimit;    
   [SerializeField] private Transform rightLimit;
   private bool isFollowingMouse = true;

   private void Awake()
   {
       leftLimit = GameObject.Find("LeftLimit").transform;
       rightLimit = GameObject.Find("RightLimit").transform;
       pool = FindAnyObjectByType<PoolingManager>().GetComponent<PoolingManager>();
       rb = GetComponent<Rigidbody2D>();
   }

   public void Start()
    {
        ChooseFace();
        text.text = value.ToString();
        mainCamera = Camera.main;
    }

   private void Update()
   {
       if (isFollowingMouse)
       {
           var mousePosition = Input.mousePosition;
           var worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
           var pos = transform.position;
           float clampedX = Mathf.Clamp(worldPosition.x, leftLimit.position.x +1f, rightLimit.position.x -1f);
           transform.position = new Vector3(clampedX, pos.y, 0);
       }

       if (!Input.GetMouseButtonDown(0)) return;
       isFollowingMouse = false;
       rb.gravityScale = 1;
   }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != 6) return;
        Dissolve();
        rb.gravityScale = 0;
        isFollowingMouse = true;
    }

    public override void Dissolve() 
    {
        //OnStartMerge?.Invoke(gameObject.transform);
        pool.ReturnObject(gameObject);
    }

    public void ChooseFace()
    {
        var chosenFace = Random.Range(0, faces.Length);
        faceRenderer.sprite = faces[chosenFace];
    }

    public void OnEnable()
    {
        text.text = value.ToString();
        ChooseColor();
        transform.rotation = new Quaternion(0f, 0f, 0f, 1f);
        ChooseFace();
    }

    public void ChooseColor()
    {
        isPositive = value switch
        {
            > 0 => true,
            < 0 => false,
            _ => isPositive
        };
        renderer.color = isPositive ? green : red;
    }
}
