using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour, IInputInterface
{
    private int blockNum;
    
    private bool _isMoved;

    public void SpawnBlockBase(BlockScriptableObject InScriptableObject)
    {
        GetComponent<SpriteRenderer>().sprite = InScriptableObject.sprite;
        gameObject.name = InScriptableObject.sprite.name;

        blockNum = InScriptableObject.BlockNum;
    }

    public void OnClickMouseButtonDown()
    {
        Debug.Log("OnClickButtonDown"+ gameObject.name);
    }

    public void OnClickMouseButtonUp()
    {
        Debug.Log("OnClickButtonUp"+ gameObject.name);
    }
}
