using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListenToValueChange : MonoBehaviour
{
   [SerializeField]  private RootNumber rootNumber;
   [SerializeField] private TMP_Text tmp;
   
   private void OnEnable()
   {
      if (rootNumber != null)
      {
         rootNumber.OnProcessOperation += ChangeNumberText;
      }
      else
      {
         Debug.LogError("rootNumber no está asignado en el Inspector.");
      }
   }

   private void OnDisable()
   {
      if (rootNumber != null)
      {
         rootNumber.OnProcessOperation -= ChangeNumberText;
      }
   }

   private void ChangeNumberText(int value)
   {
      if (tmp != null)
      {
         tmp.text = value.ToString();
      }
      else
      {
         Debug.LogError("TMP_Text no está asignado en el Inspector.");
      }
   }
}
