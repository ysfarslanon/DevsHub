using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kodlama.io.Devs.Application.Features.DeveloperUsers.Rules
{
    public class DeveloperUserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public DeveloperUserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserLoginEMailCheck(string email)
        {
            User user = await _userRepository.GetAsync(u => u.Email == email);

            if (user is null) throw new BusinessException("Kullanıcı bulunamadı");
        }

        public async Task UserMustExist(User user)
        {
            if (user == null) throw new BusinessException("Kullanıcı bulunamadı");
        }

        public async Task IsVerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Hatalı şifre");
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userRepository.GetAsync(u => u.Email.ToLower().Equals(email.ToLower()));
            if (result != null) throw new BusinessException("Bu e-posta adresi zaten kayıtlı");
        }

    }
}
