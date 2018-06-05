﻿using System;
using System.Runtime.Serialization;

namespace Lykke.Service.IncreasticEventIndicators.Client.Exceptions
{
    [Serializable]
    public class NotFoundException : ApiException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected NotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}