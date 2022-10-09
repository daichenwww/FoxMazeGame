using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// a unit wall is 1 * 1 * 0.3
public class mazeGenerate : MonoBehaviour
{
    static public int N = 20;
    static public int M = 20;
    public float SIZE = 1.0f;
    public GameObject wall;

    private bool[,] visited = new bool[N, M];
    private bool[,,] destroyWall = new bool[N+1, M+1, 2]; // 0 -> up, 1 -> left
    private int[] dx = {0, 0, -1, 1}, dy = {-1, 1, 0, 0}; 

    void Generate(int x, int y)
    {
        int dir = Random.Range(0,4);
        for (int i = 0; i < 4; i++){
            int X = x + dx[(i+dir)%4], Y = y + dy[(i+dir)%4];
            if (X >= 0 && X < N && Y >= 0 && Y < M && !visited[X, Y]) {
                visited[X, Y] = true;
                switch ((i+dir)%4)
                {
                    case 0: 
                        destroyWall[X, Y, 0] = true;
                        break;
                    case 1:
                        destroyWall[x, y, 0] = true;
                        break;
                    case 2:
                        destroyWall[x, y, 1] = true;
                        break;
                    case 3: 
                    default:
                        destroyWall[X, Y, 1] = true;
                        break;
                }
                Generate(X, Y);
            }
            
       }
       
    }

    void DrawWall()
    {
        for (int i = 0; i <= N; i++){
            if (i < N-1) Instantiate(wall, new Vector3(-N/2 + i, 0, -M/2 + (-1) + SIZE/2), Quaternion.identity);
            for (int j = 0; j < M; j++){
                if (i < N) {
                    if (!destroyWall[i, j, 0]) Instantiate(wall, new Vector3(-N/2 + i * SIZE, 0, -M/2 + j + SIZE/2), Quaternion.identity);
                    if (!destroyWall[i, j, 1]) Instantiate(wall, new Vector3(-N/2 + i - SIZE/2, 0, -M/2 + j), Quaternion.AngleAxis(90, Vector3.up));
                }
                else Instantiate(wall, new Vector3(-N/2 + i - SIZE/2, 0, -M/2 + j), Quaternion.AngleAxis(90, Vector3.up));
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {   
        visited[0, 0] = true;
        Generate(0, 0);
        DrawWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
