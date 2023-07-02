using UnityEditor;
using UnityEngine;

namespace RPGCharacterAnims
{
	class SetupInputLayers:AssetPostprocessor
	{
		static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
		{
		}
	}

	public class SetupMessageWindow:EditorWindow
	{
		void OnGUI()
		{
		}
	}
}