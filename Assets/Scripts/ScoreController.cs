using SimpleMan.CoroutineExtensions;
using System;
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
        Action<int> scoreMethod = winner == BoardController.BoardFieldCharacters.Empty ? ScoreDraw : ScoreWin;
        scoreMethod(((int)winner) - 1);
    }
    private void ScoreWin(int winningIndex)
    {
        _scoresData[winningIndex].Value++;
        _scoresData[winningIndex].Text.text = _scoresData[winningIndex].Value.ToString();

        _canvasGroupController.SetAlpha(true, 1);
    }
    private void ScoreDraw(int winningIndex)
    {
        for(int i=0; i<2; i++)
        {
            _scoresData[i].Value++;
            _scoresData[i].Text.text = _scoresData[i].Value.ToString();
        }

        _canvasGroupController.SetAlpha(true, 1);
    }
}
