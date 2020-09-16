using Newtonsoft.Json;
using PetShop.Common.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Common.Infra.Helper.Serializers
{
    public class SerializerService : ISerializerService
    {
        public T Deserialize<T>(string serializedObj)
        {
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
