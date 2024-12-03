using Hydra.WebApi.DTOs;
using Hydra.WebApi.Entities;

namespace Hydra.WebApi.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike?> GetUserLike(int sourceUserId, int targetUserId);
        Task<IEnumerable<MemberDto>> GetUserLikes(string predicate, int userId);
        Task<IEnumerable<int>> GetCurrentUserLikeIds(int currentUserId);
        void DeleteLike(UserLike like);
        void AddLike(UserLike like);
        Task<bool> SaveChanges();
    }
}
