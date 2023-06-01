using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SpriteExportTexture : MonoBehaviour
{
    [MenuItem("Tools/导出精灵")]
    static void SaveSprite()
    {
        foreach (Object obj in Selection.objects)
        {

            // 创建导出文件夹
            string outPath = Application.dataPath + "/OutSprite/" + obj.name;
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }
            else
            {
                string[] s = Directory.GetFiles(outPath);
                for (int i = 0; i < s.Length; i++)
                {
                    File.Delete(s[i]);
                }
            }
            string selectionPath = AssetDatabase.GetAssetPath(obj);
            TextureImporter importer = TextureImporter.GetAtPath(selectionPath) as TextureImporter;

            Texture2D oTex = AssetDatabase.LoadAssetAtPath<Texture2D>(selectionPath);

            object[] sprites = AssetDatabase.LoadAllAssetsAtPath(selectionPath);
            foreach (SpriteMetaData meta in importer.spritesheet)
            {
                // 创建单独的纹理
                Texture2D tex = new Texture2D((int)meta.rect.width, (int)meta.rect.height, oTex.format, false);
                tex.SetPixels(oTex.GetPixels((int)meta.rect.xMin, (int)meta.rect.yMin,
                    (int)meta.rect.width, (int)meta.rect.height));
                tex.Apply();

                File.WriteAllBytes(outPath + "/" + meta.name + ".png", tex.EncodeToPNG());
                Debug.Log("SaveSprite to " + outPath);
            }
        }
        AssetDatabase.Refresh();
        Debug.Log("SaveSprite Finished");
    }
}