using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private void Start()
   {
      StartCoroutine(CoUpdate());
   }

   IEnumerator CoUpdate()
   {
      while (true)
      {
         if (Input.GetMouseButtonDown(0))
         {
            IInputInterface handler = RaycastTarget();
            if(handler != null)
               handler.OnClickMouseButtonDown();
         }

         if (Input.GetMouseButtonUp(0))
         {
            IInputInterface handler = RaycastTarget();
            if(handler != null)
               handler.OnClickMouseButtonUp();
         }
         
         yield return null;
      }
   }

   // Raycast Target Object and call InputHandler
   IInputInterface RaycastTarget()
   {
      Ray ray;
      RaycastHit Hit;

      Vector3 StartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      if (Physics.Raycast(StartPos, Vector3.forward, out Hit, 1000f))
      {
         BlockBase go = Hit.transform.GetComponent<BlockBase>();

         if (go)
         {
            IInputInterface handler = (IInputInterface)go;

            
            return go;
         }
      }

      return null;
   }
}
