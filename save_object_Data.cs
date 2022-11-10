
//Editor Window Class
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;



public class save_object_Data : EditorWindow
{
 
    public  Obje_List  root = new Obje_List();
    private SerializedObject so;
    Vector2 scroll = Vector2.zero;
    private static Transform[] Allobject;
    private string save_name;
    
    [MenuItem("Tool/Object_Save_Editor")]
    public static void ShowWindow()
    {
        save_object_Data window = (save_object_Data) EditorWindow.GetWindow(typeof(save_object_Data), true, "Save Object Data Editor");
        window.Show();
    }

    void OnGUI()
    {
        
        
        
        EditorGUILayout.BeginVertical();
        
        if (GUILayout.Button( "Read All Objects",GUILayout.Height(50),GUILayout.MinWidth(160)))
        {
            read_all_objects();
        }
        save_name = EditorGUILayout.TextField("Save Name:", save_name);
        if (GUILayout.Button ( "Save to Json",GUILayout.Height(50),GUILayout.MinWidth(160)))
        {
            string Json_added = JsonUtility.ToJson(root);
            File.WriteAllText(Application.dataPath +"/"+save_name+".json",Json_added);
        }
        
        if (GUILayout.Button ("Load Json",GUILayout.Height(50),GUILayout.MinWidth(160)))
        {
            TextAsset json_yazi = new TextAsset(File.ReadAllText(Application.dataPath +"/"+save_name+".json"));
                
            root = JsonUtility.FromJson<Obje_List>(json_yazi.text);
            

        }
        
        EditorGUILayout.EndVertical();
        
        scroll = EditorGUILayout.BeginScrollView(scroll);
        
        EditorGUILayout.BeginVertical();
            
        ScriptableObject target = this;
        so = new SerializedObject(target);
        SerializedProperty stringsProperty = so.FindProperty("root");
        EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
        so.ApplyModifiedProperties();
        
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
    
    }



    [MenuItem("Tool/Object_Save_Editor_fonksiyonu")]
    public void read_all_objects()
    {
        Debug.Log("fonksiyon-baslangic");
        Allobject = Selection.activeGameObject.GetComponentsInChildren<Transform>();
        int a = 0;
        Debug.Log("foreach-start-oncesi");
        foreach (var obje in Allobject)
        {

            Debug.Log("foreach-start");
            int b = a;
            if (obje.TryGetComponent(out MeshCollider Collider))
            {
                Debug.Log("foreach-mesh-var");


                root.Obje_list.Add(new Obje_Unit());


                root.Obje_list[a].Object_name = obje.name;
                root.Obje_list[a].Collider_name = "MeshCollider";
                root.Obje_list[a].Layer_name = LayerMask.LayerToName(obje.gameObject.layer);
                Debug.Log("foreach-meshcollider");
                Debug.Log(a);

                if (obje.TryGetComponent(out MeshRenderer renderer))
                {
                    Debug.Log("foreach-meshcollider-renderer");
                    root.Obje_list[a].Materyal_name = renderer.sharedMaterial.name;
                     a++;
                    
                }

                if (a == b)
                {
                    a++;
                }

            }
            else if (obje.TryGetComponent(out BoxCollider Collider2))
            {

                root.Obje_list.Add(new Obje_Unit());


                root.Obje_list[a].Object_name = obje.name;
                root.Obje_list[a].Collider_name = "BoxCollider";
                root.Obje_list[a].Layer_name = LayerMask.LayerToName(obje.gameObject.layer);
                Debug.Log("foreach-meshcollider2");
                if (obje.TryGetComponent(out MeshRenderer renderer))
                {

                    root.Obje_list[a].Materyal_name = renderer.sharedMaterial.name;
                    Debug.Log("foreach-meshcollider-renderer2");
                    
                    a++;
                    
                }

                if (a == b)
                {
                    a++;
                }

            }

            else if (obje.TryGetComponent(out CapsuleCollider Collider3))
            {

                root.Obje_list.Add(new Obje_Unit());


                root.Obje_list[a].Object_name = obje.name;
                root.Obje_list[a].Collider_name = "CapsuleCollider";
                root.Obje_list[a].Layer_name = LayerMask.LayerToName(obje.gameObject.layer);
                Debug.Log("foreach-meshcollider3");
                if (obje.TryGetComponent(out MeshRenderer renderer))
                {

                    root.Obje_list[a].Materyal_name = renderer.sharedMaterial.name;
                    Debug.Log("foreach-meshcollider-renderer3");
                    
                    a++;
                    
                }

                if (a == b)
                {
                    a++;
                }

            }

            else if (obje.TryGetComponent(out SphereCollider Collider4))
            {

                root.Obje_list.Add(new Obje_Unit());


                root.Obje_list[a].Object_name = obje.name;
                root.Obje_list[a].Collider_name = "SphereCollider";
                root.Obje_list[a].Layer_name = LayerMask.LayerToName(obje.gameObject.layer);
                Debug.Log("foreach-meshcollider4");
                if (obje.TryGetComponent(out MeshRenderer renderer))
                {

                    root.Obje_list[a].Materyal_name = renderer.sharedMaterial.name;
                    Debug.Log("foreach-meshcollider-renderer4");
                    
                    a++;
                    
                }

                if (a == b)
                {
                    a++;
                }

            }
             else if (obje.TryGetComponent(out TerrainCollider Collider5))
             {
 
                 root.Obje_list.Add(new Obje_Unit());
 
 
                 root.Obje_list[a].Object_name = obje.name;
                 root.Obje_list[a].Collider_name = "TerrainCollider";
                 root.Obje_list[a].Layer_name = LayerMask.LayerToName(obje.gameObject.layer);
                 Debug.Log("foreach-terriancollider");
                  a++;
                 
 
 
                 Debug.Log("foreach-end");
             }
             else if (obje.TryGetComponent(out WheelCollider Collider6))
             {
 
                 root.Obje_list.Add(new Obje_Unit());
 
 
                 root.Obje_list[a].Object_name = obje.name;
                 root.Obje_list[a].Collider_name = "WheelCollider";
                 root.Obje_list[a].Layer_name = LayerMask.LayerToName(obje.gameObject.layer);
                 Debug.Log("foreach-meshcollider6");
                 if (obje.TryGetComponent(out MeshRenderer renderer))
                 {
 
                     root.Obje_list[a].Materyal_name = renderer.sharedMaterial.name;
                     Debug.Log("foreach-meshcollider-renderer6");
                    
                     a++;
                     
                 }
 
 
                 if (a == b)
                 {
                     a++;
                 }
 
                 Debug.Log("foreach-end");
             }
             else if (obje.TryGetComponent(out MeshRenderer renderer2))
             {
                 root.Obje_list.Add(new Obje_Unit());
 
 
                 Debug.Log("foreach-just-renderer");
                 root.Obje_list[a].Object_name = obje.name;
                 root.Obje_list[a].Materyal_name = renderer2.sharedMaterial.name;
                 root.Obje_list[a].Layer_name = LayerMask.LayerToName(obje.gameObject.layer);
                 
 
                 a++;
 
             }


        }



    }
}