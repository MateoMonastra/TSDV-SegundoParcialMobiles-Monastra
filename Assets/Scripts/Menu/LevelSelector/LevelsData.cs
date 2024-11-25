using System.Collections.Generic;
using UnityEngine;

namespace Menu.LevelSelector
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "LevelsData")]
    public class LevelsData : ScriptableObject
    {
        public List<bool> levels;
        
    }
}