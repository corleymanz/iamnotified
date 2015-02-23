﻿using System;

namespace IAmNotified.IAmNotifiedService.Implementation.Configuration
{
    public interface ISettings
    {
        MailSetting Mail { get; }
        String MailQueue { get; }
        String RabbitmqServer { get; }
    }
}