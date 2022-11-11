using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class SaveObjectData : EditorWindow
    { 
        public ListObject Root = new ListObject();
        private SerializedObject m_SerializedObject;
        private Vector2 m_Scroll = Vector2.zero;
        private static Transform[] AllObject;
        private string m_SaveName;

        [MenuItem("Tool/Object_Save_Editor")]
        public static void ShowWindow ()
        {
            SaveObjectData window = (SaveObjectData) GetWindow(typeof (SaveObjectData), true, "Save Object Data Editor");
            window.Show();
        }

        void OnGUI ()
        {
            EditorGUILayout.BeginVertical();

            if (GUILayout.Button("Read All Objects", GUILayout.Height(50), GUILayout.MinWidth(160)))
            {
                ReadAllObjects();
            }

            m_SaveName = EditorGUILayout.TextField("Save Name:", m_SaveName);
            if (GUILayout.Button("Save to Json", GUILayout.Height(50), GUILayout.MinWidth(160)))
            {
                string Json_added = JsonUtility.ToJson(Root);
                File.WriteAllText(Application.dataPath + "/" + m_SaveName + ".json", Json_added);
            }

            if (GUILayout.Button("Load Json", GUILayout.Height(50), GUILayout.MinWidth(160)))
            {
                TextAsset json_yazi = new TextAsset(File.ReadAllText(Application.dataPath + "/" + m_SaveName + ".json"));

                Root = JsonUtility.FromJson<ListObject>(json_yazi.text);
            }

            EditorGUILayout.EndVertical();

            m_Scroll = EditorGUILayout.BeginScrollView(m_Scroll);

            EditorGUILayout.BeginVertical();

            ScriptableObject target = this;
            m_SerializedObject = new SerializedObject(target);
            SerializedProperty stringsProperty = m_SerializedObject.FindProperty("root");
            EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
            m_SerializedObject.ApplyModifiedProperties();

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
        }

        private void ReadAllObjects ()
        {
            AllObject = Selection.activeGameObject.GetComponentsInChildren<Transform>();
            var count = AllObject.Length;
            var div = count / 100;
            var a = 0;
            for (var i = 1; i < AllObject.Length + 1; i++)
            {
                var obj = AllObject[i - 1];
                EditorUtility.DisplayProgressBar("SaveAllObjectData.cs", "Reading all objects.", i / div);
                var b = a;
                if (obj.TryGetComponent(out MeshCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "MeshCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        Root.ObjectList[a].MaterialName = renderer.sharedMaterial.name;
                        a++;
                    }
                    if (a == b)
                    {
                        a++;
                    }
                }
                else if (obj.TryGetComponent(out BoxCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());

                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "BoxCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        Root.ObjectList[a].MaterialName = renderer.sharedMaterial.name;
                        a++;
                    }
                    if (a == b)
                    {
                        a++;
                    }
                }
                else if (obj.TryGetComponent(out CapsuleCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());

                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "CapsuleCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        Root.ObjectList[a].MaterialName = renderer.sharedMaterial.name;

                        a++;
                    }
                    if (a == b)
                    {
                        a++;
                    }
                }
                else if (obj.TryGetComponent(out SphereCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());

                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "SphereCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        Root.ObjectList[a].MaterialName = renderer.sharedMaterial.name;
                        a++;
                    }
                    if (a == b)
                    {
                        a++;
                    }
                }
                else if (obj.TryGetComponent(out TerrainCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());

                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "TerrainCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    a++;
                }
                else if (obj.TryGetComponent(out WheelCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());

                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "WheelCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        Root.ObjectList[a].MaterialName = renderer.sharedMaterial.name;
                        a++;
                    }
                    if (a == b)
                    {
                        a++;
                    }
                }
                else if (obj.TryGetComponent(out MeshRenderer renderer2))
                {
                    Root.ObjectList.Add(new ObjectUnit());

                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].MaterialName = renderer2.sharedMaterial.name;
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);

                    a++;
                }
            }

            Array.Clear(AllObject, 0, count);

            EditorUtility.ClearProgressBar();
        }
    }
}