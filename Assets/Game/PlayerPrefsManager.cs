using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string LEVEL_KEY = "level_unlocked_";

    public static void LockLevel(int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 0); // use 1 for true
        } else {
            Debug.LogError("Trying to lock level not in build order.");
        }
    }

    public static void UnlockLevel (int level) {
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); // use 1 for true
		} else {
			Debug.LogError ("Trying to unlock level not in build order.");
		}
	}
	
	public static bool IsLevelUnlocked (int level) {
		int targetLevel = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (targetLevel == 1);
		
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Checking the unlock status of a level not in build order.");
			return false;
		}
	}

}
