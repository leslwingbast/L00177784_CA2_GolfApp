using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Linq;

namespace L00177784_CA2_GolfApp.Data
{
    public class GolfMemberService
    {
        private readonly GolfAppDBContext dBContext;

        public GolfMemberService(GolfAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<GolfMember>> GetMembersAsync()
        {
            var membersList = await dBContext.GolfMembers.ToListAsync();
            membersList.Sort((p, q) => p.LastName.CompareTo(q.LastName));
            return membersList;
        }

        public GolfMember GetMember(int id)
        {
            return dBContext.GolfMembers.First(x => x.MemberID == id);
        }

        public async Task<GolfMember> AddMemberAsync(GolfMember golfMember)
        {
            golfMember.MemberID = await GetMaxID();
            dBContext.GolfMembers.Add(golfMember);
            await dBContext.SaveChangesAsync();
            return golfMember;
        }

        private async Task<int> GetMaxID()
        {
            var _members = await GetMembersAsync();
            int maxId = 101;
            foreach (var maxMember in from maxMember in _members
                                      where maxMember.MemberID >= maxId
                                      select maxMember)
            {
                maxId = maxMember.MemberID + 1;
            }

            return maxId;
        }

        public async Task<GolfMember> UpdateMemberAsync(GolfMember golfMember)
        {
            var teeTimeExist = dBContext.GolfMembers.FirstOrDefault(p => p.MemberID == golfMember.MemberID);
            if (teeTimeExist != null)
            {
                dBContext.Update(golfMember);
                await dBContext.SaveChangesAsync();
            }
            return golfMember;
        }

        public async Task DeleteMemberAsync(GolfMember golfMember)
        {
            dBContext.GolfMembers.Remove(golfMember);
            await dBContext.SaveChangesAsync();
        }
    }
}
