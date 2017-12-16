using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace EclipseStudios.CardGame
{
    public class DataEditorWindow : EditorWindow
    {
        const string dataPath = "Assets/Data/card_data.json";
        CardList cards;

        Vector2 scrollViewPosition = Vector2.zero;

        List<bool> foldoutStates;

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
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Load Card Data"))
            {
                LoadCardData();
            }
            if (GUILayout.Button("Save Card Data"))
            {
                SaveCardData();
            }
            GUILayout.EndHorizontal();

            if (cards == null)
            {
                return;
            }

            ChangeArraySize(EditorGUILayout.IntField("Card Count", cards.Length));

            scrollViewPosition = GUILayout.BeginScrollView(scrollViewPosition);
            for (int i = 0; i < cards.Length; i++)
            {
                string title = (cards[i].Name_En == "") ? "Card " + i : cards[i].Name_En;
                foldoutStates[i] = EditorGUILayout.Foldout(foldoutStates[i], title, true);
                if (foldoutStates[i])
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(30);
                    cards[i].Name_En = EditorGUILayout.TextField("Name (English)", cards[i].Name_En);
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(30);
                    cards[i].Name = EditorGUILayout.TextField("Name", cards[i].Name);
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(30);
                    cards[i].Occupation = EditorGUILayout.TextField("Occupation", cards[i].Occupation);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndScrollView();
        }

        void ChangeArraySize(int newSize)
        {
            // TODO: If the new size is larger, just resize it
            // TODO: If the new size is smaller, show a warning that data will be lost
        }

        void LoadCardData()
        {
            using (StreamReader sr = new StreamReader(dataPath))
            {
                string json = sr.ReadToEnd();
                cards = JsonUtility.FromJson<CardList>(json);
            }

            foldoutStates = new List<bool>();
            for (int i = 0; i < cards.Length; i++)
            {
                foldoutStates.Add(false);
            }
        }

        void SaveCardData()
        {
            using (StreamWriter sw = new StreamWriter(dataPath))
            {
                string json = JsonUtility.ToJson(cards);
                sw.Write(json);
            }

            AssetDatabase.ImportAsset(dataPath, ImportAssetOptions.ForceUpdate);
        }
    }
}