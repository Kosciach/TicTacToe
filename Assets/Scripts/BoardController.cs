using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleMan.CoroutineExtensions;

public class BoardController : MonoBehaviour
{
    [Header("====Debugs====")]
    [SerializeField] bool _isGameOver;
    [Space(5)]
    [SerializeField] BoardFieldCharacters[] _boardFields = new BoardFieldCharacters[9];
    [SerializeField] BoardFieldCharacters _currentTurn;


    private RectTransform _rectTransform;

    public enum BoardFieldCharacters { Empty, O, X }


    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        _rectTransform.localScale = Vector3.zero;
        this.Delay(0.5f, () => { _rectTransform.LeanScale(Vector3.one, 1).setEaseInOutQuad(); });
    }




    public void BoardFieldPress(int index)
    {
        if (_boardFields[index] != BoardFieldCharacters.Empty || _isGameOver) return;

        SetField(index);
        CheckFields();
        SetNextCharacter();
    }
    private void SetField(int index)
    {
        _boardFields[index] = _currentTurn;
    }
    private void CheckFields()
    {
        if (_boardFields[0] == _currentTurn && _boardFields[1] == _currentTurn && _boardFields[2] == _currentTurn
        || _boardFields[3] == _currentTurn && _boardFields[4] == _currentTurn && _boardFields[5] == _currentTurn
        || _boardFields[6] == _currentTurn && _boardFields[7] == _currentTurn && _boardFields[8] == _currentTurn
        || _boardFields[0] == _currentTurn && _boardFields[4] == _currentTurn && _boardFields[8] == _currentTurn
        || _boardFields[2] == _currentTurn && _boardFields[4] == _currentTurn && _boardFields[6] == _currentTurn)
        {
            Debug.Log("GameOver");
            _isGameOver = true;
        }
    }
    private void SetNextCharacter()
    {
        _currentTurn = _currentTurn == BoardFieldCharacters.O ? BoardFieldCharacters.X : BoardFieldCharacters.O;
    }
}
