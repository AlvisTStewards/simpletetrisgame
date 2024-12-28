using UnityEngine;

public class TetrominoSpawner : MonoBehaviour
{
    public GameObject[] tetrominoPrefabs;

    void Start()
    {
        SpawnTetromino();
    }

    public void SpawnTetromino()
    {
        int index = Random.Range(0, tetrominoPrefabs.Length);
        Instantiate(tetrominoPrefabs[index], transform.position, Quaternion.identity);
    }
}

