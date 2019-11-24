using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unitomata {

	public enum Side { Right=0, Up, Left, Down }

	[System.Serializable]
	public class Note {

		public Side side;
		public int px;
		public int py;

		public void Rotate(){
			side = (Side)(((int)side + 1) % 4);
		}
	}

	[RequireComponent(typeof(AudioSource))]
	public class Unitomata : MonoBehaviour {
		
		public float bpm = 300f;

		public AudioClip[] clips;

		[SerializeField]
		[HideInInspector]
		public List<Note> notes;

		AudioSource source;

		public bool playing = true;

		void OnValidate(){
			if (bpm < 1)
				bpm = 1;
		}

		void Awake () {
			source = GetComponent<AudioSource> ();
		}

		void OnEnable(){
			StartCoroutine (Run ());
		}
		void OnDisable(){
			StopAllCoroutines ();
		}

		public void PlayNote(int i){
			if (i >= 0 && i < clips.Length && clips [i])
				source.PlayOneShot (clips [i]);
		}

		IEnumerator Run(){

			var waitplaying = new WaitUntil (() => playing && enabled);

			float currentBPM = bpm;
			WaitForSeconds waitbpm = new WaitForSeconds (60f / bpm);

			while (true) {
				
				if(bpm != currentBPM){
					currentBPM = bpm;
					waitbpm = new WaitForSeconds (60f / bpm);
				}
				//yield return new WaitForSeconds (60f / bpm);
				yield return waitbpm;

				//yield return new WaitUntil (() => playing && enabled);
				yield return waitplaying;

				int n = clips.Length;

				for (int i = 0; i < notes.Count; i++) {
					
					var note = notes [i];

					if (note.px < 0 || note.px >= n || note.py < 0 || note.py >= n)
						continue;

					switch (note.side) {
					case Side.Right:
						if (note.px == n-1) {
							note.side = Side.Left;
							note.px -= 1;
						} else {
							note.px += 1;
						}
						break;
					case Side.Up:
						if (note.py == n-1) {
							note.side = Side.Down;
							note.py -= 1;
						} else {
							note.py += 1;
						}
						break;
					case Side.Left:
						if (note.px == 0) {
							note.side = Side.Right;
							note.px += 1;
						} else {
							note.px -= 1;
						}
						break;
					case Side.Down:
						if (note.py == 0) {
							note.side = Side.Up;
							note.py += 1;
						} else {
							note.py -= 1;
						}
						break;
					}
				}

				for (int i = 0; i < notes.Count; i++) {
					var n1 = notes [i];
					if (n1.side == Side.Right && n1.px == clips.Length - 1 || n1.side == Side.Left && n1.px == 0) {
						PlayNote (n1.py);
					}
					if (n1.side == Side.Up && n1.py == clips.Length - 1 || n1.side == Side.Down && n1.py == 0) {
						PlayNote (n1.px);
					}
				}

				for (int i = 0; i < notes.Count; i++) {
					var n1 = notes [i];
					for (int j = i+1; j < notes.Count; j++) {
						var n2 = notes [j];

						if (n1.px == n2.px && n1.py == n2.py) {
							n1.Rotate ();
							n2.Rotate ();
						}
					}
				}

			}
		}

	}


}

