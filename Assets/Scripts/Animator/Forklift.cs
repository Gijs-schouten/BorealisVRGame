using UnityEngine;

public class Forklift : MonoBehaviour {
	public Animator animator;

	public void PlayAnim() {
		animator.SetBool("start", true);
	}
}
