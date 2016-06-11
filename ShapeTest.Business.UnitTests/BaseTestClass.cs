using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShapeTest.Business.Repositories;

namespace ShapeTest.Business.UnitTests
{
    /// <summary>
    /// Base abstract class for tests
    /// </summary>
    public abstract class BaseTestClass
    {
        protected MockRepository _MockRepository;
        protected BaseTestClass()
        {
            _MockRepository = new MockRepository(MockBehavior.Strict);
        }


    }
}
