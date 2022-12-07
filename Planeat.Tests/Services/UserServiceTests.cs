﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Moq;
using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using Planeat.Infrastructure.Repositories;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Planeat.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterAsync_AddValidUser_ShouldAddAsyncOnUserRepository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            //var encrypterMock = new Mock<IEncrypter>();
            var passwordHasherMock = new Mock<IPasswordHasher<User>>();

            var userService = new UserService(
                userRepositoryMock.Object, mapperMock.Object, passwordHasherMock.Object);
            await userService.RegisterAsync("userTest@user.com", "userTest", "secretTest", 1);

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        //[Fact]
        //public async Task RegisterAsync_AddUserWithExistingEmail_ShouldThrowsException()
        //{
        //}

        //[Fact]
        //public async Task GetAsync_WithValidEmail_ShouldInvokeGetAsyncOnUserRepositoryAndReturnsUser()
        //{
        //}

        //[Fact]
        //public async Task GetAsync_WithInvalidEmail_ShouldInvokeGetAsyncOnUserRepositoryAndReturns404()
        //{
        //}
    }
}
