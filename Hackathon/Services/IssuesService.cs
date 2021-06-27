using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Common;
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
        private readonly IStatusRepository _statusRepository;
        private readonly IPinsRepository _pinsRepository;

        public IssuesService(IIssuesRepository issuesRepository,
                             IUserService userService,
                             IPhotoRepository photoRepository,
                             IStatusRepository statusRepository,
                             IPinsRepository pinsRepository)
        {
            _issuesRepository = issuesRepository;
            _userService = userService;
            _photoRepository = photoRepository;
            _statusRepository = statusRepository;
            _pinsRepository = pinsRepository;
        }

        public async Task<Result<List<IssuesDto>>> GetAllIssuesAsync()
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
                    Photo = photo.PhotoByteArray,
                    StatusId = issue.StatusId,
                    Date = issue.Date
                });
            }

            return Result.OK(issuesDtoList);
        }

        public async Task<Result<IssuesDto>> GetIssuesByIdAsync(int id)
        {
            var issue = await _issuesRepository.GetIssuesByIdAsync(id);

            if(issue == null)
            {
                return Result.NotFound<IssuesDto>();
            }

            var photo = await _photoRepository.GetPhotoAsync(issue.PhotoName);

            return Result.OK(new IssuesDto
            {
                Id = issue.Id,
                Details = issue.Details,
                PinId = issue.PinId,
                Photo = photo.PhotoByteArray,
                StatusId = issue.StatusId,
                Date = issue.Date
            });
        }

        public async Task<Result<List<IssuesDto>>> GetIssuesByPinIdAsync(int pinId)
        {
            var issuesDtoList = new List<IssuesDto>();

            var issuesList = await _issuesRepository.GetIssuesByPinIdAsync(pinId);

            if(issuesList == null)
            {
                return Result.BadRequest<List<IssuesDto>>().AddErrors("pinId", "The pinId is invalid");
            }

            foreach (var issue in issuesList)
            {
                var photo = await _photoRepository.GetPhotoAsync(issue.PhotoName);

                issuesDtoList.Add(new IssuesDto {
                        Id = issue.Id,
                        Details = issue.Details,
                        PinId = issue.PinId,
                        Photo = photo.PhotoByteArray,
                        StatusId = issue.StatusId,
                        Date = issue.Date
                });             
            }

            return Result.OK(issuesDtoList);
        }

        public async Task<Result<List<IssuesDto>>> GetIssuesByPinStatusIdAsync(int statusId)
        {
            var issuesDtoList = new List<IssuesDto>();

            var issuesList = await _issuesRepository.GetIssuesByStatusAsync(statusId);

            if (issuesList == null)
            {
                return Result.BadRequest<List<IssuesDto>>().AddErrors("statusId", "The statusId is invalid");
            }

            foreach (var issue in issuesList)
            {
                var photo = await _photoRepository.GetPhotoAsync(issue.PhotoName);

                issuesDtoList.Add(new IssuesDto
                {
                    Id = issue.Id,
                    Details = issue.Details,
                    PinId = issue.PinId,
                    Photo = photo.PhotoByteArray,
                    StatusId = issue.StatusId,
                    Date = issue.Date
                });
            }

            return Result.OK(issuesDtoList);
        }

        public async Task<Result<IssuesDto>> CreateIssuesAsync(IssuesDto issuesDto)
        {
            var photo = await _photoRepository.SavePhotoAsync(issuesDto.Photo);

            if (!await _pinsRepository.CheckPin(issuesDto.PinId))
            {
                return Result.BadRequest<IssuesDto>().AddErrors("PinId", "PinId is not valid");
            }

            var issueEntity = new Issues
            {
                PhotoName = photo.Id.ToString(),
                OwnerEmail = _userService.GetUserEmail(),

                Date = issuesDto.Date,
                StatusId = issuesDto.StatusId,
                PinId = issuesDto.PinId,
                Details = issuesDto.Details
            };

            if (await _issuesRepository.CreateIssuesAsync(issueEntity))
            {
                return Result.OK(new IssuesDto
                {
                    Id = issueEntity.Id,
                    StatusId = 1,
                    Date = System.DateTime.Now,
                    Photo = photo.PhotoByteArray,
                    PinId = issueEntity.PinId,
                    Details = issueEntity.Details
                });;
            }
            return Result.InternalServerError(default(IssuesDto));
        }

        public async Task<Result<IssuesDto>> UpdateIssuesAsync(int id, IssuesDto issuesDto)
        {
            var issueEntity = await _issuesRepository.GetIssuesByIdAsync(id);
            var validationCheck = Result.BadRequest<IssuesDto>();

            if(issueEntity == null)
            {
                validationCheck.AddErrors("id", "The id is not valid");
            }

            if (!await _pinsRepository.CheckPin(issuesDto.PinId))
            {
                validationCheck.AddErrors("PinId", "PinId is not valid");
            }

            if (!await _statusRepository.CheckStatus(issuesDto.StatusId))
            {
                validationCheck.AddErrors("StatusId", "StatusId is not valid");
            }

            if (validationCheck.errors.Count > 0)
            {
                return validationCheck;
            }

            if (!await _photoRepository.UpdatePhotoAsync(issueEntity.PhotoName, issuesDto.Photo))
            {
                return Result.InternalServerError(default(IssuesDto)).AddErrors("photoRepository","failed to retrive photo");
            }

            issueEntity.PinId = issuesDto.PinId;
            issueEntity.Details = issuesDto.Details;
            issueEntity.StatusId = issuesDto.StatusId;

            var photo = await _photoRepository.GetPhotoAsync(issueEntity.PhotoName);

            if (await _issuesRepository.UpdateIssuesAsync(issueEntity))
            {
                return Result.OK(new IssuesDto
                {
                    Id = issueEntity.Id,
                    Details = issueEntity.Details,
                    PinId = issueEntity.PinId,
                    Photo = photo.PhotoByteArray,
                    Date = issueEntity.Date,
                    StatusId = issueEntity.StatusId
                });
            }
            return Result.InternalServerError(default(IssuesDto));
        }

        public async Task<Result<bool>> DeleteIssuesAsync(int id)
        {
            var issue = await _issuesRepository.GetIssuesByIdAsync(id);
            if(issue == null)
            {
                return Result.NotFound<bool>().AddErrors("id","The id is invalid");
            }

            if(!await _photoRepository.DeletePhotoAsync(issue.PhotoName))
            {
                return Result.InternalServerError(false).AddErrors("photoRepository","failed to delete photo");
            }

            if (await _issuesRepository.DeleteIssuesAsync(id))
            {
                return Result.OK(true);
            }
            return Result.InternalServerError(false).AddErrors("issuesRepository","failed to delete entry");
        }
    }
}
