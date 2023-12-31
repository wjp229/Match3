using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputInterface
{
    void OnClickMouseButtonDown();
    void OnClickMouseButtonUp();
    void OnScrollMouseButton(Direction InDir);
}
