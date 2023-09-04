using SimpleMan.CoroutineExtensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasGroupController _canvasGroupController;


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] ScoreData[] _scoresData = new ScoreData[2];



    [System.Serializable]
    public struct ScoreData
    {
        public string name;
        public TextMeshProUGUI Text;
        public int Value;
    }



    private void Awake()
    {
        _canvasGroupController.SetAlpha(false);
        this.Delay(0.5f, () => { _canvasGroupController.SetAlpha(true, 1); });
    }

    public void OnGameOver()
    {
        _canvasGroupController.SetAlpha(false, 1);
    }
    public void OnReset(BoardController.BoardFieldCharacters winner)
    {
        int index = ((int)winner) - 1;
        _scoresData[index].Value++;
        _scoresData[index].Text.text = _scoresData[index].Value.ToString();

        _canvasGroupController.SetAlpha(true, 1);
    }
}
