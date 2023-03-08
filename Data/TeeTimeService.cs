using System.Runtime.CompilerServices;

namespace L00177784_CA2_GolfApp.Data
{
    public class TeeTimeService : ITeeTimeService
    {
        private List<TeeTime> _teeTimeList = new List<TeeTime>();

        public TeeTimeService()
        {
        }

        public int AddTeeTime(TeeTime newTime)
        {
            if (CheckAvailability(newTime) == false)
            {
                int player = CheckPlayers(newTime);
                if (player == 0)
                { 
                    _teeTimeList.Add(newTime);
                    return 1;
                }
                else
                {
                    return player ;
                }
            }
            else
                return 0;
        }

        public bool CheckAvailability(TeeTime newTime)
        {
            foreach(var ttime in _teeTimeList)
            {
                if((ttime.RoundDate.Date == newTime.RoundDate.Date) && 
                    (ttime.RoundHour == newTime.RoundHour) &&
                    (ttime.RoundMinute == newTime.RoundMinute))
                    return true;
            }
            return false;
        }

        public int CheckPlayers(TeeTime newTime)
        {
            List<int> playerList = new List<int>() 
            {
                newTime.Player1Id,
                newTime.Player2Id,
                newTime.Player3Id,
                newTime.Player4Id
            };
            
            foreach(TeeTime teeTime in _teeTimeList.Where(x => x.RoundDate == newTime.RoundDate))
            {
                foreach(int playerID in playerList)
                {
                    if (teeTime.Player1Id == playerID || teeTime.Player2Id == playerID || teeTime.Player3Id == playerID || teeTime.Player4Id == playerID){
                        return playerID;
                    }
                }
            }
            return 0;
        }

        public List<TeeTime> GetTeeTimes()
        {
            return _teeTimeList;
        }
    }
}
