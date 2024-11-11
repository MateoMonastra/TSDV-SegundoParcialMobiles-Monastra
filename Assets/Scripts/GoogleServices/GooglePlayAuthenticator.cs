using GooglePlayGames;
using UnityEngine;

namespace GoogleServices
{
    public class GooglePlayAuthenticator : MonoBehaviour
    {
        private void Start()
        {
            // Configura Google Play Games para autenticación
            PlayGamesPlatform.Activate();
    
            // Intenta autenticar al usuario
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("Autenticación exitosa en Google Play Games");
                }
                else
                {
                    Debug.Log("Falló la autenticación en Google Play Games");
                }
            });
        }
    }
}
