using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    List<Node> path = new List<Node>();
    [SerializeField] [Range(0f,5f)]float movementSpeed =1f;
    GridManager gridManager;
    PathFinder pathFinder;
    Enemy enemy;
    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
    }
    void Awake() {
        enemy = GetComponent<Enemy>();   
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    void RecalculatePath(bool resetPath)
    {
        //path = Path.instance.pathElements;
        Vector2Int coordinates = new Vector2Int();
        if(resetPath)
        {
            coordinates = pathFinder.StartCoordinates;
        }else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathFinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath());
    }
    void ReturnToStart()
    {
        if(path.Count>0)
        {
            transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
        }
    }
    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        for(int i=1;i<path.Count ;i++)
        {
            Vector3 startPosition = gameObject.transform.position;
            Vector3 endingPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            transform.LookAt(endingPosition);
            while(travelPercent < 1f){
                travelPercent += Time.deltaTime * movementSpeed;
                transform.position = Vector3.Lerp(startPosition,endingPosition,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
}
