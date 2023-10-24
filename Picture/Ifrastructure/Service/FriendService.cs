using Aplication.Services;
using Domain;
using Domain.Entity;
using Domain.Enum;
using Domain.Exceptions;
using Domain.ModelDTO;
using Ifrastructure.DataAction;
using Microsoft.EntityFrameworkCore;
using Picture.Infrastructure.Service.Interface;

namespace Picture.Infrastructure.Service
{
    public class FriendService : IFriendService
    {
        private readonly FriendRepository _friendRepository;

        public FriendService(IFriendService friendRepository)
        {
            _friendRepository = (FriendRepository?)friendRepository;
        }

        public async ValueTask<IEnumerable<Friend>> GetFriendsActiveAsync(long userId)
        {
            var friends = _friendRepository.DbGetSet().Where(friend => friend.UserId == userId &&
             friend.Status == FriendStatus.Active);
            if (friends is null)
                throw new CustomException(404, "Friend not found");
            return friends;
        }

        public async ValueTask<IEnumerable<Friend>> GetFriendsAsync(long userId)
        {
            var friends = _friendRepository.DbGetSet().Where(friend => friend.UserId == userId);
            if (friends is null)
                throw new CustomException(404, "Friend not found");
            return friends;
        }

        public async ValueTask<Friend> GetFriendAsync(FriendDto dto)
        {
            var friend = await _friendRepository.DbGetSet()
                .FirstOrDefaultAsync(friend => friend.UserId == dto.UserId && friend.FriendId == dto.FriendId);
            if (friend is null)
                throw new CustomException(404, "Friend not found");
            return friend;
        }


        public async ValueTask<Friend> CreateAsync(FriendDto dto)
        {
            if (dto is null)
                throw new CustomException(400, "Bad request dto null");
            var friend = new Friend
            {
                UserId = dto.UserId,
                FriendId = dto.FriendId,
                Status = FriendStatus.Active
            };
            return await _friendRepository.CreateAsync(friend);
        }


        public async ValueTask<Friend> BlockFriendsAsync(FriendDto dto)
        {
            if (dto is null)
                throw new CustomException(400, "Bad request dto null");
            Friend friend = await this.GetFriendAsync(dto);
            if (friend is null)
            {
                friend = new Friend
                {
                    UserId = dto.UserId,
                    FriendId = dto.FriendId,
                    Status = FriendStatus.Blocked
                };
                friend = await _friendRepository.CreateAsync(friend);
            }

            else
            {
                friend.Status = FriendStatus.Blocked;
                await _friendRepository.UpdateAsync(friend);
            }

            return friend;
        }

        public async ValueTask<Friend> RequestFriendsAsync(FriendDto dto)
        {
            if (dto is null)
                throw new CustomException(400, "Bad request dto null");
            Friend friend = await this.GetFriendAsync(dto);
            if (friend is null)
            {
                friend = new Friend
                {
                    UserId = dto.UserId,
                    FriendId = dto.FriendId,
                    Status = FriendStatus.Requested
                };
                friend = await _friendRepository.CreateAsync(friend);
            }

            else
            {
                friend.Status = FriendStatus.Requested;
                friend = await _friendRepository.UpdateAsync(friend);
            }

            return friend;
        }

        public async ValueTask<Friend> RejectedFriendsAsync(FriendDto dto)
        {
            if (dto is null)
                throw new CustomException(400, "Bad request dto null");
            Friend friend = await this.GetFriendAsync(dto);
            if (friend is null)
            {
                friend = new Friend
                {
                    UserId = dto.UserId,
                    FriendId = dto.FriendId,
                    Status = FriendStatus.Rejected
                };
                friend = await _friendRepository.CreateAsync(friend);
            }

            else
            {
                friend.Status = FriendStatus.Rejected;
                friend = await _friendRepository.CreateAsync(friend);
            }
            return friend;
        }
    }
}
