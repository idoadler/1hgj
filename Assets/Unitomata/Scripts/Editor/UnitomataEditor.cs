using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace Unitomata{


	[CustomEditor(typeof(Unitomata))]
	public class UnitomataEditor : Editor {
		
		private static bool editOpen = true;

		Texture icon_right;
		Texture icon_circle;

		void OnEnable(){
			icon_right = Resources.Load ("unitomata_icon_right") as Texture;
			icon_circle = Resources.Load ("unitomata_icon_circle") as Texture;
		}

		public override void OnInspectorGUI () {
			DrawDefaultInspector ();

			if (editOpen = EditorGUILayout.Foldout (editOpen, "Editor")) {

				this.serializedObject.Update ();

				float w = Mathf.Min (200, EditorGUIUtility.currentViewWidth - 40);

				GUILayout.BeginHorizontal ();
				GUILayout.FlexibleSpace ();
				var rect = EditorGUILayout.GetControlRect (GUILayout.Width (w), GUILayout.Height (w));
				GUILayout.FlexibleSpace ();
				GUILayout.EndHorizontal ();

				GUI.Box (rect, GUIContent.none);
				Handles.DrawSolidRectangleWithOutline (rect, new Color (0.2f, 0.2f, 0.2f), Color.white);

				var notes = this.serializedObject.FindProperty ("notes");
				int nclips = this.serializedObject.FindProperty ("clips").arraySize;

				Handles.color = Color.white;
				for (int i = 1; i < nclips; i++) {
					float ti = Mathf.InverseLerp (0, nclips, i);

					var ph1 = new Vector2 (0f, ti);
					var ph2 = new Vector2 (1f, ti);
					Handles.DrawLine (Rect.NormalizedToPoint (rect, ph1), Rect.NormalizedToPoint (rect, ph2));

					var pv1 = new Vector2 (ti, 0f);
					var pv2 = new Vector2 (ti, 1f);
					Handles.DrawLine (Rect.NormalizedToPoint (rect, pv1), Rect.NormalizedToPoint (rect, pv2));
				}

				for (int i = 0; i < notes.arraySize; i++) {
					var note = notes.GetArrayElementAtIndex (i);

					int px = note.FindPropertyRelative ("px").intValue;
					int py = note.FindPropertyRelative ("py").intValue;
					Side side = (Side)note.FindPropertyRelative ("side").enumValueIndex;

					if (px >= 0 && px < nclips && py >= 0 && py < nclips) {
						float tpx = Mathf.InverseLerp (0, nclips, px);
						float tpy = Mathf.InverseLerp (0, nclips, nclips - 1 - py);
						float subwidth = rect.width / nclips;
						var subrect = new Rect (Rect.NormalizedToPoint (rect, new Vector2 (tpx, tpy)), new Vector2 (subwidth, subwidth)); 
						if (CountNotes (notes, px, py) == 1) {
							DrawArrow (subrect, side);
						} else {
							DrawCircle (subrect);
						}
					}
				}

				if (Event.current.type == EventType.MouseDown && rect.Contains (Event.current.mousePosition)) {

					var mousePos = Rect.PointToNormalized (rect, Event.current.mousePosition);
					int mousePx = (int)Mathf.Lerp (0, nclips, mousePos.x);
					int mousePy = nclips - 1 - (int)Mathf.Lerp (0, nclips, mousePos.y);

					var foundNoteIndex = FindNoteIndex (notes, mousePx, mousePy);

					if (foundNoteIndex >= 0) {
						var foundNote = notes.GetArrayElementAtIndex (foundNoteIndex);
						Side side = (Side)foundNote.FindPropertyRelative ("side").enumValueIndex;
						if (side == Side.Down) {
							notes.DeleteArrayElementAtIndex (foundNoteIndex);
						} else {
							side = (Side)(((int)side + 1) % 4);
							foundNote.FindPropertyRelative ("side").enumValueIndex = (int)side;
						}
					} else {
						notes.InsertArrayElementAtIndex (notes.arraySize);
						var newNote = notes.GetArrayElementAtIndex (notes.arraySize - 1);
						newNote.FindPropertyRelative ("side").enumValueIndex = (int)Side.Right;
						newNote.FindPropertyRelative ("px").intValue = mousePx;
						newNote.FindPropertyRelative ("py").intValue = mousePy;
					}
				}

				GUILayout.BeginHorizontal ();
				if (GUILayout.Button ("Clear")) {
					notes.ClearArray ();
				}
				if (GUILayout.Button ("Scale")) {
					notes.ClearArray ();
					notes.arraySize = nclips;
					for (int i = 0; i < nclips; i++) {
						var note = notes.GetArrayElementAtIndex (i);
						note.FindPropertyRelative ("px").intValue = i;
						note.FindPropertyRelative ("py").intValue = i;
						note.FindPropertyRelative ("side").enumValueIndex = (int)Side.Down;
					}
				}
				if(GUILayout.Button("Add Random")){
					if (notes.arraySize < nclips * nclips) {
						var positions = Enumerable.Range (0, nclips * nclips).ToList();
						for (int i = 0; i < notes.arraySize; i++) {
							var note = notes.GetArrayElementAtIndex (i);
							int px = note.FindPropertyRelative ("px").intValue;
							int py = note.FindPropertyRelative ("py").intValue;
							int index = py * nclips + px;
							positions.Remove (index);
						}
						var newIndex = positions [Random.Range (0, positions.Count)];
						notes.arraySize += 1;

						var newNote = notes.GetArrayElementAtIndex (notes.arraySize - 1);
						newNote.FindPropertyRelative ("side").enumValueIndex = Random.Range (0, 4);
						newNote.FindPropertyRelative ("px").intValue = newIndex % nclips;
						newNote.FindPropertyRelative ("py").intValue = newIndex / nclips;
					}
				}
				GUILayout.EndHorizontal ();

				this.serializedObject.ApplyModifiedProperties ();

			}

		}
		
		int FindNoteIndex(SerializedProperty notes, int wantedPx, int wantedPy){
			for (int i = 0; i < notes.arraySize; i++) {
				var note = notes.GetArrayElementAtIndex (i);
				int px = note.FindPropertyRelative ("px").intValue;
				int py = note.FindPropertyRelative ("py").intValue;

				if (px == wantedPx && py == wantedPy) {
					return i;
				}
			}	
			return -1;
		}
		int CountNotes(SerializedProperty notes, int wantedPx, int wantedPy){
			int count = 0;
			for (int i = 0; i < notes.arraySize; i++) {
				var note = notes.GetArrayElementAtIndex (i);
				int px = note.FindPropertyRelative ("px").intValue;
				int py = note.FindPropertyRelative ("py").intValue;

				if (px == wantedPx && py == wantedPy) {
					count++;
				}
			}	
			return count;
		}

		void DrawCircle(Rect rect){
			if (icon_circle) {
				GUI.DrawTexture (rect, icon_circle);
			} else {
				DrawCircle2 (rect);
			}
		}
		void DrawArrow(Rect rect, Side side){
			if (icon_right) {
				var matrix = GUI.matrix;
				GUIUtility.RotateAroundPivot (((int)side) * -90, rect.center);
				GUI.DrawTexture (rect, icon_right);
				GUI.matrix = matrix;
			} else {
				DrawArrow2 (rect, side);
			}
		}
		void DrawCircle2(Rect rect){
			Handles.DrawSolidDisc (rect.center, Vector3.forward, 0.3f * rect.width);
		}
		void DrawArrow2(Rect rect, Side side){
			
			var rot = Quaternion.Euler (0, 0, ((int)side) * 90);

			Vector2 dir1 = rot * new Vector2 (-0.4f, 0.4f) * rect.width;
			Vector2 dir2 = rot * new Vector2 (-0.4f, -0.4f) * rect.width;
			Vector2 dir3 = rot * new Vector2 (0.4f, 0.0f) * rect.width;

			dir1.y = -dir1.y;
			dir2.y = -dir2.y;
			dir3.y = -dir3.y;

			var p1 = rect.center + dir1;
			var p2 = rect.center + dir2;
			var p3 = rect.center + dir3;

			Handles.DrawAAConvexPolygon (p1, p2, p3);
		}

	}

}