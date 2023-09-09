using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleMan.CoroutineExtensions;

[RequireComponent(typeof(CanvasGroupController))]
public class FaderController : MonoBehaviour
{
    private CanvasGroupController _canvasGroupController;

    private void Awake()
    {
        _canvasGroupController = GetComponent<CanvasGroupController>();

        _canvasGroupController.ToggleBlocksRaycast(true);
        _canvasGroupController.ToggleInteractable(true);

        _canvasGroupController.SetAlpha(true);
        _canvasGroupController.SetAlpha(false, 1);

        this.Delay(1, () =>
        {
            _canvasGroupController.ToggleBlocksRaycast(false);
            _canvasGroupController.ToggleInteractable(false);
        });
    }


    public void ToggleFade(bool enable, float duration)
    {
        _canvasGroupController.SetAlpha(enable, duration);
    }
}