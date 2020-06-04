using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class EasyCollision2D : MonoBehaviour
{
    public Vector2 pos;

    public int PointsCount = 2;
    List<GameObject> Points = new List<GameObject>();

    [Tooltip("Blank GameObject for Collider Points")]
    [SerializeField] GameObject PointObj;
    [Tooltip("Blank GameObject for BoxCollider")]
    [SerializeField] GameObject ColliderBlank;

    [SerializeField] ColliderType TypeOfCollider;

    public void PointsCountUpdate()
    {
        switch(TypeOfCollider)
        {
            case ColliderType.BoxCollider2D:
                PointsCount = 2;
                break;
            
            case ColliderType.EdgeCollider2D:
                PointsCount = 100;
                break;
            
            default:
                Debug.LogError("Wtf man? What the fuck is with ColliderType???", this);
                break;
            
        }
        
    }
    public void ResetList()
    {
        Points.Clear();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("EC_Point");

        foreach(GameObject _object in objects)
        {
            DestroyImmediate(_object);
        }
    }

    public void CreatePoint()
    {
        // if(SnapToGrid && Grid != null)
        // {
        //     pos = PositionConverts(pos);
        // }
        
        GameObject point = Instantiate(PointObj, pos, Quaternion.identity);
        point.transform.SetParent(transform);
        Points.Add(point);
        print(point.transform.position);
    }

    // Vector2 PositionConverts(Vector2 _pos)
    // {
    //     Vector3Int newPos = Grid.WorldToCell(_pos);
    //     return Grid.CellToWorld(newPos);
    // }

    public void CreateCollider()
    {
        if(Points.Count == 0)
        {
            Debug.LogError("You have not attached any Points", this);
            return;
        }

        GameObject ColliderObject = Instantiate(ColliderBlank, Vector2.zero, Quaternion.identity);
        ColliderObject.transform.SetParent(transform);

        CheckColliderType(ColliderObject);
    }

    void CheckColliderType(GameObject ColliderObject)
    {
        if(TypeOfCollider == ColliderType.BoxCollider2D && Points.Count == PointsCount)
        {
            ColliderObject.AddComponent(typeof(BoxCollider2D));
            BoxColliderSetup(ColliderObject.GetComponent<BoxCollider2D>());
        }

        if(TypeOfCollider == ColliderType.EdgeCollider2D && Points.Count > 0)
        {
            ColliderObject.AddComponent(typeof(EdgeCollider2D));
            EdgeColliderSetup(ColliderObject.GetComponent<EdgeCollider2D>());
        }
    }


    void BoxColliderSetup(BoxCollider2D _collider)
    {
        Vector2 _firstPoint = Points[0].transform.position;
        Vector2 _secondPoint = Points[1].transform.position;
        ResetList();


        _collider.size = Vector2.one;
        _collider.offset = new Vector2((_secondPoint.x + _firstPoint.x) / 2, (_secondPoint.y + _firstPoint.y) / 2);
        _collider.size = new Vector2(Mathf.Abs(_secondPoint.x - _firstPoint.x), Mathf.Abs((_secondPoint.y - _firstPoint.y)));
    }
    

    void EdgeColliderSetup(EdgeCollider2D _collider)
    {
        Vector2[] PointsPos = new Vector2[Points.Count + 1];
        
        for(int i = 0; i < Points.Count; i++)
        {
            PointsPos[i] = Points[i].transform.position;
        }

        PointsPos[PointsPos.Length - 1] = PointsPos[0];

        ResetList();

        _collider.points = PointsPos;
    }
}

enum ColliderType
{
        BoxCollider2D,
        EdgeCollider2D
}
