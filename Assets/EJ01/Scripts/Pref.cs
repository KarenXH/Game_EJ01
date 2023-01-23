using UnityEngine;

public static class Pref
{
   public static int bestScore
   {
        set
        {
            int oldScore = PlayerPrefs.GetInt(PrefKey.BestSCore.ToString(), 0);

            if( value >oldScore || oldScore == 0)
            {
                PlayerPrefs.SetInt(PrefKey.BestSCore.ToString(), value);
            }
        }
        get => PlayerPrefs.GetInt(PrefKey.BestSCore.ToString(),0);
   }

}
