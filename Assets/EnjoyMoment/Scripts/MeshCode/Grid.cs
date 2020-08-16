using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (MeshFilter), typeof (MeshRenderer))]
public class Grid : MonoBehaviour {

    public int xSize, ySize; //顶点的数量取决于网格的大小
    Vector3[] vertices; //顶点数组 顶点数量取决于网格的大小 （x+1）*（y+1）
    int[] triangles; //三角面索引数组大小

    Vector2[] uv;//uv

    Vector3[] normals;//法线

    private Mesh mesh;
    void Awake () {

        StartCoroutine (Generate ());
    }
    void Start () {

    }

    private IEnumerator Generate () {
        WaitForSeconds wait = new WaitForSeconds (0.05f);
        GetComponent<MeshFilter> ().mesh = mesh = new Mesh ();
        mesh.name = "Procedural Grid";
        //顶点处理
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for (int i = 0, y = 0; y <= ySize; y++) {
            for (int x = 0; x <= xSize; x++, i++) {
                vertices[i] = new Vector3 (x, y);
                yield return wait;
            }
        }
        mesh.vertices = vertices;
        //顶点索引顺序处理:
        //以一个正方形为单位绘制，先画一行，然后在y循环，画几行
        int[] triangles = new int[xSize * ySize * 6];
        // for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
        // 	for (int x = 0; x < xSize; x++, ti += 6, vi++) {
        // 		triangles[ti] = vi;
        // 		triangles[ti + 3] = triangles[ti + 2] = vi + 1;
        // 		triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
        // 		triangles[ti + 5] = vi + xSize + 2;
        // 	}
        // }
        //index：正方形index
        for (int y = 0,index=0,i = 0; y < ySize; y++,index++) {
            for (int x = 0 ; x < xSize; x++, index++,i += 6) {
                triangles[i] = index;
                triangles[i + 1] = index + xSize + 1;
                triangles[i + 2] = index + 1;

                yield return wait;
                mesh.triangles = triangles;

                triangles[i + 3] = index + xSize + 1;
                triangles[i + 4] = index + xSize + 2;
                triangles[i + 5] = index + 1;

                yield return wait;
                mesh.triangles = triangles;
            }
        }

        //法线 
        normals = new Vector3[vertices.Length];
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i]=Vector3.up;
        }
        mesh.normals=normals;

        //顶点映射到uv
        uv=new Vector2 [vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            uv[i]=new Vector2((float)vertices[i].x/xSize,(float)vertices[i].y/ySize);
        }
        mesh.uv=uv;
        

    }

    private void OnDrawGizmos () {
        if (vertices == null) {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++) {
            Gizmos.DrawSphere (vertices[i], 0.1f);
        }
    }
}