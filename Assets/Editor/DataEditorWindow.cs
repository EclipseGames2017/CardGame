using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EclipseStudios.CardGame
{
    public class DataEditorWindow : EditorWindow
    {
        public DataEditorWindow()
        {
            this.titleContent = new GUIContent("Card Editor");
        }

        [MenuItem("Tools/CardEditor")]
        static void Init()
        {
            DataEditorWindow dew = EditorWindow.GetWindow<DataEditorWindow>();
            dew.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Hello, World!");
        }
    }
}