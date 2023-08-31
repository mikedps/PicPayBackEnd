﻿using FluentValidation;
using PicPayBackEnd.Data.DTOs;
using PicPayBackEnd.Data.Repositories;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Utils;
using PicPayBackEnd.Domain.ValueObjects;


namespace PicPayBackEnd.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public readonly IValidator<User> _validator;

        public UserService(IUserRepository repository, IValidator<User> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result> CreateUser(UserDTO request)
        {
            request.DocumentID =  Utils.ApenasNumeros(request.DocumentID);

            var documento = DocumentID.CreateDocumentID(request.DocumentID);
            var email = Email.CreateEmail(request.Email);
            var user = User.CreateUser(request.Name, request.Surname, request.UserType, documento,email);

            var validate = _validator.Validate(user);

            var result = new Result();
            if(!validate.IsValid)
            {
                foreach(var error in validate.Errors)
                {
                    result.AddError(error.ErrorMessage);
                }
                return result;
            }

            if (await _repository.DocumentAlreadyExistsAsync(documento))
            {
                result.AddError($"Document {documento.Value} already been used");
            }
            if (await _repository.EmailAlreadyExistsAsync(email))
            {
                result.AddError($"Email {email.Value} already been used");
            }

            if(!result.Valid)
            {
                return result;
            }

            await _repository.CreateAsync(user);

            return result;

        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _repository.GetAllUsersAsync();
            return users;
        }
    }
}
