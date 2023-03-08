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

        public async Task<TeeTime> AddTeeTimeAsync(TeeTime teeTime)
        {
            try
            {
                dBContext.TeeTimes.Add(teeTime);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return teeTime;
        }

        public async Task<TeeTime> UpdateProductAsync(TeeTime teeTime)
        {
            try
            {
                var teeTimeExist = dBContext.TeeTimes.FirstOrDefault(p => p.Id == teeTime.Id);
                if (teeTimeExist != null)
                {
                    dBContext.Update(teeTime);
                    await dBContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return teeTime;
        }

        public async Task DeleteProductAsync(TeeTime teeTime)
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


        //private List<TeeTime> _teeTimeList = new List<TeeTime>();

        //public TeeTimeService()
        //{
        //}

        //public int AddTeeTime(TeeTime newTime)
        //{
        //    if (CheckAvailability(newTime) == false)
        //    {
        //        int player = CheckPlayers(newTime);
        //        if (player == 0)
        //        { 
        //            _teeTimeList.Add(newTime);
        //            return 1;
        //        }
        //        else
        //        {
        //            return player ;
        //        }
        //    }
        //    else
        //        return 0;
        //}

        //public bool CheckAvailability(TeeTime newTime)
        //{
        //    foreach(var ttime in _teeTimeList)
        //    {
        //        if((ttime.RoundDate.Date == newTime.RoundDate.Date) && 
        //            (ttime.RoundHour == newTime.RoundHour) &&
        //            (ttime.RoundMinute == newTime.RoundMinute))
        //            return true;
        //    }
        //    return false;
        //}

        //public int CheckPlayers(TeeTime newTime)
        //{
        //    List<int> playerList = new List<int>() 
        //    {
        //        newTime.Player1Id,
        //        newTime.Player2Id,
        //        newTime.Player3Id,
        //        newTime.Player4Id
        //    };
            
        //    foreach(TeeTime teeTime in _teeTimeList.Where(x => x.RoundDate == newTime.RoundDate))
        //    {
        //        foreach(int playerID in playerList)
        //        {
        //            if (teeTime.Player1Id == playerID || teeTime.Player2Id == playerID || teeTime.Player3Id == playerID || teeTime.Player4Id == playerID){
        //                return playerID;
        //            }
        //        }
        //    }
        //    return 0;
        //}

        //public List<TeeTime> GetTeeTimes()
        //{
        //    return _teeTimeList;
        //}
    }
}
