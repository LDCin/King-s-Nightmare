using System;
using UnityEngine;
public class CamEdgeTrigger2D : MonoBehaviour
{
    public static event Action OnPlayerReachedEdgeUp;
    public static event Action OnPlayerReachedEdgeDown;

    private enum EdgeType { Top, Bot }

    [SerializeField] private EdgeType edgeType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(GameConfig.PLAYER_TAG)) return;

        if (edgeType == EdgeType.Top)
            OnPlayerReachedEdgeUp?.Invoke();
        else
            OnPlayerReachedEdgeDown?.Invoke();
    }
}