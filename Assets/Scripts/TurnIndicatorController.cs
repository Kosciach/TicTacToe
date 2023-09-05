using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIndicatorController : MonoBehaviour
{
    [Header("====Header====")]
    [SerializeField] Transform[] _indicatorParents;



    public void NextTurn(BoardController.BoardFieldCharacters currentTurn)
    {
        transform.LeanScale(Vector3.zero, 0.1f).setOnComplete(() =>
        {
            transform.SetParent(_indicatorParents[(int)currentTurn - 1]);
            transform.localPosition = new Vector3(-7, -328, 0);
            transform.LeanScale(Vector3.one, 0.1f);
        });
    }
    public void OnReset()
    {
        NextTurn(BoardController.BoardFieldCharacters.O);
    }
}
