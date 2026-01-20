using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private BoxCollider2D _topCamBound;
    [SerializeField] private BoxCollider2D _botCamBound;
    private float _camW;
    private float _camH;
    private void Awake()
    {
        _cam = Camera.main;
    }
    private void OnEnable()
    {
        CamEdgeTrigger2D.OnPlayerReachedEdgeUp += MoveUp;
        CamEdgeTrigger2D.OnPlayerReachedEdgeDown += MoveDown;
    }
    private void OnDisable()
    {
        CamEdgeTrigger2D.OnPlayerReachedEdgeUp -= MoveUp;
        CamEdgeTrigger2D.OnPlayerReachedEdgeDown -= MoveDown;
    }
    private void Start()
    {
        InitCamSize();
        InitScreenBound();
    }
    private void InitCamSize()
    {
        _camH = _cam.orthographicSize * 2;
        _camW = _camH * _cam.aspect;
    }
    private void InitScreenBound()
    {
        _topCamBound.size = new Vector3(_camH, _camW, 0);
        _botCamBound.size = _topCamBound.size;
        _topCamBound.transform.position = new Vector2(_cam.transform.position.x, _cam.transform.position.y + _camH / 2);
        _botCamBound.transform.position = new Vector2(_cam.transform.position.x, _cam.transform.position.y - _camH / 2);
    }
    public void MoveUp()
    {
        transform.position += new Vector3(0, _camH, 0);
    }
    public void MoveDown()
    {
        transform.position -= new Vector3(0, _camH, 0);
    }
}
