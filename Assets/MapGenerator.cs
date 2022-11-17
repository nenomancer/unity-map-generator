using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject _point;

    [SerializeField]
    GameObject _tile;

    GameObject _startPoint;
    GameObject _currentPoint;
    GameObject _nextPoint;

    GameObject[] _points;

    [SerializeField]
    List<GameObject> _possiblePoints;

    [SerializeField]
    int _mapHeight = 10;

    [SerializeField]
    int _mapWidth = 10;

    [SerializeField]
    Vector2Int _startPointCoords = new Vector2Int(1, 3);

    [SerializeField]
    Vector2Int _endPoint = new Vector2Int(4, 7);

    [SerializeField]
    int numOfPossiblePoints;

    Color _startPointColor = new Color(35, 100, 255);
    Color _currentEndPointColor = new Color(35, 250, 125);

    private void Start()
    {
        GenerateGrid();
        // GenerateStartPoint();
        _startPoint = GeneratePoint(_startPointCoords.x, _startPointCoords.y);

        Debug.Log("started");
        _startPoint.name = "_startPoint";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("FUck");
            GeneratePossiblePoints();
        }
    }

    void GenerateGrid()
    {
        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                Instantiate(_tile, new Vector3(x, 0, y), Quaternion.identity, transform);
            }
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Vector3 startPoint = new Vector3(_startPointCoords.x, 0, _startPointCoords.y);
    //     Vector3 endPoint = new Vector3(_endPoint.x, 0, _endPoint.y);

    //     for (int y = 0; y < _mapHeight; y++)
    //     {
    //         for (int x = 0; x < _mapWidth; x++)
    //         {
    //             Gizmos.DrawWireCube(new Vector3(x, 0, y), new Vector3(1, 0, 1));
    //         }
    //     }
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawSphere(startPoint, .2f);

    //     Gizmos.color = Color.green;
    //     Gizmos.DrawSphere(endPoint, .2f);

    //     Gizmos.color = Color.green;
    //     Gizmos.DrawLine(startPoint, endPoint);

    //     GeneratePossiblePoints();
    // }

    // void GenerateStartPoint()
    // {
    //     Vector3 startPoint = new Vector3(_startPointCoords.x, 0, _startPointCoords.y);
    //     _startPoint = Instantiate(_point, startPoint, Quaternion.identity);
    //     _currentPoint = _startPoint;
    // }

    GameObject GeneratePoint(int x, int y)
    {
        Vector3 position = new Vector3(x, 0, y);
        GameObject point = Instantiate(_point, position, Quaternion.identity);

        return point;
    }

    void GeneratePossiblePoints()
    {
        for (int i = numOfPossiblePoints; i > 0; i--)
        {
            GameObject possiblePoint = GeneratePoint(
                Random.Range(0, _mapWidth),
                Random.Range(0, _mapHeight)
            );
            _possiblePoints.Add(possiblePoint as GameObject);
        }
    }

    Vector3 GenerateRandomPosition(int min)
    {
        int xPosition = Random.Range(0, _mapWidth);
        int yPosition = Random.Range(min, _mapHeight);

        return new Vector3(xPosition, 0, yPosition);
    }
}
