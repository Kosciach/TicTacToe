using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasGroupController _canvasGroupController;


    private void Awake()
    {
        _canvasGroupController.SetAlpha(false);
        _canvasGroupController.ToggleBlocksRaycast(false);
        _canvasGroupController.ToggleInteractable(false);
    }


    public void OpenCredits()
    {
        _canvasGroupController.ToggleBlocksRaycast(true);
        _canvasGroupController.ToggleInteractable(true);
        _canvasGroupController.SetAlpha(true, 0.1f);
    }
    public void CloseCredits()
    {
        _canvasGroupController.SetAlpha(false, 0.1f);
        this.Delay(0.1f, () =>
        {
            _canvasGroupController.ToggleBlocksRaycast(false);
            _canvasGroupController.ToggleInteractable(false);
        });
    }
}
