using UnityEngine;
using UnityEngine.EventSystems;


namespace Client.Scripts.Algorithms.MonoBehaviours
{
	/// <summary>
	/// Use it in new unity UI system for fix drag threshold in different scale factor.
	/// </summary>
	public class DragThresholdFixer : MonoBehaviour
	{
		[SerializeField]
		private EventSystem myEventSystem;

		[SerializeField]
		private Canvas myCanvas;

		[SerializeField]
		private float pixelDragThreshold = 5;

		// Use this for initialization
		void Awake()
		{
			myEventSystem.pixelDragThreshold = (int)(pixelDragThreshold * myCanvas.scaleFactor);
		}
	}
}