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
        public static void ShowWindow()
        {
            SaveObjectData window = (SaveObjectData) GetWindow(typeof(SaveObjectData), true, "Save Object Data Editor");
            window.Show();
        }

        void OnGUI()
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
                
                Root.ObjectList.Clear();
                Root = JsonUtility.FromJson<ListObject>(json_yazi.text);
            }
            
            if (GUILayout.Button("Parse Colliders", GUILayout.Height(50), GUILayout.MinWidth(160)))
            {
               ParseAllObjects();
            }

            EditorGUILayout.EndVertical();

            m_Scroll = EditorGUILayout.BeginScrollView(m_Scroll);

            EditorGUILayout.BeginVertical();

            ScriptableObject target = this;
            m_SerializedObject = new SerializedObject(target);
            SerializedProperty stringsProperty = m_SerializedObject.FindProperty("Root");
            EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
            m_SerializedObject.ApplyModifiedProperties();

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndScrollView();
        }

        private void ReadAllObjects()
        {
            
            Root.ObjectList.Clear();
            AllObject = Selection.activeGameObject.GetComponentsInChildren<Transform>();
            var count = AllObject.Length;
            var div = count / 100;
            var a = 0;
            var MatNo = 0;
            for (var i = 1; i < AllObject.Length + 1; i++)
            {
                var obj = AllObject[i - 1];
                EditorUtility.DisplayProgressBar("SaveAllObjectData.cs", "Reading all objects.", i / 100);
                var b = a;
                if (obj.TryGetComponent(out MeshCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());
                    
                    Root.ObjectList[a].ObjectID = obj.GetInstanceID();
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "MeshCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        for (var z = 1; z < renderer.sharedMaterials.Length +1 ; z++)
                        {
                            var obj_mat = renderer.sharedMaterials[z-1 ];
                            Root.ObjectList[a].Materials.Add(new MaterialUnit());
                            Root.ObjectList[a].Materials[z-1].MaterialName = obj_mat.name;
                            Root.ObjectList[a].Materials[z-1].MaterialID = obj_mat.GetInstanceID();
                            
                        } 
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
                    
                    Root.ObjectList[a].ObjectID = obj.GetInstanceID();
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "BoxCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        for (var z = 1; z < renderer.sharedMaterials.Length +1 ; z++)
                        {
                            var obj_mat = renderer.sharedMaterials[z-1 ];
                            Root.ObjectList[a].Materials.Add(new MaterialUnit());
                            Root.ObjectList[a].Materials[z-1].MaterialName = obj_mat.name;
                            Root.ObjectList[a].Materials[z-1].MaterialID = obj_mat.GetInstanceID();
                            
                        } 
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
                    
                    Root.ObjectList[a].ObjectID = obj.GetInstanceID();
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "CapsuleCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        for (var z = 1; z < renderer.sharedMaterials.Length +1 ; z++)
                        {
                            var obj_mat = renderer.sharedMaterials[z-1 ];
                            Root.ObjectList[a].Materials.Add(new MaterialUnit());
                            Root.ObjectList[a].Materials[z-1].MaterialName = obj_mat.name;
                            Root.ObjectList[a].Materials[z-1].MaterialID = obj_mat.GetInstanceID();
                            
                        } 
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

                    Root.ObjectList[a].ObjectID = obj.GetInstanceID();
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "SphereCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        for (var z = 1; z < renderer.sharedMaterials.Length +1 ; z++)
                        {
                            var obj_mat = renderer.sharedMaterials[z-1 ];
                            Root.ObjectList[a].Materials.Add(new MaterialUnit());
                            Root.ObjectList[a].Materials[z-1].MaterialName = obj_mat.name;
                            Root.ObjectList[a].Materials[z-1].MaterialID = obj_mat.GetInstanceID();
                            
                        } 
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

                    Root.ObjectList[a].ObjectID = obj.GetInstanceID();
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "TerrainCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    a++;
                }
                else if (obj.TryGetComponent(out WheelCollider _))
                {
                    Root.ObjectList.Add(new ObjectUnit());

                    Root.ObjectList[a].ObjectID = obj.GetInstanceID();
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].ColliderName = "WheelCollider";
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    
                    if (obj.TryGetComponent(out MeshRenderer renderer))
                    {
                        for (var z = 1; z < renderer.sharedMaterials.Length +1 ; z++)
                        {
                            var obj_mat = renderer.sharedMaterials[z-1 ];
                            Root.ObjectList[a].Materials.Add(new MaterialUnit());
                            Root.ObjectList[a].Materials[z-1].MaterialName = obj_mat.name;
                            Root.ObjectList[a].Materials[z-1].MaterialID = obj_mat.GetInstanceID();
                            
                        } 
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

                    Root.ObjectList[a].ObjectID = obj.GetInstanceID();
                    Root.ObjectList[a].ObjectName = obj.name;
                    Root.ObjectList[a].LayerName = LayerMask.LayerToName(obj.gameObject.layer);
                    
                    
                        for (var z = 1; z < renderer2.sharedMaterials.Length +1 ; z++)
                        {
                            var obj_mat = renderer2.sharedMaterials[z-1 ];
                            Root.ObjectList[a].Materials.Add(new MaterialUnit());
                            Root.ObjectList[a].Materials[z-1].MaterialName = obj_mat.name;
                            Root.ObjectList[a].Materials[z-1].MaterialID = obj_mat.GetInstanceID();
                            
                        } 
                        
                        a++;

                }
            }

            Array.Clear(AllObject, 0, count);

            EditorUtility.ClearProgressBar();
        }



        private void ParseAllObjects()
        {   AllObject = Selection.activeGameObject.GetComponentsInChildren<Transform>();
            var count = Root.ObjectList.Count;
            var div = count / 100;
            var a = 0;
            
            /// for one start
                
            for (var i = 1; i < AllObject.Length + 1; i++)
            {
                var obj = AllObject[i - 1];
//                EditorUtility.DisplayProgressBar("ParseAllObjectData.cs", "Parsing all objects.", i / div);
                var b = a;
                
                
            /// for two start
                
                for (var c = 1; c < Root.ObjectList.Count + 1; c++)
                {
                    var unit = Root.ObjectList[c - 1];
//                EditorUtility.DisplayProgressBar("ParseAllObjectData.cs", "Parsing all objects.", i / div);
                    Debug.Log(obj.name + ":::"+unit.ObjectName);
                    Debug.Log("for two if oncesi");

                    if (obj.GetInstanceID() == unit.ObjectID)
                    {
                        Debug.Log("for two start");
                        switch (unit.ColliderName)
                        {
                            case "MeshCollider":
                            {
                                if (obj.TryGetComponent(out MeshCollider _meshCollider) == false)
                                {
                                    obj.gameObject.AddComponent<MeshCollider>();

                                }

                            }
                                break;
                            case "BoxCollider":
                            {
                                if (obj.TryGetComponent(out BoxCollider _boxCollider) == false)
                                {
                                    obj.gameObject.AddComponent<BoxCollider>();

                                }

                            }
                                break;
                            case "CapsuleCollider":
                            {
                                if (obj.TryGetComponent(out CapsuleCollider _boxCollider) == false)
                                {
                                    obj.gameObject.AddComponent<CapsuleCollider>();

                                }

                            }
                                break;
                            case "SphereCollider":
                            {
                                if (obj.TryGetComponent(out SphereCollider _boxCollider) == false)
                                {
                                    obj.gameObject.AddComponent<SphereCollider>();

                                }

                            }
                                break;
                            case "TerrainCollider":
                            {
                                if (obj.TryGetComponent(out TerrainCollider _boxCollider) == false)
                                {
                                    obj.gameObject.AddComponent<TerrainCollider>();

                                }

                            }
                                break;
                            case "WheelCollider":
                            {
                                if (obj.TryGetComponent(out WheelCollider _boxCollider) == false)
                                {
                                    obj.gameObject.AddComponent<WheelCollider>();

                                }

                            }
                                break;

                             
                        } // switch
                        Debug.Log("switch two start");
                    }// for two
                    
                }// for one
                Debug.Log("for one end");
                a++;
                Debug.Log(a);
             

              //  EditorUtility.ClearProgressBar();
            }
            Array.Clear(AllObject, 0,  AllObject.Length  );
        }
    }

}
