using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GeneratrController : MonoBehaviour
{

    /*public GameObject[] prefabsToSpawn; // 两种预制体的数组
    public Transform[] spawnPoints; // 12个生成点的数组
    public float spawnInterval = 4f; // 生成物体的时间间隔
    public GameData gameData;
    private float speed = 4f;*/

    public GameObject[] prefabsToSpawn; // 两种预制体的数组
    public Transform[] spawnPoints; // 12个生成点的数组
    public GameData gameData; // 蘑菇的GameData组件引用
    private float speed = 4f; // 物体的初始移动速度
    private float lastSpawnTime; // 上一次生成物体的时间
    public float spawnInterval = 3f;


    public void StartSpawning()
     {
         InvokeRepeating(nameof(SpawnPrefabs), spawnInterval, spawnInterval);
         Debug.Log("StartSpawning");
     }

     public void StopSpawning()
     {
         CancelInvoke(nameof(SpawnPrefabs));
     }

     void SpawnPrefabs()
     {
         // 从12个物体位置随机选择两个不同的点
         int firstIndex = Random.Range(0, spawnPoints.Length);
         int secondIndex;
         do
         {
             secondIndex = Random.Range(0, spawnPoints.Length);
         } while (secondIndex == firstIndex);

         // 生成第一个预制体
         GameObject firstPrefab = Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)], spawnPoints[firstIndex].position, Quaternion.identity);
         AssignMovement(firstPrefab, spawnPoints[firstIndex]);

         // 生成第二个预制体
         GameObject secondPrefab = Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)], spawnPoints[secondIndex].position, Quaternion.identity);
         AssignMovement(secondPrefab, spawnPoints[secondIndex]);
     }

     void AssignMovement(GameObject prefab, Transform spawnPoint)
     {
         // 根据生成点的位置，分配不同的移动方向
         if (spawnPoint.CompareTag("Top"))
         {
             prefab.AddComponent<MovingObject>().SetDirection(Vector3.down);
         }
         else if (spawnPoint.CompareTag("Bottom"))
         {
             prefab.AddComponent<MovingObject>().SetDirection(Vector3.up);
         }
         else if (spawnPoint.CompareTag("Left"))
         {
             prefab.AddComponent<MovingObject>().SetDirection(Vector3.right);
         }
         else if (spawnPoint.CompareTag("Right"))
         {
             prefab.AddComponent<MovingObject>().SetDirection(Vector3.left);
         }
     }


}


