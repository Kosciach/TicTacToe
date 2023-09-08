using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartingCharacterController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] BoardController _boardController;
    [SerializeField] Transform _startingCharacterIndicator;
    [Space(5)]
    [SerializeField] Transform _parentO;
    [SerializeField] Transform _parentX;


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] StartingCharacterSettingsClass _startingCharacterSettings; public StartingCharacterSettingsClass StartingCharacterSettings { get { return _startingCharacterSettings; } }


    [System.Serializable]
    public class StartingCharacterSettingsClass
    {
        public BoardController.BoardFieldCharacters StartingCharacter;
    }

    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + "/StartingCharacterSettings.json")) LoadStartingCharacter();
        else
        {
            _startingCharacterSettings.StartingCharacter = BoardController.BoardFieldCharacters.O;
            SaveStartingCharacter();

            _boardController.ChangeCharacterOnStart(_startingCharacterSettings.StartingCharacter);
            MoveIndicator(_parentO);
        }
    }

    public void SetStartingO()
    {
        if (_startingCharacterSettings.StartingCharacter == BoardController.BoardFieldCharacters.O) return;

        _startingCharacterSettings.StartingCharacter = BoardController.BoardFieldCharacters.O;
        _boardController.ChangeCharacterOnStart(_startingCharacterSettings.StartingCharacter);
        SaveStartingCharacter();
        MoveIndicator(_parentO);

        AudioController.Instance.PlaySound("StartingCharacterChange");
    }
    public void SetStartingX()
    {
        if (_startingCharacterSettings.StartingCharacter == BoardController.BoardFieldCharacters.X) return;

        _startingCharacterSettings.StartingCharacter = BoardController.BoardFieldCharacters.X;
        _boardController.ChangeCharacterOnStart(_startingCharacterSettings.StartingCharacter);
        SaveStartingCharacter();
        MoveIndicator(_parentX);

        AudioController.Instance.PlaySound("StartingCharacterChange");
    }

    private void MoveIndicator(Transform parent)
    {
        _startingCharacterIndicator.LeanScale(Vector3.zero, 0.1f).setOnComplete(() =>
        {
            _startingCharacterIndicator.SetParent(parent);
            _startingCharacterIndicator.SetAsLastSibling();
            _startingCharacterIndicator.localPosition = new Vector3(0, -240, 0);
            _startingCharacterIndicator.LeanScale(Vector3.one * 0.6f, 0.1f);
        });
    }



    private void SaveStartingCharacter()
    {
        string jsonStartingCharacterSettings = JsonUtility.ToJson(_startingCharacterSettings);
        File.WriteAllText(Application.persistentDataPath + "/StartingCharacterSettings.json", jsonStartingCharacterSettings);
    }
    private void LoadStartingCharacter()
    {
        string jsonStartingCharacterSettings = File.ReadAllText(Application.persistentDataPath + "/StartingCharacterSettings.json");
        _startingCharacterSettings = JsonUtility.FromJson<StartingCharacterSettingsClass>(jsonStartingCharacterSettings);

        _boardController.ChangeCharacterOnStart(_startingCharacterSettings.StartingCharacter);
        if (_startingCharacterSettings.StartingCharacter == BoardController.BoardFieldCharacters.O) MoveIndicator(_parentO);
        else MoveIndicator(_parentX);
    }
}
