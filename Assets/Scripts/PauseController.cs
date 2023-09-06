using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasGroupController _canvasGroupController;
    [SerializeField] BoardController _boardController;
    [SerializeField] FaderController _fader;

    private void Awake()
    {
        _canvasGroupController.SetAlpha(false);
        _canvasGroupController.ToggleBlocksRaycast(false);
        _canvasGroupController.ToggleInteractable(false);
    }


    public void Pause()
    {
        if (_boardController.IsGameOver) return;

        _canvasGroupController.SetAlpha(true, 0.1f);
        _canvasGroupController.ToggleBlocksRaycast(true);
        _canvasGroupController.ToggleInteractable(true);
    }
    public void UnPause()
    {
        _canvasGroupController.SetAlpha(false, 0.1f);
        _canvasGroupController.ToggleBlocksRaycast(false);
        _canvasGroupController.ToggleInteractable(false);
    }


    public void Exit()
    {
        _fader.ToggleFade(true, 0.5f);
        this.Delay(1.1f, () => { Application.Quit(); });
    }
}
