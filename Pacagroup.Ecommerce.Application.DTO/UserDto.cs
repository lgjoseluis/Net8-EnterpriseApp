﻿namespace Pacagroup.Ecommerce.Application.DTO;

public record UserDto
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }    
    public string Token { get; set; }
}
