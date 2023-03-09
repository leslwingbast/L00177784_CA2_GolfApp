using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace L00177784_CA2_GolfApp.Data
{
    public class GolfMemberService
    {
        private GolfAppDBContext dBContext;

        public GolfMemberService(GolfAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<GolfMember>> GetMembersAsync()
        {
            return await dBContext.GolfMembers.ToListAsync();
        }

        public GolfMember GetMember(int id)
        {
            return dBContext.GolfMembers.First(x => x.MemberID == id);
        }

        public async Task<GolfMember> AddMemberAsync(GolfMember golfMember)
        {
            try
            {
                golfMember.MemberID = await GetMaxID();
                dBContext.GolfMembers.Add(golfMember);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return golfMember;
        }

        private async Task<int> GetMaxID()
        {
            var _members = await GetMembersAsync();
            int maxId = 101;
            foreach (var maxMember in _members)
            {
                if (maxMember.MemberID >= maxId)
                {
                    maxId = maxMember.MemberID + 1;
                }
            }
            return maxId;
        }

        public async Task<GolfMember> UpdateMemberAsync(GolfMember golfMember)
        {
            try
            {
                var teeTimeExist = dBContext.GolfMembers.FirstOrDefault(p => p.MemberID == golfMember.MemberID);
                if (teeTimeExist != null)
                {
                    dBContext.Update(golfMember);
                    await dBContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return golfMember;
        }

        public async Task DeleteMemberAsync(GolfMember golfMember)
        {
            try
            {
                dBContext.GolfMembers.Remove(golfMember);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
