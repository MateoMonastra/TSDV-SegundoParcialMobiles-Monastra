using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;

namespace GoogleServices
{
    public class AchievementController : MonoBehaviour
    {
        private static AchievementController instance;

        private IEnumerator Start()
        {
            yield return null;
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                // Si ya existe una instancia y no es esta, se destruye el objeto duplicado
                Destroy(gameObject);
            }
        }

        public static AchievementController GetInstance()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AchievementController>();
            }

            return instance;
        }
        
        private void OnDestroy()
        {
            instance = null;
        }
        
        public void UnlockAchievement(string achievementId)
        {
            if (Social.localUser.authenticated)
            {
                Social.ReportProgress(achievementId, 100.0f, (bool success) =>
                {
                    if (success)
                    {
                        Debug.Log("Logro desbloqueado: " + achievementId);
                    }
                    else
                    {
                        Debug.Log("Error al desbloquear el logro: " + achievementId);
                    }
                });
            }
            else
            {
                Debug.Log("Usuario no autenticado, no se puede desbloquear el logro.");
            }
        }
        
        public void ResetAchievement(string achievementId)
        {
            Social.ReportProgress(achievementId, 0.0f, (bool success) => { });
        }
    
    }
}
