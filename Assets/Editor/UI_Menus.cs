using UnityEditor;
using UnityEngine;

namespace ReusableUI
{
    public class UI_Menus : MonoBehaviour {

		private const string UI_GROUP_PATH = "Assets/Prefabs/UI_Group.prefab";
		private const string CANNOT_FIND_MESSAGE = "Cannot find UI Group Prefab.";

		[MenuItem("Reusable-UI/Create UI Group")]
		public static void CreateUIGroup() {
			GameObject uiGroup = AssetDatabase.LoadAssetAtPath<GameObject>(UI_GROUP_PATH);
			if(uiGroup) {
				GameObject newUIGroup = Instantiate(uiGroup);
				newUIGroup.name = "UI Group";
			} else {
				EditorUtility.DisplayDialog("UI Tools Warning", CANNOT_FIND_MESSAGE, "Ok");
			}
		}
		
	}
}
