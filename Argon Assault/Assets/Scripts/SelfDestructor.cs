using UnityEngine;

namespace Project.Scripts
{
	public class SelfDestructor : MonoBehaviour 
	{
		private void Start() 
		{
        	Destroy(gameObject, 5f); 
		}
	}
}
