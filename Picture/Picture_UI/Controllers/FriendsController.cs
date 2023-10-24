using Domain.Entity;
using Domain.Exceptions;
using Domain.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Picture.Infrastructure.Interface;
using Picture.Infrastructure.Service.Interface;

namespace Picture_UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        public readonly IFriendService _friendService;
        public readonly IFriendRepository _friendRepository;

        public FriendsController(IFriendService friendService, IFriendRepository friendRepository)
        {
            _friendService = friendService;
            _friendRepository = friendRepository;
        }
        [HttpGet("Get-Friends-Active"), Authorize]
        public async ValueTask<ApiResult<IEnumerable<Friend>>> GetFriendsActiveAsync(long userId)
        {
            return ApiResult<Friend>.FromIEnumerable(await _friendService.GetFriendsActiveAsync(userId));
        }

        [HttpGet("Get-Friends"), Authorize]
        public async ValueTask<ApiResult<IEnumerable<Friend>>> GetFriendsAsync(long userId)
        {
            return ApiResult<Friend>.FromIEnumerable(await _friendService.GetFriendsAsync(userId));
        }

        [HttpGet("Get-Friend"), Authorize]
        public async ValueTask<ApiResult<Friend>> GetFriendAsync(FriendDto dto)
        {
            return await _friendService.GetFriendAsync(dto);
        }

        [HttpPost("Accepted-Friends"), Authorize]
        public async ValueTask<ApiResult<Friend>> CreateAsync(FriendDto dto)
        {
            return await _friendService.CreateAsync(dto);
        }

        [HttpPost("Block-Friends"), Authorize]
        public async ValueTask<ApiResult<Friend>> BlockFriendsAsync(FriendDto dto)
        {
            return await _friendService.BlockFriendsAsync(dto);
        }

        [HttpPost("Requested-Friends"), Authorize]
        public async ValueTask<ApiResult<Friend>> RequestFriendsAsync(FriendDto dto)
        {
            return await _friendService.RequestFriendsAsync(dto);
        }

        [HttpPost("rejected-friends"), Authorize]
        public async ValueTask<ApiResult<Friend>> RejectedFriendsAsync(FriendDto dto)
        {
            return await _friendService.RejectedFriendsAsync(dto);
        }
        [HttpDelete("{Id:Long}"), Authorize]
        public async ValueTask<ApiResult<Friend>> DeleteAsync(long id)
        {
            var friend = await _friendRepository.GetByIdAsync(id);
            if (friend is null)
                throw new CustomException(404, "Friend not found");
            return await _friendRepository.DeleteByIdAsync(friend.Id);
        }

    }
}
