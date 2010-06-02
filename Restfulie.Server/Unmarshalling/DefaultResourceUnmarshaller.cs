﻿using System;
using Restfulie.Server.Exceptions;
using Restfulie.Server.Unmarshalling.Deserializers;

namespace Restfulie.Server.Unmarshalling
{
    public class DefaultResourceUnmarshaller : IResourceUnmarshaller
    {
        private readonly IResourceDeserializer deserializer;

        public DefaultResourceUnmarshaller(IResourceDeserializer deserializer)
        {
            this.deserializer = deserializer;
        }

        public IBehaveAsResource ToResource(string xml, Type objectType)
        {
            try
            {
                return string.IsNullOrEmpty(xml) ? null : deserializer.Deserialize(xml, objectType);
            }
            catch(Exception e)
            {
                throw new UnmarshallingException(e.Message);
            }
        }
    }
}