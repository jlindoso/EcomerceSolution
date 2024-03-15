using Domain.Entities.Base;
using Domain.Exceptions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company: BaseModel
    {
        public string Name { get; set; }

        public Company()
        {
            
        }
        public Company(string name)
        {
            Name = name;
            var contract = new Contract<Company>()
                                        .IsNotNullOrEmpty(Name, nameof(Name));
            AddNotifications(contract);
        }

    }
}
