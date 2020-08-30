using Cinemachine;
using UnityEngine;

/// <summary>
/// Class that switchs the collider for the cinemachine camera
/// </summary>
public class SwitchConfineBoundingShape : MonoBehaviour {
    /// <summary>
    /// Initialization with other objects
    /// </summary>
    void Start() {
        SwitchBoundingShape();
    }

    /// <summary>
    /// Switchs the collider for the cinemachine camera
    /// </summary>
    private void SwitchBoundingShape() {
        PolygonCollider2D col = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).GetComponent<PolygonCollider2D>();
        CinemachineConfiner confiner = GetComponent<CinemachineConfiner>();
        confiner.m_BoundingShape2D = col;
        confiner.InvalidatePathCache();
    }
}
