using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="BlockData", menuName = "ScriptableObjects/BlockBase")]
public class BlockScriptableObject : ScriptableObject
{
    public Sprite sprite;
    
    [SerializeField]
    private int blockNum;
    public int BlockNum
    {
        get { return blockNum; }
    }
}
