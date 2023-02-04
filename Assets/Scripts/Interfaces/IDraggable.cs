using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{
    Transform NodeTransform { get; }
    void OnPlayerMouseEnter();
    void OnPlayerMouseExit();
    void OnPlayerDragging();
}
