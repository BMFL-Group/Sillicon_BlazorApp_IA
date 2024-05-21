﻿using Infrastructure.Models.Account;
using Infrastructure.Models;
using Sillicon_BlazorApp_IA.Data;

namespace Sillicon_BlazorApp_IA.Services
{
    public static class FormMapper
    {
        /// <summary>
        /// Adds the values from a form to the user.
        /// </summary>
        /// <param name="form">Form model</param>
        /// <param name="user">User model</param>
        public static void MapNewValuesFromForm(BasicInfoFormModel form, ApplicationUser user)
        {
            user.FirstName = form.FirstName;
            user.LastName = form.LastName;
            user.Email = form.Email;
            user.UserName = form.Email;
            user.PhoneNumber = form.Phone;
            user.Biography = form.Bio;
        }

        /// <summary>
        /// Adds the values from a form to the adress model.
        /// </summary>
        /// <param name="form">Form model</param>
        /// <param name="user">User model</param>
        public static void MapNewValuesFromForm(AddressFormModel form, AddressModel address)
        {
            address.AddressLine_1 = form.Addressline_1;
            address.AddressLine_2 = form.Addressline_2;
            address.PostalCode = form.PostalCode;
            address.City = form.City;
        }
  
    }
}
