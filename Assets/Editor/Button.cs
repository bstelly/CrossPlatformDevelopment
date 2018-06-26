using UnityEditor;
using UnityEngine;

namespace BrettTools
{
    public class Button : MonoBehaviour
    {
        public Object prefab;
        public GameObject spawnedPrefab;
        public Rect rect;
        public Vector3 position;
        public Vector3 posInput;

        public Button(Rect position)
        {
            rect = position;
        }

        public void ProcessEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0)
                    {
                        if (rect.Contains(e.mousePosition))
                        {
                            GUI.changed = true;
                            Create();
                        }
                        else
                        {
                            GUI.changed = true;
                        }
                    }

                    break;
            }
        }

        public void Draw()
        {
            GUI.Box(rect, "");
            GUILayout.BeginArea(rect);
            prefab = EditorGUILayout.ObjectField(prefab, typeof(GameObject), false);
            posInput = EditorGUILayout.Vector3Field("Position", posInput);
            GUILayout.EndArea();
            if (spawnedPrefab != null)
                spawnedPrefab.transform.position = posInput;
        }

        public void Create()
        {
            if (prefab != null)
            {
                spawnedPrefab = Instantiate(prefab, posInput, Quaternion.identity) as GameObject;
            }
        }
    }
}