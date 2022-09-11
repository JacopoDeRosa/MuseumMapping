using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDescriptor : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _pictureA, _pictureB, _pictureC;
    [SerializeField , TextArea] private string _description;
    [SerializeField] private int _nodeIndex;

    public string Name { get => _name; }
    public string Description { get => _description; }
    public Sprite PictureA { get => _pictureA; }
    public Sprite PictureB { get => _pictureB; }
    public Sprite PictureC { get => _pictureC; }
    public int NodeIndex { get => _nodeIndex; }
}
