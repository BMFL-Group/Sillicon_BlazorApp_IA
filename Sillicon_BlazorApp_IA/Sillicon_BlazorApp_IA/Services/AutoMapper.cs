﻿using Infrastructure.Models.Account;
using Infrastructure.Models;
using Sillicon_BlazorApp_IA.Data;
using Azure.Core;

namespace Sillicon_BlazorApp_IA.Services
{
    public static class AutoMapper
    {
        /// <summary>
        /// Creates a new ApplicationUser.
        /// </summary>
        /// <param name="fristName">string content</param>
        /// <param name="lastName">string content</param>
        /// <param name="email">string content</param>
        /// <param name="UserName">string content</param>
        public static ApplicationUser MapNewApplicationUser(string fristName, string lastName, string email, string UserName)
        {
            var newUser = new ApplicationUser
            {
                FirstName = fristName,
                LastName = lastName,
                Email = email,
                UserName = UserName
            };

            return newUser;
        }

        /// <summary>
        /// Adds the values to the SubscribeConfirmModel and creates a new message.
        /// </summary>
        /// <param name="email">string content</param>
        /// <param name="subject">string content</param>
        /// <param name="htmlBody">string content</param>
        /// <param name="plainText">string content</param>
        public static SubscribeConfirmModel MapNewSubscriptionModel(string email, string subject, string htmlBody, string plainText)
        {
            var emailModel = new SubscribeConfirmModel
            {
                To = email,
                Subject = subject,
                HtmlBody = htmlBody,
                PlainText = plainText
            };

            return emailModel;
        }

        /// <summary>
        /// Creates a new address with the form values and adds it to a user.
        /// </summary>
        /// <param name="form">Form model</param>
        /// <param name="user">User model</param>
        public static AddressModel MapNewAddress(AddressFormModel form, ApplicationUser user)
        {
            if (form != null)
            {
                var newAddress = new AddressModel
                {
                    AddressLine_1 = form.Addressline_1,
                    AddressLine_2 = form.Addressline_2,
                    PostalCode = form.PostalCode,
                    City = form.City,
                };
                newAddress.Users.Add(user);

                return newAddress;
            }
            return null!;
        }

        /// <summary>
        /// Adds the values from a user to the form.
        /// </summary>
        /// <param name="form">Form model</param>
        /// <param name="user">User model</param>
        public static void MapNewFormValues(BasicInfoFormModel form, ApplicationUser user)
        {
            if(user != null && form != null)
            {
                form.FirstName = user.FirstName;
                form.LastName = user.LastName;
                form.Email = user.Email!;
                form.Phone = user.PhoneNumber;
                form.Bio = user.Biography;
            }
        }

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

        /// <summary>
        /// Adds the values from a form to the useraddress.
        /// </summary>
        /// <param name="form">Form model</param>
        /// <param name="user">User model</param>
        public static void MapNewUserAddress(AddressFormModel form, ApplicationUser user)
        {
            if(user != null && form != null)
            {
                if (user.Address == null)
                    user.Address = new AddressModel();

                user!.Address.AddressLine_1 = form.Addressline_1;
                user.Address.AddressLine_2 = form.Addressline_2;
                user.Address.PostalCode = form.PostalCode;
                user.Address.City = form.City;
            }       
        }

        /// <summary>
        /// Adds the values from a AddressFormModel to the form.
        /// </summary>
        /// <param name="form">Form model</param>
        /// <param name="address">address model</param>
        public static void MapNewFormValues(AddressFormModel form, AddressModel address)
        {
            if (address != null && form != null)
            {
                form.Addressline_1 = address.AddressLine_1;
                form.Addressline_2 = address.AddressLine_2;
                form.City = address.City;
                form.PostalCode = address.PostalCode;
            }
        }

        /// <summary>
        /// Adds the values from a ApplicationUser to the ClientUserModel.
        /// </summary>
        /// <param name="clientUser">ClientUserModel model</param>
        /// <param name="user">ApplicationUser model</param>
        public static void MapClientUser(ClientUserModel clientUser, ApplicationUser user)
        {
            clientUser.Id = user.Id;
            clientUser.FirstName = user.FirstName;
            clientUser.Email = user.Email!;
            clientUser.ProfileImg = user.ProfileImageUrl;
        }
    }
}
