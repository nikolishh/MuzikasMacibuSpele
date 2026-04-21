using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelSystem
{
    public static bool IsLevelUnlocked(string game, int level)
    {
        if (level == 1) return true;

        for (int i = 1; i < level; i++)
        {
            if (PlayerPrefs.GetInt(game + "_Level" + i, 0) == 0)
                return false;
        }

        return true;
    }

    public static void CompleteLevel(string game, int level)
    {
        PlayerPrefs.SetInt(game + "_Level" + level, 1);
        PlayerPrefs.Save();
    }
}
