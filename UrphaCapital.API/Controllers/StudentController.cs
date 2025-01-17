﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using UrphaCapital.Application.ExternalServices.AuthServices;
using UrphaCapital.Application.ExternalServices.HasherServices;
using UrphaCapital.Application.UseCases.Lessons.Commands;
using UrphaCapital.Application.UseCases.StudentsCRUD.Commands;
using UrphaCapital.Application.UseCases.StudentsCRUD.Queries;
using UrphaCapital.Application.ViewModels;
using UrphaCapital.Domain.Entities;
using UrphaCapital.Domain.Entities.Auth;

namespace UrphaCapital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;
        private readonly IPasswordHasher _passwordHasher;

        public StudentController(IMediator mediator, IAuthService authService, IPasswordHasher passwordHasher)
        {
            _mediator = mediator;
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, Student")]
        public async Task<ResponseModel> PostStudent([FromBody] CreateStudentsCommand command, CancellationToken cancellation)
        {
            var response = await _mediator.Send(command, cancellation);

            return response;
        }

        [HttpGet("{id}")]
        [EnableRateLimiting(policyName: "sliding")]
        //[Authorize(Roles = "Admin")]
        public async Task<Student> GetStudentById(long id, CancellationToken cancellation)
        {
            var query = new GetAllStudentsByIdQuery { Id = id };

            var response = await _mediator.Send(query, cancellation);

            return response;
        }

        [HttpGet("get-my-courses/{id}")]
        [EnableRateLimiting(policyName: "sliding")]
        //[Authorize(Roles = "Admin, Students")]
        public async Task<IEnumerable<Course>> GetMyCoursesById(long id, CancellationToken cancellation)
        {
            var query = new GetStudentCoursesQuery { Id = id };

            var response = await _mediator.Send(query, cancellation);

            return response;
        }

        [HttpGet("{index}/{count}")]
        [EnableRateLimiting(policyName: "sliding")]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Student>> GetStudentsByStudentId(int index, int count, CancellationToken cancellation)
        {
            var query = new GetAllStudentsQuery()
            {
                Index = index,
                Count = count
            };

            var response = await _mediator.Send(query, cancellation);

            return response;
        }

        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<ResponseModel> PutStudent([FromBody] UpdateStudentCommand command, CancellationToken cancellation)
        {
            var response = await _mediator.Send(command, cancellation);

            return response;
        }

        [HttpPut("add-course")]
        //[Authorize(Roles = "Admin")]
        public async Task<ResponseModel> AddMyCourse([FromQuery] AddMyCourseCommand command, CancellationToken cancellation)
        {
            var response = await _mediator.Send(command, cancellation);

            return response;
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ResponseModel> RemoveStudent(string id, CancellationToken cancellation)
        {
            var command = new DeleteLessonCommand { Id = id };

            var response = await _mediator.Send(command, cancellation);

            return response;
        }
    }
}

