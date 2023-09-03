using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    private CanvasGroup _canvasGroup;


    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }


    public void SetAlpha(bool enable)
    {
        int weight = enable ? 1 : 0;
        _canvasGroup.alpha = weight;
    }
    public void SetAlpha(bool enable, float duration)
    {
        int weight = enable ? 1 : 0;
        LeanTween.alphaCanvas(_canvasGroup, weight, duration);
    }

    public void ToggleInteractable(bool enable)
    {
        _canvasGroup.interactable = enable;
    }
    public void ToggleBlocksRaycast(bool enable)
    {
        _canvasGroup.blocksRaycasts = enable;
    }
}