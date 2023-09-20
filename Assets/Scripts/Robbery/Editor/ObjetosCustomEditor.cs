using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Objeto))]
public class ObjetosCustomEditor : Editor
{
    public override bool HasPreviewGUI()
    {
        return true;
    }

    public override void OnPreviewGUI(Rect rect, GUIStyle backgroundStyle)
    {
        if (Event.current.type == EventType.Repaint)
        {
            GUI.DrawTexture(rect, ((Objeto)target).image.texture);
        }
    }

    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        return ((Objeto)target).image.texture;
    }

}
