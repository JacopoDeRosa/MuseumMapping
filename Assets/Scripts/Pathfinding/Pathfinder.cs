using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] private PathNode _startNode;
    [SerializeField] private PathNode[] _interactableNodes;
    [SerializeField] private GameObject _character;


    private PathNode _currentNode;
    private PathNode _destination;

    private List<PathNode> _frontier, _newFrontier, _exploredNodes;
    private Stack<PathNode> _moveQueue;

    private void Awake()
    {
        _exploredNodes = new List<PathNode>();
    }

    private void Start()
    {
        _currentNode = _startNode;
        _character.transform.position = _currentNode.transform.position;
    }


    public void MoveTo(int node)
    {
        MoveTo(_interactableNodes[node]);
    }


    private void MoveTo(PathNode node)
    {
        if (_frontier == null)
        {
            _frontier = new List<PathNode>();
            _newFrontier = new List<PathNode>();
        }

        _exploredNodes.Clear();
        _destination = node;
        _frontier.Clear();
        _newFrontier.Clear();
        bool pathFound = false;

        int i = 0;

        while (pathFound == false && i < 120)
        {

         
            if(_frontier.Count == 0)
            { 
                ExploreNode(_currentNode);
                _exploredNodes.Add(_currentNode);
                _frontier.Clear();
                _frontier.AddRange(_newFrontier);
                _newFrontier.Clear();
            }
            else
            {
                foreach (PathNode frontierNode in _frontier)
                {
                    if (ExploreNode(frontierNode))
                    {
                        pathFound = true;
                    }
                }
                _frontier.Clear();
                _frontier.AddRange(_newFrontier);
                _newFrontier.Clear();
            }

            i++;
        }

        _currentNode = node;
    }

    private bool ExploreNode(PathNode node)
    {
        for (int i = 0; i < node.Connections.Length; i++)
        {
            if (_exploredNodes.Contains(node.Connections[i].Destination) || node.Connections[i].Destination == _currentNode) continue;

            node.Connections[i].Destination.Explore(node);

            _newFrontier.Add(node.Connections[i].Destination);
            _exploredNodes.Add(node.Connections[i].Destination);

            if (node.Connections[i].Destination == _destination)
            {
                GenerateMoveQueue();
                StartCoroutine(MovementRoutine());
                return true;
            }
        }
        return false;
    }

    private void GenerateMoveQueue()
    {
        _moveQueue = new Stack<PathNode>();
        PathNode node = _destination;
        PathNode lastNode = null;
        while (node != null)
        {
            _moveQueue.Push(node);
            lastNode = node;
            node = node.ExploredFrom;
            lastNode.ResetNode();
        }
    }

    private IEnumerator MovementRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(1);
        while (_moveQueue.Count > 0)
        {
            _character.transform.position = _moveQueue.Pop().transform.position;
            if (_moveQueue.TryPeek(out PathNode peek))
            {
                _character.transform.rotation = Quaternion.LookRotation(new Vector3(peek.transform.position.x, _character.transform.position.y, peek.transform.position.z) - _character.transform.position);
            }
            yield return wait;
        }
    }
}
