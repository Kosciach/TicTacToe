using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleMan.CoroutineExtensions;
using AYellowpaper.SerializedCollections;

public class BoardController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CanvasGroupController _canvasGroupController;
    [SerializeField] ScoreController _scoreController;
    [SerializeField] TurnIndicatorController _turnIndicatorController;
    [SerializeField] PauseButtonController _pauseButtonController;
    [SerializeField] StartingCharacterController _startingCharacterController;


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] bool _isGameOver; public bool IsGameOver { get { return _isGameOver; } }
    [SerializeField] BoardFieldCharacters _winner;
    [Space(5)]
    [SerializeField] BoardField[] _boardFields = new BoardField[9];
    [Space(5)]
    [SerializeField] BoardFieldCharacters _currentTurn;
    [SerializeField] int _turnCount = 1;
    [Space(5)]
    [SerializeField] List<CharacterIndexesTrackerClass> _characterIndexesTracker = new List<CharacterIndexesTrackerClass>();

    [Space(20)]
    [Header("====Settings====")]
    [SerializeField] GameObject[] _characterGameObjects = new GameObject[2];



    [System.Serializable]
    public class CharacterIndexesTrackerClass
    {
        public string name;
        public List<int> Indexes;
    }
    [System.Serializable]
    public struct BoardField
    {
        public BoardFieldCharacters Character;
        public RectTransform Field;
    }
    public enum BoardFieldCharacters { Empty, O, X }


    private void Awake()
    {
        Application.targetFrameRate = 60;

        transform.localScale = Vector3.zero;
        _canvasGroupController.SetAlpha(false);
        _currentTurn = _startingCharacterController.StartingCharacterSettings.StartingCharacter;

        this.Delay(0.5f, () =>
        {
            transform.LeanScale(Vector3.one, 1).setEaseInOutSine();
            _canvasGroupController.SetAlpha(true, 1);
        });
    }


    public void ChangeCharacterOnStart(BoardFieldCharacters startingCharacter)
    {
        if (_turnCount > 1) return;

        _currentTurn = startingCharacter;
        _turnIndicatorController.MoveIndicator(_currentTurn);
    }

    public void BoardFieldPress(int index)
    {
        if (_boardFields[index].Character != BoardFieldCharacters.Empty || _isGameOver) return;

        SetField(index);
        SpawnCharacterOnCanvas(index);
        CheckOutcome(index);
        SetNextTurn();
    }
    private void SetField(int index)
    {
        _characterIndexesTracker[((int)_currentTurn) - 1].Indexes.Add(index);
        _boardFields[index].Character = _currentTurn;
        _turnCount++;
    }
    private void SpawnCharacterOnCanvas(int index)
    {
        Instantiate(_characterGameObjects[((int)_currentTurn) - 1], _boardFields[index].Field);
    }
    private void CheckOutcome(int index)
    {
        if (_boardFields[0].Character == _currentTurn && _boardFields[1].Character == _currentTurn && _boardFields[2].Character == _currentTurn
        || _boardFields[3].Character == _currentTurn && _boardFields[4].Character == _currentTurn && _boardFields[5].Character == _currentTurn
        || _boardFields[6].Character == _currentTurn && _boardFields[7].Character == _currentTurn && _boardFields[8].Character == _currentTurn
        || _boardFields[0].Character == _currentTurn && _boardFields[3].Character == _currentTurn && _boardFields[6].Character == _currentTurn
        || _boardFields[1].Character == _currentTurn && _boardFields[4].Character == _currentTurn && _boardFields[7].Character == _currentTurn
        || _boardFields[2].Character == _currentTurn && _boardFields[5].Character == _currentTurn && _boardFields[8].Character == _currentTurn
        || _boardFields[0].Character == _currentTurn && _boardFields[4].Character == _currentTurn && _boardFields[8].Character == _currentTurn
        || _boardFields[2].Character == _currentTurn && _boardFields[4].Character == _currentTurn && _boardFields[6].Character == _currentTurn)
        {
            _winner = _currentTurn;
            _boardFields[index].Field.GetChild(0).GetComponent<BoardFieldController>()?.OnWin();
            StartCoroutine(GameOver());
        }
        else if (_turnCount >= 9)
        {
            _winner = BoardFieldCharacters.Empty;

            int OIndex = _characterIndexesTracker[0].Indexes[Random.Range(0, _characterIndexesTracker[0].Indexes.Count)];
            int XIndex = _characterIndexesTracker[1].Indexes[Random.Range(0, _characterIndexesTracker[1].Indexes.Count)];
            _boardFields[OIndex].Field.GetChild(0).GetComponent<BoardFieldController>()?.OnDraw(new Vector3(-350, 0, 0));
            _boardFields[XIndex].Field.GetChild(0).GetComponent<BoardFieldController>()?.OnDraw(new Vector3(350, 0, 0));

            StartCoroutine(GameOver());
        }
    }
    private void SetNextTurn()
    {
        _currentTurn = _currentTurn == BoardFieldCharacters.O ? BoardFieldCharacters.X : BoardFieldCharacters.O;
        _turnIndicatorController.MoveIndicator(_currentTurn);
    }



    private IEnumerator GameOver()
    {
        _isGameOver = true;
        _scoreController.OnGameOver();
        _pauseButtonController.OnGameOver();
        yield return new WaitForSeconds(0.1f);

        transform.LeanScale(Vector3.zero, 1).setEaseInOutSine();
        _canvasGroupController.SetAlpha(false, 1);
        yield return new WaitForSeconds(4);

        ResetBoard();
    }
    private void ResetBoard()
    {
        _scoreController.OnReset(_winner);
        _turnIndicatorController.OnReset();
        _pauseButtonController.OnReset();

        _winner = BoardFieldCharacters.Empty;
        _currentTurn = _startingCharacterController.StartingCharacterSettings.StartingCharacter;
        _turnCount = 0;

        for(int i=0; i<9; i++)
        {
            _boardFields[i].Character = BoardFieldCharacters.Empty;
            if(_boardFields[i].Field.childCount > 0) Destroy(_boardFields[i].Field.GetChild(0).gameObject);
        }

        for(int i=0; i<2; i++) _characterIndexesTracker[i].Indexes.Clear();

        transform.LeanScale(Vector3.one, 1).setEaseInOutSine();
        _canvasGroupController.SetAlpha(true, 1);
        _isGameOver = false;
    }
}
