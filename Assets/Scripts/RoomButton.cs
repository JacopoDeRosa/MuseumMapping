using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomButton : MonoBehaviour
{
    [SerializeField] private RoomDescriptor _room;
    [SerializeField] private FoldingBar _roomUiBar;
    [SerializeField] private RoomUI _ui;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _name;

    private void Awake()
    {
        if (_room == null)
        {
            Destroy(gameObject);
            return;
        }

        _button.onClick.AddListener(OnClick);
        _name.text = _room.Name;
    }

    public void OnClick()
    {
        if (_roomUiBar.Open) return;

        _ui.ReadRoom(_room);
        _roomUiBar.Toggle(true);
    }
}
