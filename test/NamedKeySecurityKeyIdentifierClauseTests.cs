﻿
//-----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//-----------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace System.IdentityModel.Test
{
    [TestClass]
    public class NamedKeySecurityKeyIdentifierClauseTests
    {
                /// <summary>
        /// Test Context Wrapper instance on top of TestContext. Provides better accessor functions
        /// </summary>
        protected TestContextProvider _testContextProvider;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassSetup( TestContext testContext )
        {}

        [ClassCleanup]
        public static void ClassCleanup()
        {}

        [TestInitialize]
        public void Initialize()
        {
            _testContextProvider = new TestContextProvider( TestContext );
        }

        [TestMethod]
        [TestProperty("TestCaseID", "0B23D0BA-5F60-4EBA-BA11-7BCD23432D84")]
        [Description("Tests: Constructor")]
        public void NamedKeySecurityKeyIdentifierClause_Constructor()
        {
            NamedKeySecurityKeyIdentifierClause namedKeySecurityKeyIdentifierClause;
            ExpectedException expectedException = new ExpectedException(thrown: typeof(ArgumentNullException), id: "name");
            try
            {
                namedKeySecurityKeyIdentifierClause = new NamedKeySecurityKeyIdentifierClause(null, null);
                ExpectedException.ProcessNoException(expectedException);
            }
            catch(Exception exception)
            {
                ExpectedException.ProcessException(expectedException, exception);
            }

            expectedException = new ExpectedException(thrown: typeof(ArgumentNullException), id: "keyIdentifier");
            try
            {
                namedKeySecurityKeyIdentifierClause = new NamedKeySecurityKeyIdentifierClause("name", null);
                ExpectedException.ProcessNoException(expectedException);
            }
            catch (Exception exception)
            {
                ExpectedException.ProcessException(expectedException, exception);
            }

            expectedException = new ExpectedException(thrown: typeof(ArgumentException), id: "WIF10000");
            try
            {
                namedKeySecurityKeyIdentifierClause = new NamedKeySecurityKeyIdentifierClause(name: "     ", keyIdentifier: "keyIdentifier");
                ExpectedException.ProcessNoException(expectedException);
            }
            catch (Exception exception)
            {
                ExpectedException.ProcessException(expectedException, exception);
            }

            expectedException = new ExpectedException(thrown: typeof(ArgumentException), id: "WIF10000");
            try
            {
                namedKeySecurityKeyIdentifierClause = new NamedKeySecurityKeyIdentifierClause("name", "     ");
                ExpectedException.ProcessNoException(expectedException);
            }
            catch (Exception exception)
            {
                ExpectedException.ProcessException(expectedException, exception);
            }
        }

        [TestMethod]
        [TestProperty("TestCaseID", "46693B19-671C-4113-9F73-186C0E3467A4")]
        [Description("Tests: Defaults")]
        public void NamedKeySecurityKeyIdentifierClause_Defaults()
        {
            NamedKeySecurityKeyIdentifierClause namedKeySecurityKeyIdentifierClause = new NamedKeySecurityKeyIdentifierClause("name", "keyidentifier");
            Assert.IsTrue("NamedKeySecurityKeyIdentifierClause" == namedKeySecurityKeyIdentifierClause.ClauseType);
        }

        [TestMethod]
        [TestProperty("TestCaseID", "590F3BE5-4CDF-49F6-81B7-424D5AE5A0D9")]
        [Description("Tests: Publics")]
        public void NamedKeySecurityKeyIdentifierClause_Publics()
        {
            NamedKeySecurityKeyIdentifierClause namedKeySecurityKeyIdentifierClause = new NamedKeySecurityKeyIdentifierClause("name", "keyidentifier");
            Assert.IsTrue("name" == namedKeySecurityKeyIdentifierClause.Name);
            Assert.IsTrue("keyidentifier" == namedKeySecurityKeyIdentifierClause.KeyIdentifier);

            // *** Matches (null)
            ExpectedException expectedException = new ExpectedException(thrown: typeof(ArgumentNullException), id: "keyIdentifierClause");
            try
            {
                namedKeySecurityKeyIdentifierClause.Matches(null);
                ExpectedException.ProcessNoException(expectedException);
            }
            catch (Exception exception)
            {
                ExpectedException.ProcessException(expectedException, exception);
            }

        }
    }
}