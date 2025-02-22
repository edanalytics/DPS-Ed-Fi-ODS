﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using NUnit.Framework;

namespace EdFi.Ods.Api.IntegrationTests
{
    public abstract class DatabaseTestFixtureBase
    {
        private TransactionScope _transaction;
        protected IDbConnection Connection { get; private set; }
        protected EducationOrganizationTestDataBuilder Builder { get; private set; }

        [SetUp]
        public void Setup()
        {
            _transaction = new TransactionScope();
            Connection = BuildTestConnection();
            Builder = EducationOrganizationTestDataBuilder.Initialize(Connection);
        }

        [TearDown]
        public void TearDown()  
        {
            _transaction.Dispose();
        }

        protected virtual IDbConnection BuildTestConnection()
        {
            var connection = new SqlConnection(OneTimeGlobalDatabaseSetup.SqlServerConnectionString);
            connection.Open();
            return connection;
        }
    }
}
