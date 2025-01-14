﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Api.Commands
{
    public class SaveRecordCommand : IRequest<bool>
    {
        public string? Title { get; set; }

        public string? Body { get; set; }
    }
}
