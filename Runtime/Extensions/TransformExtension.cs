using UnityEngine;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class TransformExtension
    {
        public static void LookAt(this Transform me, Vector3 target, bool ignoreX, bool ignoreY, bool ignoreZ)
        {
            Vector3 position = me.position;
            Vector3 result = new Vector3(ignoreX ? position.x : target.x, ignoreY ? position.y : target.y, ignoreZ ? position.z : target.z);
            me.LookAt(result);
        }
        
        public static void LookAtTopDown(this Transform me, Vector3 target)
        {
            me.LookAt(target, false, true, false);
        }
        
        public static void LookAt2D(this Transform me, Vector2 target)
        {
            Vector2 dir = target - (Vector2)me.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            me.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public static void LookAt2D(this Transform me, Transform target)
        {
            me.LookAt2D(target.position);
        }

        public static void LookAt2D(this Transform me, GameObject target)
        {
            me.LookAt2D(target.transform.position);
        }

        /// <summary>
        /// Sets the position of a transform's children to zero.
        /// </summary>
        /// <param name="transform">Parent transform.</param>
        /// <param name="recursive">Also reset ancestor positions?</param>
        public static void ResetChildPositions(this Transform transform, bool recursive = false)
        {
            foreach (Transform child in transform)
            {
                child.position = Vector3.zero;

                if (recursive)
                {
                    child.ResetChildPositions(true);
                }
            }
        }

        /// <summary>
        /// Sets the x component of the transform's position.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x">Value of x.</param>
        public static void SetX(this Transform transform, float x)
        {
            var position = transform.position;
            position = new Vector3(x, position.y, position.z);
            transform.position = position;
        }

        /// <summary>
        /// Sets the y component of the transform's position.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="y">Value of y.</param>
        public static void SetY(this Transform transform, float y)
        {
            var position = transform.position;
            position = new Vector3(position.x, y, position.z);
            transform.position = position;
        }

        /// <summary>
        /// Sets the z component of the transform's position.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="z">Value of z.</param>
        public static void SetZ(this Transform transform, float z)
        {
            var position = transform.position;
            position = new Vector3(position.x, position.y, z);
            transform.position = position;
        }
        
        /// <summary>
        /// Find GameObject with name in recursive hierarchy.
        /// </summary>
        /// <returns>Transform of found GameObject.</returns>
        /// <param name="target">Root of search.</param>
        /// <param name="name">Name to search.</param>
        public static Transform FindRecursive (this Transform target, string name) {
            if ((object) target == null || string.CompareOrdinal (target.name, name) == 0) {
                return target;
            }
            Transform retVal = null;
            for (var i = target.childCount - 1; i >= 0; i--) {
                retVal = target.GetChild (i).FindRecursive (name);
                if ((object) retVal != null) {
                    break;
                }
            }
            return retVal;
        }

        /// <summary>
        /// Find GameObject with tag in recursive hierarchy.
        /// </summary>
        /// <returns>Transform of found GameObject.</returns>
        /// <param name="target">Root of search.</param>
        /// <param name="tag">Tag to search.</param>
        public static Transform FindRecursiveByTag (this Transform target, string tag) {
            if ((object) target == null || target.CompareTag (tag)) {
                return target;
            }
            Transform retVal = null;
            for (var i = target.childCount - 1; i >= 0; i--) {
                retVal = target.GetChild (i).FindRecursiveByTag (tag);
                if ((object) retVal != null) {
                    break;
                }
            }
            return retVal;
        }
    }
}