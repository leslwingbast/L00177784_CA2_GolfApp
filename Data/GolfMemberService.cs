using System.Runtime.CompilerServices;

namespace L00177784_CA2_GolfApp.Data
{
    public class GolfMemberService : IGolfMemberService
    {
        private List<GolfMember> _members = new List<GolfMember>();
        public List<GolfMember> GetMembers()
        {
            return _members;
        }

        public void CreateMember(GolfMember member)
        {

            member.MemberID = GetMaxID();
            _members.Add(member);
        }

        private int GetMaxID()
        {
            int maxId = 101;
            foreach(var maxMember in _members)
            {
                if(maxMember.MemberID >= maxId)
                {
                    maxId = maxMember.MemberID + 1;
                }
            }
            return maxId;
        }

        public GolfMember GetMember(int id)
        {
            _members = GetMembers();
            return _members.First(x => x.MemberID == id);
        }

        public void DeleteMember(int id)
        {
            var delMember = GetMember(id);
            _members.Remove(delMember);
        }
    }
}
