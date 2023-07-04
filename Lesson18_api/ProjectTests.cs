using Lesson18_api.BusinessObject;
using Lesson18_api.BusinessObject.ApiServiceSteps;
using Lesson18_api.BusinessObject.Model;
using Lesson18_api.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Core.Configuration;
using Lesson18_api.Core;

namespace Lesson18_api
{
    internal class ProjectTests : BaseApiTest
    {

        protected ProjectService projectService;
        protected ApiProjectSteps apiProjectSteps;

        [OneTimeSetUp]
        public void InitialService()
        {
            projectService = new ProjectService();
            apiProjectSteps = new ApiProjectSteps();
                        
        }

        [Test]
        public void GetProjectById()
        {
            var projectCode = "TESTM";

            var response = projectService.GetProjectByCode(projectCode);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.ContentEncoding);
            Console.WriteLine(response.StatusCode);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }

        [Test]
        public void GetProjectById_RespenseModel()
        {
            var projectCode = "TESTM";

            var project = apiProjectSteps.GetProjectByCode(projectCode);

            Console.WriteLine(project.Title);
        }


        [Test]
        public void CreateProject()
        {
            var projectModel = new CreateProjectModel()
            {
                Title = "Test",
                Code = "1234",
             ////  Code = $"{new Faker().Finance.RoutingNumber()}",
                Access = "none"
            };

            var projectResponse = projectService.CreateProject(projectModel);
           /// Assert.IsTrue(projectResponse.StatusCode.Equals(HttpStatusCode.OK));
            Console.WriteLine(projectResponse.Content);
        }

        [Test]
        public void GetAllProjects()
        {
            int limit = 10;
            int offset = 0;
            var projectResponse = projectService.GetAllProjects(limit, offset);
            Console.WriteLine(projectResponse.Content);
        }

        [Test]
        public void GrantAccesstToProjectByCode()
        {
            string code = "TESTM";
            int memberid = 151174;
            var projectResponse = projectService.GrantAccesstToProjectByCode(code, memberid);
            Console.WriteLine(projectResponse.Content);
        }

        [Test]
        public void RevokeAccessToProjectByCode()
        {
            string code = "TESTM";
            int memberid = 151175;
            var projectResponse = projectService.RevokeAccessToProjectByCode(code, memberid);
            Console.WriteLine(projectResponse.Content);
        }

        [Test]
        public void DeleteProjectByCode()
        {
            string code = "TESTM";
            var projectResponse = projectService.DeleteProjectByCode(code);
            Console.WriteLine(projectResponse.ResponseStatus);
        }


    }
}