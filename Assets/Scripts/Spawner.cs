using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Wall _wallBlock;
    [SerializeField] private Block _blockBlock;
    [SerializeField] private WinBlock _finishBlock;
    [SerializeField] private int _levelCount;

    private void Start()
    {
        BuildTower();
    }

    private void BuildTower()
    {
        GameObject currentPoint = gameObject;

        for (int i = 0; i < _levelCount; i++)
        {
            currentPoint = BuildWall(currentPoint, _wallBlock.gameObject);
            currentPoint = BuildWall(currentPoint, _blockBlock.gameObject);
        }
        currentPoint = BuildWall(currentPoint, _finishBlock.gameObject);
    }

    private GameObject BuildWall(GameObject currentWall, GameObject nextWall)
    {
        return Instantiate(nextWall, GetBuildPoint(currentWall.transform, nextWall.transform), Quaternion.identity, transform);
    }

    private Vector3 GetBuildPoint(Transform currentWall, Transform nextWall)
    {
        return new Vector3(
            transform.position.x,
            currentWall.transform.position.y + currentWall.transform.localScale.y / 2 + nextWall.transform.localScale.y / 2,
            transform.position.z);
    }
}
