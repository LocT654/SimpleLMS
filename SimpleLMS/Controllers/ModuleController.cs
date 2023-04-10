using NUnit.Framework;
using SimpleLMSWebApi.Controllers;
using SimpleLMSWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleLMSWebApi.Tests
{
    [TestFixture]
    public class ModuleControllerTests
    {
        private ModuleController _controller;
        private List<Module> _modules;

        [SetUp]
        public void Setup()
        {
            _modules = new List<Module> {
                new Module { CourseId = 1, Id = 1, Name = "Math" },
                new Module { CourseId = 1, Id = 2, Name = "History" },
                new Module { CourseId = 2, Id = 3, Name = "Science" },
            };

            _controller = new ModuleController(_modules);
        }

        [Test]
        public void Index_ReturnsListOfModules()
        {
            var result = _controller.GetModules();

            Assert.IsInstanceOf<IEnumerable<Module>>(result);
            Assert.That(result.Count(), Is.EqualTo(_modules.Count));
        }

        [Test]
        public void GetModule_ReturnsModule()
        {
            int moduleId = 2;
            Module expectedModule = _modules.FirstOrDefault(m => m.Id == moduleId);

            Module actualModule = _controller.GetModule(moduleId);

            Assert.That(actualModule.CourseId, Is.EqualTo(expectedModule.CourseId));
            Assert.That(actualModule.Id, Is.EqualTo(expectedModule.Id));
            Assert.That(actualModule.Name, Is.EqualTo(expectedModule.Name));
        }

        [Test]
        public void AddModule_AddsModuleToList()
        {
            var moduleToAdd = new Module { CourseId = 1, Id = 4, Name = "Circles" };

            var result = _controller.AddModule(moduleToAdd);

            Assert.Contains(moduleToAdd, result);
            Assert.That(result.Count(), Is.EqualTo(_modules.Count + 1));
        }

        [Test]
        public void UpdateModule_UpdatesModule()
        {
            var oldModuleId = 1;
            var newModule = new Module { CourseId = 1, Id = 1, Name = "Rectangles" };

            var result = _controller.UpdateModule(oldModuleId, newModule);

            Assert.Contains(newModule, result);
            Assert.That(result.FirstOrDefault(m => m.Id == oldModuleId), Is.Not.EqualTo(_modules.FirstOrDefault(m => m.Id == oldModuleId)));
        }

        [Test]
        public void RemoveModule_RemovesExistingModule()
        {
            var moduleIdToRemove = 3;

            var result = _controller.RemoveModule(moduleIdToRemove);

            Assert.IsNull(result.FirstOrDefault(m => m.Id == moduleIdToRemove));
            Assert.That(result.Count(), Is.EqualTo(_modules.Count - 1));
        }
    }
}
