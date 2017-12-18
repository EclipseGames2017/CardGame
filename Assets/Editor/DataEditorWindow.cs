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

        int indent = 30;

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
            if (GUILayout.Button("Load Card Data", GUILayout.Width(200f)))
            {
                LoadCardData();
            }
            if (GUILayout.Button("Save Card Data", GUILayout.Width(200f)))
            {
                SaveCardData();
            }
            GUILayout.EndHorizontal();

            if (cards == null)
            {
                return;
            }
            
            scrollViewPosition = GUILayout.BeginScrollView(scrollViewPosition);
            for (int i = 0; i < cards.Length; i++)
            {
                string title = i + ": " + cards[i].Name;
                foldoutStates[i] = EditorGUILayout.Foldout(foldoutStates[i], title, true);
                if (foldoutStates[i])
                {
                    #region Name
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(indent);
                    cards[i].Name = EditorGUILayout.TextField("Name", cards[i].Name, GUILayout.Width(400f - indent));
                    GUILayout.EndHorizontal();
                    #endregion
                    #region Description
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(indent);
                    cards[i].Description = EditorGUILayout.TextField("Description", cards[i].Description, GUILayout.Width(400f - indent));
                    GUILayout.EndHorizontal();
                    #endregion
                    #region Remove Button
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(indent);
                    if (GUILayout.Button("Remove Card", GUILayout.Width(200f)))
                    {
                        if (EditorUtility.DisplayDialog("Remove " + cards[i].Name + "?","Are you sure you want to remove " + cards[i].Name + " from the list?  This cannot be undone.", "Remove", "Cancel"))
                        {
                            cards.RemoveAt(i);
                            foldoutStates.RemoveAt(i);
                        }
                    }
                    GUILayout.EndHorizontal();
                    #endregion
                }
            }

            if (GUILayout.Button("Add New Card", GUILayout.Width(400f)))
            {
                cards.AddNewCard();
                foldoutStates.Add(true);
            }

            GUILayout.EndScrollView();
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
                string json = JsonUtility.ToJson(cards, false);
                sw.Write(json);
            }

            AssetDatabase.ImportAsset(dataPath, ImportAssetOptions.ForceUpdate);
        }
    }
}