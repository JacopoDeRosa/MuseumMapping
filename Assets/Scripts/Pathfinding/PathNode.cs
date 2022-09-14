using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathNode : MonoBehaviour
{
 [SerializeField] private string _name;
 [SerializeField] private PathNode[] _connectedNodes;
 [HideInInspector] private NodeConnector[] _connections;

public string NodeName {get => _name;}
public NodeConnector[] Connections {get => _connections;}

#region Exploration Function
      private PathNode _exploredFrom;
      public PathNode ExploredFrom {get => _exploredFrom;}   
      public void Explore(PathNode explorer)
      {
        if(explorer == null)
        {
            Debug.LogError("Explorer for this node is null");
            return;
        }
        _exploredFrom = explorer;
      }
 #endregion

 private void OnValidate() 
 {

    if(_connectedNodes != null && _connections == null || _connectedNodes.Length != _connections.Length)
    {
    _connections = new NodeConnector[_connectedNodes.Length];
    for (int i = 0; i < _connectedNodes.Length; i++)
  {
    _connections[i] = new NodeConnector(this, _connectedNodes[i], GetNodeDistance(_connectedNodes[i]));
  }
    }

  if(string.IsNullOrEmpty(_name))
  {
     name = "Unnamed Node";
  }
  else
  {
     name = "Node: " + NodeName;
  }
 }

 public void ResetNode()
 {
    _exploredFrom = null;
 }

 private float GetNodeDistance(PathNode node) 
 {
    return Vector3.Distance(transform.position, node.transform.position);
 }
}