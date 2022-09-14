using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField, TextArea] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Sprite _pictureA, _pictureB, _pictureC, _pictureD;
    [SerializeField] private int _nodeIndex;

    public string Name { get => _name; }
    public string Description { get => _description; }
    public Sprite Icon { get => _icon; }
    public Sprite PictureA { get => _pictureA; }
    public Sprite PictureB { get => _pictureB; }
    public Sprite PictureC { get => _pictureC; }
    public Sprite PictureD { get => _pictureD; }
    public int NodeIndex { get => _nodeIndex; }

    private void OnValidate()
    {
        name = "Room: " + _name;
    }
}
