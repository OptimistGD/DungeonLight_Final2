using UnityEngine;

public class SounBox : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.Pause();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			audioSource.Play();
		}
	}
}
