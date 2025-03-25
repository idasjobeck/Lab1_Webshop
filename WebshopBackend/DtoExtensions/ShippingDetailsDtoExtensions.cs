using System.ComponentModel.DataAnnotations;
using WebshopBackend.Data;
using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class ShippingDetailsDtoExtensions
    {
        
        public static ShippingDetails ToShippingDetails(this ShippingDetailsDto shippingDetailsDto, WebshopDbContext context) =>
            new ShippingDetails
            {
                Id = 0,
                ShipFirstName = shippingDetailsDto.FirstName,
                ShipLastName = shippingDetailsDto.LastName,
                ShipAdd1 = shippingDetailsDto.Address1,
                ShipAdd2 = shippingDetailsDto.Address2,
                ShipCity = shippingDetailsDto.City,
                ShipZip = shippingDetailsDto.Zip,
                ShipCountry = shippingDetailsDto.Country,
                User = context.Users.FirstOrDefault(u => u.Id == shippingDetailsDto.User.Id)!
            };

        public static ShippingDetailsDto ToShippingDetailsDto(this ShippingDetails shippingDetails) =>
            new ShippingDetailsDto
            {
                FirstName = shippingDetails.ShipFirstName,
                LastName = shippingDetails.ShipLastName,
                Email = shippingDetails.User.Email!, // will this work?
                Address1 = shippingDetails.ShipAdd1,
                Address2 = shippingDetails.ShipAdd2,
                City = shippingDetails.ShipCity,
                Zip = shippingDetails.ShipZip,
                Country = shippingDetails.ShipCountry,
                User = shippingDetails.User.ToWebshopUserDto()
            };
    }
}
