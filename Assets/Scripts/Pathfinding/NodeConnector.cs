using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class NodeConnector
{
    [SerializeField] private PathNode _originNode, _destinationNode;
    [SerializeField] private float _lenght;

    public NodeConnector(PathNode origin, PathNode destination, float lenght)
    {
        _originNode = origin;
        _destinationNode = destination;
        _lenght = lenght;
    }

    public PathNode Destination { get => _destinationNode; }


}
