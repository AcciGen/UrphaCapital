﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrphaCapital.Application.Abstractions;
using UrphaCapital.Application.UseCases.Homework.Queries;
using UrphaCapital.Domain.Entities;

namespace UrphaCapital.Application.UseCases.Homework.QueriesHandler
{
    public class GetHomeworksByStudentIdQueryHandler : IRequestHandler<GetHomeworkByStudentIdQuery, IEnumerable<Homeworks>>
    {
        private readonly IApplicationDbContext _context;

        public GetHomeworksByStudentIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Homeworks>> Handle(GetHomeworkByStudentIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Homeworks.Where(x => x.studentId == request.studentId).ToListAsync();
        }
    }
}