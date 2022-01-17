using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScriptableObject/Singleton",fileName = "GameManagerSO")]
public class GameController : SingletonSO<GameController>
{
	[SerializeField] Canvas _deathCanvas;
	public void OnDeath()
	{
		Time.timeScale = 0f;
		isDead = true;
		Instantiate(_deathCanvas);
	}

	public void RestartGame()
	{
		if (isDead)
		{
			isDead = false;
			Time.timeScale = 1f;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
	}
}
