using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RoomButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _image;
    [SerializeField] private Room _room;
    [SerializeField] private RoomDescriptionUI _roomDescription;
    [SerializeField] private GameObject _roomFocusCam, _mapCam;

    public event Action<Room> onClick;

    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
        if(_room == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            SetRoom(_room);
        }
    }
    public void OnClick()
    {
        if (_room == null || _roomFocusCam.activeInHierarchy) return;
        _roomFocusCam.transform.position = _room.transform.position;
        _roomFocusCam.SetActive(true);
        _roomDescription.Toggle(true);
        _roomDescription.SetRoom(_room);
        _mapCam.SetActive(false);
        onClick?.Invoke(_room);
    }
    public void SetRoom(Room room)
    {
        if (room == null) return;
        _name.text = room.Name;
        _image.sprite = room.Icon;
    }

    private void Update()
    {
        if (_room == null) return;
        transform.position = Camera.main.WorldToScreenPoint(_room.transform.position);
    }
}
