using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    [Range(.001f, 20f)]
    [SerializeField] float speed = 1f;

    public event Action onEnemyReachEnd;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();

        Transform waypointParent = GameObject.FindWithTag("Path").transform;
        foreach(Transform child in waypointParent)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        Waypoint prevWaypoint = path[0];
        for(int i = 1; i < path.Count; i++)
        {
            this.transform.LookAt(path[i].transform.position);
            float timer = 0;
            while(timer < 1f)
            {
                timer += Time.deltaTime * speed;
                this.transform.position =
                    Vector3.Lerp(prevWaypoint.transform.position, path[i].transform.position, timer / 1f);
                yield return new WaitForEndOfFrame();
            }
            this.transform.position = path[i].transform.position;
            prevWaypoint = path[i];

        }

        FinishPath();
    }

    void FinishPath()
    {
        onEnemyReachEnd?.Invoke();
        gameObject.SetActive(false);
    }
}
