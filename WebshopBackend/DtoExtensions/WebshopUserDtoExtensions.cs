using WebshopBackend.Data;
using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class WebshopUserDtoExtensions
    {
        public static WebshopUser ToWebshopUser(this WebshopUserDto webshopUserDto, WebshopDbContext context) =>
            context.Users.FirstOrDefault(u => u.Id == webshopUserDto.Id)!;

        public static WebshopUserDto ToWebshopUserDto(this WebshopUser webshopUser) => new WebshopUserDto
        {
            Id = webshopUser.Id,
            UserName = webshopUser.UserName!,
            Email = webshopUser.Email!
        };

    }
}
