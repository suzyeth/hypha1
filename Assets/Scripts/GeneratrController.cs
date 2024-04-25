using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GeneratrController : MonoBehaviour
{

    /*public GameObject[] prefabsToSpawn; // ����Ԥ���������
    public Transform[] spawnPoints; // 12�����ɵ������
    public float spawnInterval = 4f; // ���������ʱ����
    public GameData gameData;
    private float speed = 4f;*/

    public GameObject[] prefabsToSpawn; // ����Ԥ���������
    public Transform[] spawnPoints; // 12�����ɵ������
    public GameData gameData; // Ģ����GameData�������
    private float speed = 4f; // ����ĳ�ʼ�ƶ��ٶ�
    private float lastSpawnTime; // ��һ�����������ʱ��
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
         // ��12������λ�����ѡ��������ͬ�ĵ�
         int firstIndex = Random.Range(0, spawnPoints.Length);
         int secondIndex;
         do
         {
             secondIndex = Random.Range(0, spawnPoints.Length);
         } while (secondIndex == firstIndex);

         // ���ɵ�һ��Ԥ����
         GameObject firstPrefab = Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)], spawnPoints[firstIndex].position, Quaternion.identity);
         AssignMovement(firstPrefab, spawnPoints[firstIndex]);

         // ���ɵڶ���Ԥ����
         GameObject secondPrefab = Instantiate(prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)], spawnPoints[secondIndex].position, Quaternion.identity);
         AssignMovement(secondPrefab, spawnPoints[secondIndex]);
     }

     void AssignMovement(GameObject prefab, Transform spawnPoint)
     {
         // �������ɵ��λ�ã����䲻ͬ���ƶ�����
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


