using UnityEngine;

public class Toolbox : Singleton<Toolbox> {
	protected Toolbox () {} // guarantee this will be always a singleton only - can't use the constructor!

	private void Awake()
	{
		RegisterComponent<BackButton>();
	}

	// (optional) allow runtime registration of global objects
	public static T RegisterComponent<T> () where T: Component {
		return Instance.GetOrAddComponent<T>();
	}
}