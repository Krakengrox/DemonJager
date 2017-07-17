using UnityEngine;
using System.Collections.Generic;


public class UtilMethods
{
    /// <summary>
	/// Finds a component in the object's parents.
	/// </summary>
	/// <returns>The component in any of the parents.</returns>
	/// <param name="go">Game object.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
    
    public static Transform FindInChildren(Transform transform, string objectName)
    {
        if (transform.name == objectName)
            return transform;

        foreach (Transform child in transform)
        {
            Transform result = FindInChildren(child, objectName);

            if (result != null)
                return result;
        }

        return null;
    }

    public static Vector3 ClampRotation(Vector3 rotation)
    {
        if (rotation.x > 180)
            rotation.x -= 360f;

        if (rotation.y > 180)
            rotation.y -= 360f;

        if (rotation.z > 180)
            rotation.z -= 360f;

        return rotation;
    }

    public static float MakeAnglePositive(float rotation)
    {
        rotation = rotation % 360f;

        if (rotation < 0)
            rotation += 360f;

        return rotation;
    }

    public static float NormalizeAngle(float angle)
    {
        while (angle <= -180f) angle += 360f;
        while (angle > 180f) angle -= 360f;

        return angle;
    }

    public static float SignedAngle(Vector3 a, Vector3 b)
    {
        float angle = Vector3.Angle(a, b);
        return angle * Mathf.Sign(Vector3.Cross(a, b).y);
    }

}

public static class UtilExtentions
{
    public static GameObject FindInChildren(this GameObject gameObject, string objectName)
    {
        return UtilMethods.FindInChildren(gameObject.transform, objectName).gameObject;
    }
}