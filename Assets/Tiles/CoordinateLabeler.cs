using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    [SerializeField] Color exploredColor = Color.green;
    [SerializeField] Color pathColor = new Color(1f,0f,0.7f);
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Tile waypoint;
    GridManager gridManager;
    bool isEnabled = true;

    void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();
        waypoint = GetComponentInParent<Tile>();
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        DisplayCoordinates();
    }
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ShowHideLabels();
    }
    void DisplayCoordinates()
    {
        if(gridManager == null){ return; }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x +","+coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
    void SetLabelColor()
    {
        if(gridManager == null){ return; }

        Node node = gridManager.GetNode(coordinates);
        if(node == null){ return; }
        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }else
        {
            label.color = defaultColor;
        }


        /*if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }else
        {
            label.color=blockedColor;
        }*/
    }
    void ShowHideLabels(){
        /*if(Input.GetKey(KeyCode.F1)){
            label.enabled = true;
        }
        if(Input.GetKey(KeyCode.F2)){
            label.enabled = false;
        }*/
        if(Input.GetKeyDown(KeyCode.C))
        {
            /*if(isEnabled)
            {
                isEnabled = false;
                label.enabled = false;
            }else
            {
                isEnabled = true;
                label.enabled = true;
            }*/
            label.enabled = !label.IsActive();
        }
    }
}
