﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrphaCapital.Domain.Entities.Auth;

namespace UrphaCapital.Application.UseCases.Admins.Queries
{
    public class GetAllAdminsQuery : IRequest<IEnumerable<Admin>>
    {
    }
}
