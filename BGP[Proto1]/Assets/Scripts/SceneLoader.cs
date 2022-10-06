using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader {
    public static void Load() {
        SceneManager.LoadScene("Game");
    }
    public static void ReturnToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
