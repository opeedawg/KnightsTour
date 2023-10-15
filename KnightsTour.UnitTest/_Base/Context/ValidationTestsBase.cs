// © 2023 DXterity Solutions
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : March 19, 2023 7:56:06 AM
// File             : ValidationTestsBase.cs
// ************************************************************************

using System;
using KnightsTour;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace KnightsTourUnitTests.Context
{
    [TestClass]
    public class ValidationTestsBase : DataTestBase<int?>
{
        #region Initialization and Cleanup routines
        [TestInitialize]
        public void TestInitialize()
        {
            //Start with no validators on the dummy table.
            KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()] = new Dictionary<string, KnightsTour.CoreLibrary.IFieldValidator>();
        }
        #endregion

        #region Tests
        [TestMethod]
        public void Initialized()
        {
            InitializeValidation();
        }
        [TestMethod]
        public void AddOrUpdate_Single()
        {
            InitializeValidation();

            KnightsTour.Context.ValidationHandler.AddOrUpdate(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), new FieldValidator
            {
                FieldName ="Amount",
                MinimumValue = 99.99M
            });

            Assert.AreEqual(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()].Count, 1);
        }
        [TestMethod]
        public void AddOrUpdate_Multiple()
        {
            InitializeValidation();

            AddValidators();

            Assert.AreEqual(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()].Count, 2);
        }
        [TestMethod]
        public void Exists()
        {
            InitializeValidation();

            AddValidators();

            Assert.AreEqual(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()].Count, 2);
            Assert.IsTrue(KnightsTour.Context.ValidationHandler.Exists(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount"));
            Assert.IsTrue(KnightsTour.Context.ValidationHandler.Exists(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "CreateDate"));
        }
        [TestMethod]
        public void Remove()
        {
            InitializeValidation();

            AddValidators();

            Assert.AreEqual(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()].Count, 2);
            Assert.IsTrue(KnightsTour.Context.ValidationHandler.Exists(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount"));
            Assert.IsTrue(KnightsTour.Context.ValidationHandler.Exists(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "CreateDate"));
            KnightsTour.Context.ValidationHandler.Remove(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount");
            Assert.AreEqual(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()].Count, 1);
            Assert.IsFalse(KnightsTour.Context.ValidationHandler.Exists(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount"));
            KnightsTour.Context.ValidationHandler.Remove(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "CreateDate");
            Assert.AreEqual(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()].Count, 0);
            Assert.IsFalse(KnightsTour.Context.ValidationHandler.Exists(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "CreateDate"));
        }
        [TestMethod]
        public void Get_Single()
        {
            InitializeValidation();

            AddValidators();

            KnightsTour.CoreLibrary.IFieldValidator validator = KnightsTour.Context.ValidationHandler.GetFieldValidator(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount");
            Assert.IsNotNull(validator);
            Assert.AreEqual(validator.Table, KnightsTour.Enumerations.EntityName.DummyTable.ToString());
            Assert.AreEqual(validator.FieldName, "Amount");
            Assert.AreEqual(validator.MinimumValue, 99.99M);
        }
        [TestMethod]
        public void Get_Multiple()
        {
            InitializeValidation();

            AddValidators();

            List<KnightsTour.CoreLibrary.IFieldValidator> validators = KnightsTour.Context.ValidationHandler.GetFieldValidators(KnightsTour.Enumerations.EntityName.DummyTable.ToString());
            Assert.IsTrue(validators.Count > 0);
            KnightsTour.CoreLibrary.IFieldValidator amountValidator = validators.FirstOrDefault(v => v.FieldName == "Amount");
            Assert.AreEqual(amountValidator.Table, KnightsTour.Enumerations.EntityName.DummyTable.ToString());
            Assert.AreEqual(amountValidator.FieldName, "Amount");
            Assert.AreEqual(amountValidator.MinimumValue, 99.99M);
        }
        [TestMethod]
        public void ValidateField()
        {
            InitializeValidation();

            AddValidators();

            //Too small!
            KnightsTour.CoreLibrary.ActionResponse response = KnightsTour.Context.ValidationHandler.ValidateField(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount", 9.99M);
            Assert.IsFalse(response.IsValid);

            //Too big!
            response = KnightsTour.Context.ValidationHandler.ValidateField(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount", 1999.99M);
            Assert.IsFalse(response.IsValid);

            //Just right :)
            response = KnightsTour.Context.ValidationHandler.ValidateField(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "Amount", 199.99M);
            Assert.IsTrue(response.IsValid);
        }
        [TestMethod]
        public void ValidateEntity()
        {
            InitializeValidation();

            AddValidators();

            //Too small!
            DummyClass dummyClass = GetNewEntity<DummyClass>();
            dummyClass.Amount = 9.99M;
            dummyClass.CreateDate = DateTime.Now.AddDays(1);
            KnightsTour.CoreLibrary.ActionResponse response = KnightsTour.Context.ValidationHandler.ValidateEntity<int?>(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "", dummyClass);
            Assert.IsFalse(response.IsValid);

            //Too big!
            dummyClass = GetNewEntity<DummyClass>();
            dummyClass.Amount = 1999.99M;
            dummyClass.CreateDate = DateTime.Now.AddDays(-1);
            response = KnightsTour.Context.ValidationHandler.ValidateEntity<int?>(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "", dummyClass);
            Assert.IsFalse(response.IsValid);

            //Just right :)
            dummyClass = GetNewEntity<DummyClass>();
            dummyClass.Amount = 199.99M;
            dummyClass.CreateDate = DateTime.Now.AddDays(-1);
            response = KnightsTour.Context.ValidationHandler.ValidateEntity<int?>(KnightsTour.Enumerations.EntityName.DummyTable.ToString(), "", dummyClass);
            Assert.IsTrue(response.IsValid);
        }
        #endregion

        #region Private support methods
        void InitializeValidation()
        {
            Assert.IsNotNull(KnightsTour.Context.ValidationHandler);
            Assert.IsTrue(KnightsTour.Context.ValidationHandler.FieldConfiguration.ContainsKey(KnightsTour.Enumerations.EntityName.DummyTable.ToString()));
            Assert.IsNotNull(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()]);
            Assert.AreEqual(KnightsTour.Context.ValidationHandler.FieldConfiguration[KnightsTour.Enumerations.EntityName.DummyTable.ToString()].Count, 0);
        }
        void AddValidators()
        {
            KnightsTour.Context.ValidationHandler.AddOrUpdate(KnightsTour.Enumerations.EntityName.DummyTable.ToString(),
                new KnightsTour.FieldValidator()
                {
                    FieldName = "Amount",
                    MinimumValue = 99.99M,
                    MaximumValue = 999.99M,
                    ObjectType = typeof(decimal)
                });
            KnightsTour.Context.ValidationHandler.AddOrUpdate(KnightsTour.Enumerations.EntityName.DummyTable.ToString(),
                new KnightsTour.FieldValidator()
                {
                    FieldName = "CreateDate",
                    MaximumValue = DateTime.Now,
                    ObjectType = typeof(DateTime)
                });
        }
        #endregion
    }
}