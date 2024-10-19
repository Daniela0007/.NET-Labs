using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Use_Cases.Commands
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        [JsonIgnore] // nu trebuie sa am posibilitatea sa schimb Id-ul cartii, e corect asa sa fac ??
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
