using System.Collections.Generic;
using System;
using UnityEngine;
/*
 绘制一个三角面

    准备三个顶点
    三个顶点的顺序
    顶点变换到uv坐标（如果模型需要贴图）
    每个顶点的法线
    
    写入到mesh的顶点数组，和三角面顶点顺序数组，uv数组，法线数组
    这样只是绘制一个面（默认）
    要绘制两个面的办法有：
        法1。一开始就关闭背面剔除，这样就不会剔除背面，双面绘制。
        法2。再绘制一个正面。逆向当做背面
 */

namespace EnjoyMoment.MeshCode {

    
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Draw01 : MonoBehaviour {
        
    
        
        List<Vector3> vList = new List<Vector3> {
            Vector3.left,//0
            Vector3.right,//1
            Vector3.up//2
        };




        List<int> orderList = new List<int> {
            0,1,2,2,1,0
        };
        Mesh mesh;
        public Material mat;
        void Start() {
            mesh = GetComponent<MeshFilter>().mesh;
            mesh.vertices = vList.ToArray();
            mesh.triangles = orderList.ToArray();
            GetComponent<MeshRenderer>().material = mat;

            List<Vector2> uvlist = new List<Vector2> {
            new Vector2(vList[0].x/2,vList[0].y),
            new Vector2(vList[1].x/2,vList[1].y),
            new Vector2(vList[2].x/2,vList[2].y),
            };
            mesh.uv = uvlist.ToArray();

        }
    }
}

