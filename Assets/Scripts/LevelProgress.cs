using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelProgress
{
    public static int GetUnlockedLevel(string gameName)
    {
        return PlayerPrefs.GetInt(gameName + "_UnlockedLevel", 1);
    }

    public static void UnlockLevel(string gameName, int level)
    {
        int current = GetUnlockedLevel(gameName);

        if (level >= current)
        {
            PlayerPrefs.SetInt(gameName + "_UnlockedLevel", level + 1);
            PlayerPrefs.Save();
        }
    }
}
