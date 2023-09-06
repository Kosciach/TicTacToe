using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasGroupController _canvasGroupController;



    public void OnGameOver()
    {
        _canvasGroupController.SetAlpha(false, 1);
    }
    public void OnReset()
    {
        _canvasGroupController.SetAlpha(true, 1);
    }
}