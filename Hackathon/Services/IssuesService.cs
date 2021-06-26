﻿using AutoMapper;
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

        public IssuesService(IIssuesRepository issuesRepository,
                             IUserService userService,
                             IPhotoRepository photoRepository)
        {
            _issuesRepository = issuesRepository;
            _userService = userService;
            _photoRepository = photoRepository;
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
                    Photo = photo.PhotoByteArray
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
                Photo = photo.PhotoByteArray
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
                        Photo = photo.PhotoByteArray
                    });             
            }

            return Result.OK(issuesDtoList);
        }

        public async Task<Result<IssuesDto>> CreateIssuesAsync(IssuesDto issuesDto)
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
                return Result.OK(new IssuesDto 
                {
                    Id = issueEntity.Id,
                    Photo = photo.PhotoByteArray,
                    PinId = issueEntity.PinId,
                    Details = issueEntity.Details
                });
            }
            return Result.InternalServerError(default(IssuesDto));
        }

        public async Task<Result<IssuesDto>> UpdateIssuesAsync(int id, IssuesDto issuesDto)
        {
            var issueEntity = await _issuesRepository.GetIssuesByIdAsync(id);
            if(issueEntity == null)
            {
                return Result.BadRequest<IssuesDto>().AddErrors("id", "The id is not valid");
            }

            if (!await _photoRepository.UpdatePhotoAsync(issueEntity.PhotoName, issuesDto.Photo))
            {
                return Result.InternalServerError(default(IssuesDto));
            }

            issueEntity.PinId = issuesDto.PinId;
            issueEntity.Details = issuesDto.Details;

            var photo = await _photoRepository.GetPhotoAsync(issueEntity.PhotoName);

            if (await _issuesRepository.UpdateIssuesAsync(issueEntity))
            {
                return Result.OK(new IssuesDto
                {
                    Id = issueEntity.Id,
                    Details = issueEntity.Details,
                    PinId = issueEntity.PinId,
                    Photo = photo.PhotoByteArray
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
                return Result.InternalServerError(false);
            }

            if (await _issuesRepository.DeleteIssuesAsync(id))
            {
                return Result.OK(true);
            }
            return Result.InternalServerError(false);
        }
    }
}
