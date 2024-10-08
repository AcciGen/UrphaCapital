﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrphaCapital.Application.UseCases.Homework.Commands;
using UrphaCapital.Application.UseCases.Lessons.Commands;
using UrphaCapital.Application.ViewModels;

namespace UrphaCapital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeworksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseModel> PostLesson(CreateHomeworkCommand command, CancellationToken cancellation)
        {
            var response = await _mediator.Send(command, cancellation);

            return response;
        }
    }
}
