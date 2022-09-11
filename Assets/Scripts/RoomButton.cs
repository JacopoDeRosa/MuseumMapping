using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    [SerializeField] private RoomDescriptor _room;
    [SerializeField] private FoldingBar _roomUiBar;
    [SerializeField] private RoomUI _ui;
    [SerializeField] private Button _button;

    private void Awake()
    {
        if (_room == null) Destroy(gameObject);

        _button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (_roomUiBar.Open) return;

        _ui.ReadRoom(_room);
        _roomUiBar.Toggle(true);
    }
}
