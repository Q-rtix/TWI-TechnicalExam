using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.Dtos;

public record ClientDto(int Id, Name Name, string Email, PhoneNumber Phone, ICollection<Sale> Sales);
