﻿using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Common.Extensions;
using RegistrationServices.BusinessLayer.Extensions;
using OnlineServices.Common.RegistrationServices.Interfaces;
using System.Linq;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.Exceptions;
using RegistrationServices.BusinessLayer.UseCase.Attendee;

namespace RegistrationServices.BusinessLayer.UseCase.Assistant
{
    public partial class RSAssistantRole : RSAttendeeRole, IRSAssistantRole
    {
        private readonly IRSUnitOfWork iRSUnitOfWork;

        public RSAssistantRole(IRSUnitOfWork iRSUnitOfWork)
        {
            this.iRSUnitOfWork = iRSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iRSUnitOfWork));
        }

        public RSAssistantRole()
        {

        }
    }
}
