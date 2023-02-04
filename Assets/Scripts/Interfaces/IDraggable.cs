using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{
    void FollowingMouse(Vector3 mousePos);
    void OnPlayerMouseEnter();
    void OnPlayerMouseExit();
}
