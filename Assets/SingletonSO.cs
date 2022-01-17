using UnityEngine;

public class SingletonSO<T> : ScriptableObject where T : SingletonSO<T>
{
	public bool isDead = false;
	private static T _instance = null;

	public static T instance
	{
		get
		{
			if (_instance == null)
			{
				T[] results = Resources.FindObjectsOfTypeAll<T>();
				if (results.Length == 0)
				{
					Debug.LogError("SingletonScriptableObject: Results length is 0 of " + typeof(T).ToString());
					return null;
				}
				if (results.Length > 1)
				{
					Debug.LogError("SingletonScriptableObject: Results length is greater than 1 of " + typeof(T).ToString());
					return null;
				}
				_instance = results[0];
				_instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
			}
			return _instance;
		}
	}

}
