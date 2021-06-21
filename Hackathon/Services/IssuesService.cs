using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Models;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly IIssuesRepository _issuesRepository;
        private readonly IUserService _userService;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public IssuesService(IIssuesRepository issuesRepository,
                             IUserService userService,
                             IPhotoService photoService,
                             IMapper mapper)
        {
            _issuesRepository = issuesRepository;
            _userService = userService;
            _photoService = photoService;
            _mapper = mapper;
        }

        public async Task<List<IssuesDto>> GetAllIssuesAsync()
        {
            var issuesList = await _issuesRepository.GetAllIssuesAsync();
            return MapToDto(issuesList);
        }

        public async Task<IssuesDto> GetIssuesByIdAsync(int id)
        {
            var issue = await _issuesRepository.GetIssuesByIdAsync(id);
            return MapToDto(issue);
        }

        public async Task<List<IssuesDto>> GetIssuesByPinIdAsync(int pinId)
        {
            var issuesList = await _issuesRepository.GetIssuesByPinIdAsync(pinId);
            return MapToDto(issuesList);
        }

        public async Task<IssuesDto> CreateIssuesAsync(IssuesDto issuesDto)
        {
            var issueEntity = MapToEntity(issuesDto);

            if (await _issuesRepository.CreateIssuesAsync(issueEntity))
            {
                return MapToDto(issueEntity);
            }
            return default(IssuesDto);
        }

        public async Task<IssuesDto> UpdateIssuesAsync(int id, IssuesDto issuesDto)
        {
            var issueEntity = await MapToUpdatedEntity(id, issuesDto);

            if (await _issuesRepository.UpdateIssuesAsync(issueEntity))
            {
                return MapToDto(issueEntity);
            }
            return default(IssuesDto);
        }

        public async Task<bool> DeleteIssuesAsync(int id)
        {
            if (await _issuesRepository.DeleteIssuesAsync(id))
            {
                return true;
            }
            return false;
        }

        private IssuesDto MapToDto(Issues issueEntity)
        {
            return new IssuesDto
            {
                PinId = issueEntity.PinId,
                Details = issueEntity.Details,
                Id = issueEntity.Id,
                Photo = _photoService.GetPhoto(issueEntity.PhotoName)
            };
        }

        private List<IssuesDto> MapToDto(List<Issues> issueEntityList)
        {
            var dtoList = new List<IssuesDto>();

            issueEntityList.ForEach(x =>
            {
                dtoList.Add(new IssuesDto
                {
                    PinId = x.PinId,
                    Details = x.Details,
                    Id = x.Id,
                    Photo = _photoService.GetPhoto(x.PhotoName)
                });

            });

            return dtoList;
        }

        private async Task<Issues> MapToUpdatedEntity(int id, IssuesDto issuesDto)
        {
            var issueEntity = await _issuesRepository.GetIssuesByIdAsync(id);

            issueEntity.OwnerEmail = _userService.GetUserEmail();
            issueEntity.PhotoName = _photoService.UpdatePhoto(issueEntity.PhotoName, issuesDto.Photo);
            issueEntity.PinId = issuesDto.PinId;
            issueEntity.Details = issuesDto.Details;

            return issueEntity;
        }

        private Issues MapToEntity(IssuesDto issuesDto)
        {
            return new Issues
            {
                OwnerEmail = _userService.GetUserEmail(),
                PhotoName = _photoService.SavePhoto(issuesDto.Photo),
                PinId = issuesDto.PinId,
                Details = issuesDto.Details
            };
        }
    }
}
