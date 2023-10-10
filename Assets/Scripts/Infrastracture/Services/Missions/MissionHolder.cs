using UnityEngine;

namespace TDS.Infrastracture.Services.Missions
{
    public class MissionHolder : MonoBehaviour
    {
        [SerializeField] private MissionCondition _missionCondition;
        
        public MissionCondition MissionCondition => _missionCondition;
    }
}