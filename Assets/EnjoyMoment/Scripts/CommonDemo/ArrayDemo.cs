/*
CreateBy:     wgy
CreateTime:   2020/08/04 22:51:54
Description:  开发常用技巧使用1维数组代替二维数组
*/

using UnityEngine;

public class ArrayDemo : MonoBehaviour
{
    public GameObject prefab;
    public const int width = 5;//x的长度
    public GameObject[] cubeArr = new GameObject[width * width];

    private void Start() {
        for (int i = 0; i < cubeArr.Length; i++) {
            cubeArr[i] = Instantiate<GameObject>(prefab);
            cubeArr[i].gameObject.name = $"({i % 5},{i / 5})";
            cubeArr[i].transform.position = new Vector3(i % 5, i / 5, 0);
        }
        //隐藏（4,3）
        GetCube(4, 3).gameObject.SetActive(false);

    }

    public GameObject GetCube(int x, int y) {
        var index = x + width * y;//公式
        return cubeArr[index];
    }
}
