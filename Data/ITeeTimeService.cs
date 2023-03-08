namespace L00177784_CA2_GolfApp.Data
{
    public interface ITeeTimeService
    {
        List<TeeTime> GetTeeTimes();

        public int AddTeeTime(TeeTime newTime);

        public bool CheckAvailability(TeeTime newTime);

        public int CheckPlayers(TeeTime newTime);

    }
}
