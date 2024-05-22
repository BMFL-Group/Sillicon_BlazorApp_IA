using Infrastructure.Models.Account;
using Infrastructure.Models;
using Sillicon_BlazorApp_IA.Data;
using Microsoft.Azure.Amqp.Framing;
using System.Net;

namespace Sillicon_BlazorApp_IA.Services
{
    public static class FormMapper
    {
        /// <summary>
        /// Adds the values from a form to the user.
        /// </summary>
        /// <param name="form">Form model</param>
        /// <param name="user">User model</param>
        public static void MapNewUserValues(BasicInfoFormModel form, ApplicationUser user)
        {
            user.FirstName = form.FirstName;
            user.LastName = form.LastName;
            user.Email = form.Email;
            user.UserName = form.Email;
            user.PhoneNumber = form.Phone;
            user.Biography = form.Bio;
            user.UserName = form.Email;
        }
        public static void MapNewUserAddress(AddressFormModel form, ApplicationUser user)
        {
            if(user != null && form != null)
            {
                if (user.Address == null)
                    user.Address = new AddressModel();

                user!.Address.AddressLine_1 = form.Addressline_1;
                user.Address.AddressLine_2 = form.Addressline_2 ?? "";
                user.Address.PostalCode = form.PostalCode;
                user.Address.City = form.City;
            }       
        }

        public static AddressModel MapNewAddress(AddressFormModel form, ApplicationUser user)
        {
            if (form != null)
            {
                var newAddress = new AddressModel
                {
                    AddressLine_1 = form.Addressline_1,
                    AddressLine_2 = form.Addressline_2 ?? "",
                    PostalCode = form.PostalCode,
                    City = form.City,
                };
                newAddress.Users.Add(user);
                //newAddress.Users.Add(new ApplicationUser
                //{
                //    Id = user.Id,
                //    FirstName = user.FirstName,
                //    LastName = user.LastName,
                //    Email = user.Email,
                //    UserName = user.Email,
                //    PhoneNumber = user.PhoneNumber,
                //    Biography = user.Biography
                //});

                return newAddress;
            }
            return null!;
        }
    }
}
