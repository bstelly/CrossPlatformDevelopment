using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BrettTools
{
    public class PrefabEditorWindow : EditorWindow
    {
        public List<Button> buttons;

        [MenuItem("Tools/BrettTools/Prefab Spawner")]

        static void Init()
        {
            Debug.Log("Make Window");
            var window = GetWindow<PrefabEditorWindow>();
            window.titleContent = new GUIContent("Prefab Spawner");
            window.Show();
        }

        private void OnGUI()
        {
            DrawButtons();
            ProcessEvents(Event.current);
        }

        private void OnEnable()
        {
            buttons = new List<Button>
            {
                new Button(new Rect(10, 10, 200, 200)),
                new Button(new Rect(230, 10, 200, 200)),
                new Button(new Rect(10, 230, 200, 200)),
                new Button(new Rect(230, 230, 200, 200)),
            };
        }

        private void DrawButtons()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Draw();
            }
        }


        private void ProcessEvents(Event e)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].ProcessEvents(e);
            }
        }


    }
}
