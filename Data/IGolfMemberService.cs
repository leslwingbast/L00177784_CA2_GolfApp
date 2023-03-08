namespace L00177784_CA2_GolfApp.Data
{
    public interface IGolfMemberService
    {
        List<GolfMember> GetMembers();

        public void CreateMember(GolfMember member);

        public GolfMember GetMember(int id);

        public void DeleteMember(int id);
    }

}
