﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using Npgsql;
using NUnit.Framework;
using System.Data;

namespace EdFi.Ods.Api.IntegrationTests
{
    // This class provides a VERY manual way to execute the Education Organization Id tuple tests based on DatabaseTestFixtureBase against a PostgreSQL database
    // Assumes the database defined in OneTimeGlobalDatabaseSetup.PostgreSqlConnectionString has already been set up (by default initdev -Engine PostgreSQL will create this database)
    // All tests are marked as Explicit to ensure they only run when explicitly requested
    // If new tests are added just create another subclass here.
    // See ODS-5022 for the more robust solution to PostgreSQL testing.
    public class ManualPostgreSqlTests
    {
        private static IDbConnection BuildPostgreSqlConnection()
        {
            var connection = new NpgsqlConnection(OneTimeGlobalDatabaseSetup.PostgreSqlConnectionString);
            connection.Open();
            return connection;
        }

        [TestFixture, Explicit]
        public class PostgreSqlEducationOrganizationTests : EducationOrganizationTests
        {
            protected override IDbConnection BuildTestConnection()
            {
                return BuildPostgreSqlConnection();
            }
        }

        [TestFixture, Explicit]
        public class PostgreSqlSchoolTests : SchoolTests
        {
            protected override IDbConnection BuildTestConnection()
            {
                return BuildPostgreSqlConnection();
            }
        }

        [TestFixture, Explicit]
        public class PostgreSqlStudentUSIToEducationOrganizationIdAuthViewTests : StudentUSIToEducationOrganizationIdAuthViewTests
        {
            protected override IDbConnection BuildTestConnection()
            {
                return BuildPostgreSqlConnection();
            }
        }

    }
}
