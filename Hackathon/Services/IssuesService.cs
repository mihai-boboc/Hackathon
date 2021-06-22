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
        private readonly IPhotoRepository _photoRepository;

        public IssuesService(IIssuesRepository issuesRepository,
                             IUserService userService,
                             IPhotoRepository photoRepository)
        {
            _issuesRepository = issuesRepository;
            _userService = userService;
            _photoRepository = photoRepository;
        }

        public async Task<List<IssuesDto>> GetAllIssuesAsync()
        {
            var issuesDtoList = new List<IssuesDto>();

            var issuesList = await _issuesRepository.GetAllIssuesAsync();

            foreach (var issue in issuesList)
            {
                var photo = await _photoRepository.GetPhotoAsync(issue.PhotoName);

                issuesDtoList.Add(new IssuesDto
                {
                    Id = issue.Id,
                    Details = issue.Details,
                    PinId = issue.PinId,
                    Photo = photo.PhotoByteArray
                });
            }

            return issuesDtoList;
        }

        public async Task<IssuesDto> GetIssuesByIdAsync(int id)
        {
            var issue = await _issuesRepository.GetIssuesByIdAsync(id);
            var photo = await _photoRepository.GetPhotoAsync(issue.PhotoName);

            return new IssuesDto
            {
                Id = issue.Id,
                Details = issue.Details,
                PinId = issue.PinId,
                Photo = photo.PhotoByteArray
            };
        }

        public async Task<List<IssuesDto>> GetIssuesByPinIdAsync(int pinId)
        {
            var issuesDtoList = new List<IssuesDto>();

            var issuesList = await _issuesRepository.GetIssuesByPinIdAsync(pinId);

            foreach (var issue in issuesList)
            {
                var photo = await _photoRepository.GetPhotoAsync(issue.PhotoName);

                issuesDtoList.Add(new IssuesDto {
                        Id = issue.Id,
                        Details = issue.Details,
                        PinId = issue.PinId,
                        Photo = photo.PhotoByteArray
                    });             
            }

            return issuesDtoList;
        }

        public async Task<IssuesDto> CreateIssuesAsync(IssuesDto issuesDto)
        {
            var photo = await _photoRepository.SavePhotoAsync(issuesDto.Photo);

            var issueEntity = new Issues
            {
                PhotoName = photo.Id.ToString(),
                OwnerEmail = _userService.GetUserEmail(),

                PinId = issuesDto.PinId,
                Details = issuesDto.Details
            };

            if (await _issuesRepository.CreateIssuesAsync(issueEntity))
            {
                return new IssuesDto 
                {
                    Id = issueEntity.Id,
                    Photo = photo.PhotoByteArray,
                    PinId = issueEntity.PinId,
                    Details = issueEntity.Details
                };
            }
            return default(IssuesDto);
        }

        public async Task<IssuesDto> UpdateIssuesAsync(int id, IssuesDto issuesDto)
        {
            var issueEntity = await _issuesRepository.GetIssuesByIdAsync(id);

            if (!await _photoRepository.UpdatePhotoAsync(issueEntity.PhotoName, issuesDto.Photo))
            {
                return default(IssuesDto);
            }

            issueEntity.PinId = issuesDto.PinId;
            issueEntity.Details = issuesDto.Details;

            var photo = await _photoRepository.GetPhotoAsync(issueEntity.PhotoName);

            if (await _issuesRepository.UpdateIssuesAsync(issueEntity))
            {
                return new IssuesDto
                {
                    Id = issueEntity.Id,
                    Details = issueEntity.Details,
                    PinId = issueEntity.PinId,
                    Photo = photo.PhotoByteArray
                };
            }
            return default(IssuesDto);
        }

        public async Task<bool> DeleteIssuesAsync(int id)
        {
            var issue = await _issuesRepository.GetIssuesByIdAsync(id);

            if(!await _photoRepository.DeletePhotoAsync(issue.PhotoName))
            {
                return false;
            }

            if (await _issuesRepository.DeleteIssuesAsync(id))
            {
                return true;
            }
            return false;
        }
    }
}
