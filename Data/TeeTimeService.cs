using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace L00177784_CA2_GolfApp.Data
{
    public class TeeTimeService
    {

        private GolfAppDBContext dBContext;

        public TeeTimeService(GolfAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<TeeTime>> GetTeeTimesAsync()
        {
            return await dBContext.TeeTimes.ToListAsync();
        }

        public async Task<int> AddTeeTimeAsync(TeeTime teeTime)
        {
            if (CheckAvailability(teeTime) == false)
            {
                int player = CheckPlayers(teeTime);
                if (player == 0)
                {
                    try
                    {
                        dBContext.TeeTimes.Add(teeTime);
                        await dBContext.SaveChangesAsync();
                        return 1;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else return player;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateTeeTimeAsync(TeeTime teeTime)
        {
            if (CheckAvailability(teeTime) == false)
            {
                int player = CheckPlayers(teeTime);
                if (player == 0)
                {
                    try
                    {
                        var teeTimeExist = dBContext.TeeTimes.FirstOrDefault(p => p.Id == teeTime.Id);
                        if (teeTimeExist != null)
                        {
                            dBContext.Update(teeTime);
                            await dBContext.SaveChangesAsync();
                        }
                        return 1;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else return player;
            }
            else
            {
                return 0;
            }
        }

        public async Task DeleteTeeTimeAsync(TeeTime teeTime)
        {
            try
            {
                dBContext.TeeTimes.Remove(teeTime);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckAvailability(TeeTime newTime)
        {
            var _teeTimesList = dBContext.TeeTimes.Where(x => x.RoundDate == newTime.RoundDate).ToList();            
            foreach (var ttime in _teeTimesList)
            {
                if ((ttime.RoundDate.Date == newTime.RoundDate.Date) &&
                    (ttime.RoundHour == newTime.RoundHour) &&
                    (ttime.RoundMinute == newTime.RoundMinute))
                {
                    if (ttime.Id == newTime.Id) { return false; }
                    else { return true; }
                }
                    
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

            foreach (TeeTime teeTime in dBContext.TeeTimes.Where(x => x.RoundDate == newTime.RoundDate))
            {
                foreach (int playerID in playerList)
                {
                    if ((teeTime.Player1Id == playerID || teeTime.Player2Id == playerID || teeTime.Player3Id == playerID || teeTime.Player4Id == playerID) && (newTime.Id != teeTime.Id))
                    {
                        return playerID;
                    }
                }
            }
            return 0;
        }

        public TeeTime GetTeeTime(int id)
        {
            return dBContext.TeeTimes.First(x => x.Id == id);
        }
    }
}
