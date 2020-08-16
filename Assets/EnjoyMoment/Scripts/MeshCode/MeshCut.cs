using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 
这个网格切割的例子并不完善。
首先认为滑动的中点必定在物体上，选中点为发射ray（这是有问题的）
设定上不能理解的地方有点多。不够直接
    
 */
namespace EnjoyMoment.MeshCode {
    public class MeshCut : MonoBehaviour {

        Vector3 _startPos;//鼠标滑动开始位置
        Vector3 _endPos;//鼠标滑动结束位置
        Vector3 _hitPos, _dir, _upDir, _planeNormal;
        Mesh _mesh;
        Transform _hitTrans;


        Vector3[] triangleTemp = new Vector3[3];//临时三角形:cun三个顶点(世界坐标)
        float[] _resultTemp = new float[3];//点乘结果

        //左边的模型信息
        List<Vector3> _leftVertices;
        List<int> _leftTriangles;
        List<Vector3> _leftNormals;
        //key:元模型的顶点下标，value：现模型的顶点下标
        Dictionary<int, int> _leftIndexMapping = new Dictionary<int, int>();
        //右边的模型信息
        List<Vector3> _rightVertices;
        List<int> _rightTriangles;
        List<Vector3> _rightNormals;
        //key:元模型的顶点下标，value：现模型的顶点下标
        Dictionary<int, int> _rightIndexMapping = new Dictionary<int, int>();
        void Update() {
            //鼠标按下
            if (Input.GetMouseButtonDown(0)) {
                _startPos = Input.mousePosition;
            }
            //鼠标抬起
            if (Input.GetMouseButtonUp(0)) {
                _endPos = Input.mousePosition;
                Ray();
            }
            DebugDir();
        }

        //为什么要求平面法线=》切面角度？=》平面的向量全部转角度=》切面
        void Ray() {
            var center = (_endPos + _startPos) * 0.5f;
            //从屏幕某个点发射一条射线
            var ray = Camera.main.ScreenPointToRay(center);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                //获取网格对象
                _hitTrans = hit.transform;
                _mesh = hit.transform.GetComponent<MeshFilter>().mesh;

                //平面的第一个向量
                Vector3 dir = (hit.point - Camera.main.transform.position).normalized;
                //平面的第二个向量（垂直与第一个向量） 这个向量为什么就属于切面了呢
                //以vector.up为辅助向量，先得到up在第一个向量（反方向）的投影，再向量相加
                Vector3 upDir = (-dir * Vector3.Dot(Vector3.up, dir) + Vector3.up).normalized;
                //平面法线
                Vector3 planeNormal = Vector3.Cross(dir, upDir);


                //鼠标滑动方向
                Vector3 slideDir = _endPos - _startPos;
                //如果向下滑动，基准轴是-vector.up，反之
                Vector3 baseDir = slideDir.y < 0 ? -Vector3.up : Vector3.up;
                float angle = Vector3.Angle(slideDir, baseDir);

                if (slideDir.y < 0) {
                    angle = slideDir.x > 0 ? angle : -angle;
                }
                else {
                    angle = slideDir.x > 0 ? -angle : angle;
                }
                //角度转弧度，Cos，Sin，要求传入角度的弧度
                angle *= Mathf.Deg2Rad;
                //向量拆分， 单位向量*长度+单位向量*长度 旋转之后的upDir
                upDir = upDir * Mathf.Cos(angle) + planeNormal * Mathf.Sin(angle);
                //Vector3.Cross（）方法的时候算出来的向量的方向是服从左手定则的
                planeNormal = Vector3.Cross(dir, upDir);

                _hitPos = hit.point;
                _dir = dir;
                _upDir = upDir;
                _planeNormal = planeNormal;
            }
            else {
                _hitPos = Vector3.zero;
                _mesh = null;
            }
        }

        //辅助线
        void DebugDir() {
            Debug.DrawRay(_hitPos, _dir, Color.blue);
            Debug.DrawRay(_hitPos, _upDir, Color.red);
            Debug.DrawRay(_hitPos, _planeNormal, Color.yellow);
        }
        //一个模型，切成两个模型，补两个切面，补面：选一个点，连接所有点？
        //切了之后，会有新的顶点。顶点分组？
        void Cut() {
            if (_mesh == null) {
                return;
            }
            CalculateVertexInfor();
            GenerateSection();
        }
        //计算顶点信息
        void CalculateVertexInfor() {
            //判断一个三角面是否被切割：（向量的点乘）
            //问题转换=》如果一个点在三角形外部，那么他们向量的点乘三个结果都一致，小于0或者大于0
            //切割是一条线

            var triangles = _mesh.triangles;
            //var vertices = _mesh.vertices;
            //var normals = _mesh.normals;
            Vector3[] triangle = new Vector3[3];//一个临时的三角形
            for (int i = 0; i < triangles.Length; i += 3) {

                GetDotResult(i, triangles);

                if (_resultTemp[0] >= 0 && _resultTemp[1] >= 0 && _resultTemp[2] >= 0) {
                    //顶点在切割线的左边
                    SaveOldVertex(i, true);
                }
                else if (_resultTemp[0] <= 0 && _resultTemp[1] <= 0 && _resultTemp[2] <= 0) {
                    //顶点做切割线的右边
                    SaveOldVertex(i, false);
                }
                else {
                    //被切割的三角形部分 todo
                    //求三个点的情况，还有与切割线的交点
                    //想知道三角形的哪个和其他的两个点不同。
                    int differentIndex = GetDifferentSidePointIndex();
                    int index = differentIndex + i;

                    for (int j = 0; j < _resultTemp.Length; j++) {
                        if (i == differentIndex) {
                            continue;
                        }
                        GetPointOnSection(_mesh.triangles[index], _mesh.triangles[i + j]);
                    }
                }
            }
        }

        int GetDifferentSidePointIndex() {
            List<int> temp1 = new List<int>(2);
            List<int> temp2 = new List<int>(2);
            for (int i = 0; i < _resultTemp.Length; i++) {
                if (_resultTemp[i] > 0) {
                    temp1.Add(i);
                    //如果大于0的（左边）只有1个长度
                }
                else {
                    temp2.Add(i);
                    //如果小于0的（右边）只有1个长度
                }
            }
            if (temp1.Count == 1) {
                return temp1[0];
            }
            else {
                return temp2[0];
            }

        }


        void GetPointOnSection(int index1, int index2) {
            //计算三角面和切割线的交点

            Vector3 side = _mesh.vertices[index2] - _mesh.vertices[index1];

        }

        void GetDotResult(int index, int[] traingles) {
            for (int i = 0; i < triangleTemp.Length; i++) {
                //从本地到世界坐标的转换
                triangleTemp[i] = _hitTrans.TransformPoint(_mesh.vertices[traingles[index + i]]);
                //todo 为什么是跟_planeNormal点乘（因为切面的法向量是左边（unity的vector。cross））
                _resultTemp[i] = Vector3.Dot(_planeNormal, triangleTemp[i] - _hitPos);
            }
        }
        //保存旧的顶点
        void SaveOldVertex(int index, bool isLeft) {
            if (isLeft) {
                SaveOldVertex(index, _leftTriangles, _leftVertices, _leftNormals, _leftIndexMapping);
            }
            else {
                SaveOldVertex(index, _rightTriangles, _rightVertices, _rightNormals, _rightIndexMapping);
            }
        }
        //处理的单位一个三角面
        void SaveOldVertex(
            int index,
            List<int> curTraingles,
            List<Vector3> curVertices,
            List<Vector3> curNormals,
            Dictionary<int, int> indexMapping) {

            for (int i = 0; i < 3; i++) {
                int vertexIndex = _mesh.triangles[index + i];
                if (!indexMapping.ContainsKey(vertexIndex)) {
                    curVertices.Add(_mesh.vertices[vertexIndex]);
                    curNormals.Add(_mesh.normals[vertexIndex]);
                    curTraingles.Add(vertexIndex);
                    //todo为什么用这个来存新的三角面顺序
                    indexMapping.Add(vertexIndex, curVertices.Count - 1);
                }
            }
        }

        //生成切面
        void GenerateSection() {

        }
    }
}
