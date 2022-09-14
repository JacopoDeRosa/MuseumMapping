using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText, _description;
    [SerializeField] private Image _imageA, _imageB, _imageC;
    [SerializeField] private Pathfinder _pathfinder;
    [SerializeField] private Button _moveButton;

    private RoomDescriptor _room;

    private void Awake()
    {
        _moveButton.onClick.AddListener(TakeMeThere);
    }

    public void ReadRoom(RoomDescriptor room)
    {
        _room = room;
        _nameText.text = room.Name;
        _description.text = room.Description;
        _imageA.sprite = room.PictureA;
        _imageB.sprite = room.PictureB;
        _imageC.sprite = room.PictureC;
    }

    private void TakeMeThere()
    {
        if (_room == null) return;

        _pathfinder.MoveTo(_room.NodeIndex);
    }
}
