using FPS.InventorySystem;
using UnityEditor;
using UnityEngine;

namespace FPS
{
    [CustomEditor(typeof(Inventory))]
    public class InventoryEditor : Editor
	{
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Inventory inv = (Inventory)target;

            for (int i = 0; i < inv.ItemsCount; i++)
            {
                EditorGUILayout.LabelField("Item Name", inv.Items[i].Data.Name + " SlotID: " + inv.Items[i].Data.SlotId.ToString());
            }
            
            Repaint();
        }
    }
}