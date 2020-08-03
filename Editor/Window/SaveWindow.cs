using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Editor.Window
{
    public class SaveWindow : EditorWindow
    {
        private float _saveTime = 300f;
        private float _nextSave = 0f;

        [MenuItem ("Window/Common/Save Window", false, 1)]
        public static void ShowSaveWindow()
        {
            SaveWindow sw = GetWindow<SaveWindow>("SAVER");
            sw.minSize = new Vector2(1, 0.1f);
            sw.Save();
        }

        private void OnGUI()
        {
            int timeToSave = (int)(_nextSave - EditorApplication.timeSinceStartup);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Save each:");
            if (int.TryParse(EditorGUILayout.TextField(_saveTime.ToString()), out var num))
            {
                _saveTime = num;
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Next save in:");
            GUILayout.Label(Mathf.Max(0, timeToSave) + " sec");
            EditorGUILayout.EndHorizontal();

            if (!EditorApplication.isPlaying
                && (GUILayout.Button("SAVE") || EditorApplication.timeSinceStartup > _nextSave))
            {
                Save();
            }
            Repaint();
        }

        private void Save()
        {
            EditorSceneManager.SaveOpenScenes();
            Debug.Log("Auto Saved " + DateTime.Now.ToLongTimeString());
            _nextSave = (int)(EditorApplication.timeSinceStartup + _saveTime);
        }
    }
}