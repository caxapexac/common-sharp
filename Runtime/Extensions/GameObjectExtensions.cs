using UnityEngine;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Ensure that GameObject have component.
        /// </summary>
        /// <returns>Wanted component.</returns>
        /// <param name="go">Target GameObject.</param>
        /// <typeparam name="T">Any unity-based component.</typeparam>
        public static T EnsureGetComponent<T> (this GameObject go) where T : Component {
            if ((object) go == null) {
                return null;
            }
            var c = go.GetComponent<T> ();
            if ((object) c == null) {
                c = go.AddComponent<T> ();
            }
            return c;
        }
    }
}