using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardContainer : MonoBehaviour
{
    public BlockScriptableObject[] BlockScriptableObjects;
    public GameObject BlockBaseObject;

    [SerializeField]
    private List<GameObject> BlockObjects = new List<GameObject>();
    
    private int _horizontalSlot = 7;
    private int _verticalSlot = 12;

    public float SlotOffset = 2f;

    [SerializeField]
    public List<BlockRow> BlockRows;

    public GameObject Container;
    
    public void InitializeGameSettings()
    {
        // Instantiate Block Base Objects to Clone
        // Replace this with Scriptable Object
        for (int ix = 0; ix < BlockScriptableObjects.Length; ix++)
        {
            GameObject go = Instantiate(BlockBaseObject);
            go.GetComponent<BlockBase>().SpawnBlockBase(BlockScriptableObjects[ix]);
            BlockObjects.Add(go);
            go.SetActive(false);
        }

        InitializeBoard();
    }
    
    // Init Game
    public void InitializeBoard()
    {
        Vector2 pivotPoint = Vector2.zero;

        // Create Slots with Num
        for (int ix = 0; ix < _horizontalSlot; ix++)
        {
            BlockRows.Add(new BlockRow());
            for (int jx = 0; jx < _verticalSlot; jx++)
            {
                int RandomBlock = Random.Range(0, BlockObjects.Count);
                var go = Instantiate(BlockObjects[RandomBlock], new Vector3(ix * SlotOffset, jx * SlotOffset, 0f), Quaternion.identity, Container.transform);
                go.SetActive(true);
                BlockRows[ix].Block.Add(go);
            }
        }
    }
}

[Serializable]
public class BlockRow
{
    public List<GameObject> Block = new List<GameObject>();
}