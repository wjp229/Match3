using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private bool _isDragging = false;
   private Vector2 _initMousePos;

   private float _offsetMouseValue = 130.0f;

   private IInputInterface _currentHandler;
   
   private void Start()
   {
      StartCoroutine(CoUpdate());
   }

   IEnumerator CoUpdate()
   {
      while (true)
      {
         if (_isDragging)
         {
            // Drag Mouse Action
            Vector2 DifferMousePos = Input.mousePosition;
            DifferMousePos -= _initMousePos;

            if (DifferMousePos.magnitude > _offsetMouseValue && _currentHandler != null)
            {
               _isDragging = false;

               if (DifferMousePos.x > _offsetMouseValue)
               {
                  _currentHandler.OnScrollMouseButton(Direction.right);
               }
               else if (DifferMousePos.x < -_offsetMouseValue)
               {
                  _currentHandler.OnScrollMouseButton(Direction.left);

               }
               else if (DifferMousePos.y > _offsetMouseValue)
               {
                  
                  _currentHandler.OnScrollMouseButton(Direction.up);
               }
               else if (DifferMousePos.y < -_offsetMouseValue)
               {
                  
                  _currentHandler.OnScrollMouseButton(Direction.down);
               }
               
               _currentHandler = null;
            }
         }

         if (Input.GetMouseButtonDown(0))
         {
            _currentHandler = RaycastTarget();
            if (_currentHandler != null)
            {
               _currentHandler.OnClickMouseButtonDown();
               _isDragging = true;
               _initMousePos = Input.mousePosition;
            }
         }
         
         if (Input.GetMouseButtonUp(0))
         {
            _isDragging = false;
         }
         
         yield return new WaitForSeconds(0.001f);
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
