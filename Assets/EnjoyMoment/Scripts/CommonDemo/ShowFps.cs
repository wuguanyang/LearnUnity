using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnjoyMoment.CommonDemo {
    /// <summary>
    /// 显示update的帧率
    /// </summary>
    public class ShowFps : MonoBehaviour {

        public float updateInterval = 0.5f;//更新的频率
        float accum, timeleft;
        int frames;
        string stringFps;
        void Start () {
            timeleft = updateInterval;
        }

        void Update () {
            timeleft -= Time.deltaTime;
            accum += Time.timeScale / Time.deltaTime;
            ++frames;
            if (timeleft <= 0.0) {
                float fps = accum / frames;
                string format = string.Format ("{0:F2} FPS", fps);
                stringFps = format;
                timeleft = updateInterval;
                accum = 0.0f;
                frames = 0;
            }
        }

        void OnGUI () {
            GUIStyle gUIStyle = GUIStyle.none;
            gUIStyle.fontSize = 30;
            gUIStyle.normal.textColor = Color.red;
            gUIStyle.alignment = TextAnchor.UpperCenter;

            Rect rt = new Rect (40, 0, 100, 100);
            GUI.Label (rt, stringFps, gUIStyle);
        }
    }
}