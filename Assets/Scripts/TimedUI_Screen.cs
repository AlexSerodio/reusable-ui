using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ReusableUI {
    public class TimedUI_Screen : UI_Screen {

		#region Variables

		[Header("Timed Screen Properties")]
		public float screenTime = 2f;
		public UnityEvent onTimeCompleted = new UnityEvent();

		private float startTime;

		#endregion
		
		#region Helper Methods

		public override void StartScreen() {
			base.StartScreen();

			startTime = Time.time;
			StartCoroutine(WaitForTime());
		}

		private IEnumerator WaitForTime() {
			yield return new WaitForSeconds(screenTime);

			if(onTimeCompleted != null) {
				onTimeCompleted.Invoke();
			}
		}

		#endregion
	}
}
