﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoDb.Attributes;
using RepoDb.IntegrationTests.Setup;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace RepoDb.IntegrationTests
{
    [TestClass]
    public class TypeConversionsTest
    {
        private class CompleteTable { }

        [TestInitialize]
        public void Initialize()
        {
            Startup.Init();
            Cleanup();
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb))
            {
                connection.DeleteAll<CompleteTable>();
            }
        }

        #region StringToBigIntClass

        [Map("CompleteTable")]
        private class StringToBigIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnBigInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToBigIntClass()
        {
            // Setup
            var entity = new StringToBigIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBigInt = 12345.ToString()
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnBigInt, data.ColumnBigInt);

                // Act Delete
                var deletedRows = connection.Delete<StringToBigIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToBitClass

        [Map("CompleteTable")]
        private class StringToBitClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnBit { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToBitClass()
        {
            // Setup
            var entity = new StringToBitClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBit = bool.TrueString
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnBit, data.ColumnBit);

                // Act Delete
                var deletedRows = connection.Delete<StringToBitClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToDecimalClass

        [Map("CompleteTable")]
        private class StringToDecimalClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnDecimal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToDecimalClass()
        {
            // Setup
            var entity = new StringToDecimalClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDecimal = "12345.55"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnDecimal, data.ColumnDecimal);

                // Act Delete
                var deletedRows = connection.Delete<StringToDecimalClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToFloatClass

        [Map("CompleteTable")]
        private class StringToFloatClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnFloat { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToFloatClass()
        {
            // Setup
            var entity = new StringToFloatClass
            {
                SessionId = Guid.NewGuid(),
                ColumnFloat = "12345.55"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnFloat, data.ColumnFloat);

                // Act Delete
                var deletedRows = connection.Delete<StringToFloatClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToIntClass

        [Map("CompleteTable")]
        private class StringToIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToIntClass()
        {
            // Setup
            var entity = new StringToIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = "12345"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnInt, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<StringToIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToMoneyClass

        [Map("CompleteTable")]
        private class StringToMoneyClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnMoney { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToMoneyClass()
        {
            // Setup
            var entity = new StringToMoneyClass
            {
                SessionId = Guid.NewGuid(),
                ColumnMoney = "12345.6789"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToMoneyClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnMoney, data.ColumnMoney);

                // Act Delete
                var deletedRows = connection.Delete<StringToMoneyClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToMoneyClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToNumericClass

        [Map("CompleteTable")]
        private class StringToNumericClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnNumeric { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToNumericClass()
        {
            // Setup
            var entity = new StringToNumericClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNumeric = "12345.67"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToNumericClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNumeric, data.ColumnNumeric);

                // Act Delete
                var deletedRows = connection.Delete<StringToNumericClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToNumericClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToRealClass

        [Map("CompleteTable")]
        private class StringToRealClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnReal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToRealClass()
        {
            // Setup
            var entity = new StringToRealClass
            {
                SessionId = Guid.NewGuid(),
                ColumnReal = "12345.67"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnReal, data.ColumnReal);

                // Act Delete
                var deletedRows = connection.Delete<StringToRealClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToSmallIntClass

        [Map("CompleteTable")]
        private class StringToSmallIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnSmallInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToSmallIntClass()
        {
            // Setup
            var entity = new StringToSmallIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnSmallInt = "12345"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnSmallInt, data.ColumnSmallInt);

                // Act Delete
                var deletedRows = connection.Delete<StringToSmallIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToSmallMoneyClass

        [Map("CompleteTable")]
        private class StringToSmallMoneyClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnSmallMoney { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToSmallMoneyClass()
        {
            // Setup
            var entity = new StringToSmallMoneyClass
            {
                SessionId = Guid.NewGuid(),
                ColumnSmallMoney = "12345.6700"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToSmallMoneyClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnSmallMoney, data.ColumnSmallMoney);

                // Act Delete
                var deletedRows = connection.Delete<StringToSmallMoneyClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToSmallMoneyClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToDateClass

        [Map("CompleteTable")]
        private class StringToDateClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnDate { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToDateClass()
        {
            // Setup
            var entity = new StringToDateClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDate = "1970-01-01"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToDateClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual("1/1/1970 12:00:00 AM", data.ColumnDate);

                // Act Delete
                var deletedRows = connection.Delete<StringToDateClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToDateClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToDateTimeClass

        [Map("CompleteTable")]
        private class StringToDateTimeClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnDateTime { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToDateTimeClass()
        {
            // Setup
            var entity = new StringToDateTimeClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDateTime = "1970-01-01 11:30 AM"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToDateTimeClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual("1/1/1970 11:30:00 AM", data.ColumnDateTime);

                // Act Delete
                var deletedRows = connection.Delete<StringToDateTimeClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToDateTimeClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToDateTime2Class

        [Map("CompleteTable")]
        private class StringToDateTime2Class
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnDateTime2 { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToDateTime2Class()
        {
            // Setup
            var entity = new StringToDateTime2Class
            {
                SessionId = Guid.NewGuid(),
                ColumnDateTime2 = "2019-03-03 15:22:10.0500000"
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToDateTime2Class>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual("3/3/2019 3:22:10 PM", data.ColumnDateTime2);

                // Act Delete
                var deletedRows = connection.Delete<StringToDateTime2Class>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToDateTime2Class>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region StringToUniqueIdentifierClass

        [Map("CompleteTable")]
        private class StringToUniqueIdentifierClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public string ColumnUniqueIdentifier { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromStringToUniqueIdentifierClass()
        {
            // Setup
            var entity = new StringToUniqueIdentifierClass
            {
                SessionId = Guid.NewGuid(),
                ColumnUniqueIdentifier = Guid.NewGuid().ToString()
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<StringToUniqueIdentifierClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnUniqueIdentifier, data.ColumnUniqueIdentifier);

                // Act Delete
                var deletedRows = connection.Delete<StringToUniqueIdentifierClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<StringToUniqueIdentifierClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region UniqueIdentifierToStringClass

        [Map("CompleteTable")]
        private class UniqueIdentifierToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public Guid ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromUniqueIdentifierToStringClass()
        {
            // Setup
            var entity = new UniqueIdentifierToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = Guid.NewGuid()
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<UniqueIdentifierToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<UniqueIdentifierToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<UniqueIdentifierToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DateTimeToStringClass (Date, DateTime, DateTime2)

        [Map("CompleteTable")]
        private class DateTimeToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public DateTime ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDateTimeToStringClass()
        {
            // Setup
            var entity = new DateTimeToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = DateTime.UtcNow
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DateTimeToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<DateTimeToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DateTimeToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region IntToStringClass

        [Map("CompleteTable")]
        private class IntToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public int ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromIntToStringClass()
        {
            // Setup
            var entity = new IntToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = int.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<IntToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<IntToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<IntToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region IntToBigIntClass

        [Map("CompleteTable")]
        private class IntToBigIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public int ColumnBigInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromIntToBigIntClass()
        {
            // Setup
            var entity = new IntToBigIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBigInt = int.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<IntToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnBigInt, data.ColumnBigInt);

                // Act Delete
                var deletedRows = connection.Delete<IntToBigIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<IntToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region IntToSmallIntClass

        [Map("CompleteTable")]
        private class IntToSmallIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public int ColumnSmallInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromIntToSmallIntClass()
        {
            // Setup
            var entity = new IntToSmallIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnSmallInt = (int)short.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<IntToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnSmallInt, data.ColumnSmallInt);

                // Act Delete
                var deletedRows = connection.Delete<IntToSmallIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<IntToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region IntToDecimalClass

        [Map("CompleteTable")]
        private class IntToDecimalClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public int ColumnDecimal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromIntToDecimalClass()
        {
            // Setup
            var entity = new IntToDecimalClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDecimal = int.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<IntToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnDecimal, data.ColumnDecimal);

                // Act Delete
                var deletedRows = connection.Delete<IntToDecimalClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<IntToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region IntToFloatClass

        [Map("CompleteTable")]
        private class IntToFloatClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public int ColumnFloat { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromIntToFloatClass()
        {
            // Setup
            var entity = new IntToFloatClass
            {
                SessionId = Guid.NewGuid(),
                ColumnFloat = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<IntToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnFloat, data.ColumnFloat);

                // Act Delete
                var deletedRows = connection.Delete<IntToFloatClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<IntToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region IntToRealClass

        [Map("CompleteTable")]
        private class IntToRealClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public int ColumnReal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromIntToRealClass()
        {
            // Setup
            var entity = new IntToRealClass
            {
                SessionId = Guid.NewGuid(),
                ColumnReal = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<IntToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnReal, data.ColumnReal);

                // Act Delete
                var deletedRows = connection.Delete<IntToRealClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<IntToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region IntToBitClass

        [Map("CompleteTable")]
        private class IntToBitClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public int ColumnBit { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromIntToBitClass()
        {
            // Setup
            var entity = new IntToBitClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBit = 1
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<IntToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnBit, data.ColumnBit);

                // Act Delete
                var deletedRows = connection.Delete<IntToBitClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<IntToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region BigIntToStringClass

        [Map("CompleteTable")]
        private class BigIntToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public long ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromBigIntToStringClass()
        {
            // Setup
            var entity = new BigIntToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = long.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<BigIntToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<BigIntToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<BigIntToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region BigIntToIntClass

        [Map("CompleteTable")]
        private class BigIntToIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public long ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromBigIntToIntClass()
        {
            // Setup
            var entity = new BigIntToIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = int.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<BigIntToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnInt, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<BigIntToIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<BigIntToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region BigIntToSmallIntClass

        [Map("CompleteTable")]
        private class BigIntToSmallIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public long ColumnSmallInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromBigIntToSmallIntClass()
        {
            // Setup
            var entity = new BigIntToSmallIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnSmallInt = short.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<BigIntToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnSmallInt, data.ColumnSmallInt);

                // Act Delete
                var deletedRows = connection.Delete<BigIntToSmallIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<BigIntToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region BigIntToDecimalClass

        [Map("CompleteTable")]
        private class BigIntToDecimalClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public long ColumnDecimal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromBigIntToDecimalClass()
        {
            // Setup
            var entity = new BigIntToDecimalClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDecimal = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<BigIntToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnDecimal, data.ColumnDecimal);

                // Act Delete
                var deletedRows = connection.Delete<BigIntToDecimalClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<BigIntToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region BigIntToFloatClass

        [Map("CompleteTable")]
        private class BigIntToFloatClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public long ColumnFloat { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromBigIntToFloatClass()
        {
            // Setup
            var entity = new BigIntToFloatClass
            {
                SessionId = Guid.NewGuid(),
                ColumnFloat = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<BigIntToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnFloat, data.ColumnFloat);

                // Act Delete
                var deletedRows = connection.Delete<BigIntToFloatClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<BigIntToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region BigIntToRealClass

        [Map("CompleteTable")]
        private class BigIntToRealClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public long ColumnReal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromBigIntToRealClass()
        {
            // Setup
            var entity = new BigIntToRealClass
            {
                SessionId = Guid.NewGuid(),
                ColumnReal = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<BigIntToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnReal, data.ColumnReal);

                // Act Delete
                var deletedRows = connection.Delete<BigIntToRealClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<BigIntToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region BigIntToBitClass

        [Map("CompleteTable")]
        private class BigIntToBitClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public long ColumnBit { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromBigIntToBitClass()
        {
            // Setup
            var entity = new BigIntToBitClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBit = 1
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<BigIntToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnBit, data.ColumnBit);

                // Act Delete
                var deletedRows = connection.Delete<BigIntToBitClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<BigIntToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region SmallIntToStringClass

        [Map("CompleteTable")]
        private class SmallIntToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public short ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromSmallIntToStringClass()
        {
            // Setup
            var entity = new SmallIntToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = short.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<SmallIntToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<SmallIntToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region SmallIntToIntClass

        [Map("CompleteTable")]
        private class SmallIntToIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public short ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromSmallIntToIntClass()
        {
            // Setup
            var entity = new SmallIntToIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = short.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<SmallIntToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnInt, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<SmallIntToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region SmallIntToBigIntClass

        [Map("CompleteTable")]
        private class SmallIntToBigIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public short ColumnBigInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromSmallIntToBigIntClass()
        {
            // Setup
            var entity = new SmallIntToBigIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBigInt = short.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<SmallIntToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnBigInt, data.ColumnBigInt);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToBigIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<SmallIntToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region SmallIntToDecimalClass

        [Map("CompleteTable")]
        private class SmallIntToDecimalClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public short ColumnDecimal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromSmallIntToDecimalClass()
        {
            // Setup
            var entity = new SmallIntToDecimalClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDecimal = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<SmallIntToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnDecimal, data.ColumnDecimal);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToDecimalClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<SmallIntToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region SmallIntToFloatClass

        [Map("CompleteTable")]
        private class SmallIntToFloatClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public short ColumnFloat { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromSmallIntToFloatClass()
        {
            // Setup
            var entity = new SmallIntToFloatClass
            {
                SessionId = Guid.NewGuid(),
                ColumnFloat = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<SmallIntToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnFloat, data.ColumnFloat);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToFloatClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<SmallIntToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region SmallIntToRealClass

        [Map("CompleteTable")]
        private class SmallIntToRealClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public short ColumnReal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromSmallIntToRealClass()
        {
            // Setup
            var entity = new SmallIntToRealClass
            {
                SessionId = Guid.NewGuid(),
                ColumnReal = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<SmallIntToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnReal, data.ColumnReal);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToRealClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<SmallIntToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region SmallIntToBitClass

        [Map("CompleteTable")]
        private class SmallIntToBitClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public short ColumnBit { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromSmallIntToBitClass()
        {
            // Setup
            var entity = new SmallIntToBitClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBit = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<SmallIntToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, data.ColumnBit);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToBitClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<SmallIntToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DecimalToStringClass

        [Map("CompleteTable")]
        private class DecimalToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public decimal ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDecimalToStringClass()
        {
            // Setup
            var entity = new DecimalToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = decimal.MaxValue
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DecimalToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<DecimalToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DecimalToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DecimalToIntClass

        [Map("CompleteTable")]
        private class DecimalToIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public decimal ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDecimalToIntClass()
        {
            // Setup
            var entity = new DecimalToIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DecimalToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<DecimalToIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DecimalToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DecimalToBigIntClass

        [Map("CompleteTable")]
        private class DecimalToBigIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public decimal ColumnBigInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDecimalToBigIntClass()
        {
            // Setup
            var entity = new DecimalToBigIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBigInt = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DecimalToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnBigInt);

                // Act Delete
                var deletedRows = connection.Delete<DecimalToBigIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DecimalToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DecimalToSmallIntClass

        [Map("CompleteTable")]
        private class DecimalToSmallIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public decimal ColumnSmallInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDecimalToSmallIntClass()
        {
            // Setup
            var entity = new DecimalToSmallIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnSmallInt = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DecimalToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnSmallInt);

                // Act Delete
                var deletedRows = connection.Delete<DecimalToSmallIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DecimalToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DecimalToFloatIntClass

        [Map("CompleteTable")]
        private class DecimalToFloatIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public decimal ColumnFloat { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDecimalToFloatIntClass()
        {
            // Setup
            var entity = new DecimalToFloatIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnFloat = 12345.67M
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DecimalToFloatIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnFloat, data.ColumnFloat);

                // Act Delete
                var deletedRows = connection.Delete<DecimalToFloatIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DecimalToFloatIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DecimalToRealClass

        [Map("CompleteTable")]
        private class DecimalToRealClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public decimal ColumnReal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDecimalToRealClass()
        {
            // Setup
            var entity = new DecimalToRealClass
            {
                SessionId = Guid.NewGuid(),
                ColumnReal = 12345.67M
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DecimalToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnReal, data.ColumnReal);

                // Act Delete
                var deletedRows = connection.Delete<DecimalToRealClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DecimalToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DecimalToBitClass

        [Map("CompleteTable")]
        private class DecimalToBitClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public decimal ColumnBit { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDecimalToBitClass()
        {
            // Setup
            var entity = new DecimalToBitClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBit = 1
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DecimalToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, data.ColumnBit);

                // Act Delete
                var deletedRows = connection.Delete<DecimalToBitClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DecimalToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToStringClass

        [Map("CompleteTable")]
        private class DoubleToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToStringClass()
        {
            // Setup
            var entity = new DoubleToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = 12345
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<DoubleToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToDecimalClass

        [Map("CompleteTable")]
        private class DoubleToDecimalClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnDecimal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToDecimalClass()
        {
            // Setup
            var entity = new DoubleToDecimalClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDecimal = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnDecimal, data.ColumnDecimal);

                // Act Delete
                var deletedRows = connection.Delete<DoubleToDecimalClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToBigIntClass

        [Map("CompleteTable")]
        private class DoubleToBigIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnBigInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToBigIntClass()
        {
            // Setup
            var entity = new DoubleToBigIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBigInt = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnBigInt);

                // Act Delete
                var deletedRows = connection.Delete<DoubleToBigIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToIntClass

        [Map("CompleteTable")]
        private class DoubleToIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToIntClass()
        {
            // Setup
            var entity = new DoubleToIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<DoubleToIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToIntClass

        [Map("CompleteTable")]
        private class DoubleToSmallIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToSmallIntClass()
        {
            // Setup
            var entity = new DoubleToSmallIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<DoubleToSmallIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToFloatClass

        [Map("CompleteTable")]
        private class DoubleToFloatClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnFloat { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToFloatClass()
        {
            // Setup
            var entity = new DoubleToFloatClass
            {
                SessionId = Guid.NewGuid(),
                ColumnFloat = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnFloat, data.ColumnFloat);

                // Act Delete
                var deletedRows = connection.Delete<DoubleToFloatClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToRealClass

        [Map("CompleteTable")]
        private class DoubleToRealClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnReal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToRealClass()
        {
            // Setup
            var entity = new DoubleToRealClass
            {
                SessionId = Guid.NewGuid(),
                ColumnReal = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnReal, Math.Round(data.ColumnReal, 2));

                // Act Delete
                var deletedRows = connection.Delete<DoubleToRealClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region DoubleToBitClass

        [Map("CompleteTable")]
        private class DoubleToBitClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnBit { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromDoubleToBitClass()
        {
            // Setup
            var entity = new DoubleToBitClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBit = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<DoubleToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, data.ColumnBit);

                // Act Delete
                var deletedRows = connection.Delete<DoubleToBitClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<DoubleToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToStringClass (Real, Money, Float)

        [Map("CompleteTable")]
        private class FloatToStringClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public float ColumnNVarChar { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToStringClass()
        {
            // Setup
            var entity = new FloatToStringClass
            {
                SessionId = Guid.NewGuid(),
                ColumnNVarChar = 12345.7F
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnNVarChar, data.ColumnNVarChar);

                // Act Delete
                var deletedRows = connection.Delete<SmallIntToStringClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToStringClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToDecimalClass

        [Map("CompleteTable")]
        private class FloatToDecimalClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnDecimal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToDecimalClass()
        {
            // Setup
            var entity = new FloatToDecimalClass
            {
                SessionId = Guid.NewGuid(),
                ColumnDecimal = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnDecimal, data.ColumnDecimal);

                // Act Delete
                var deletedRows = connection.Delete<FloatToDecimalClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToDecimalClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToBigIntClass

        [Map("CompleteTable")]
        private class FloatToBigIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnBigInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToBigIntClass()
        {
            // Setup
            var entity = new FloatToBigIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBigInt = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnBigInt);

                // Act Delete
                var deletedRows = connection.Delete<FloatToBigIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToBigIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToIntClass

        [Map("CompleteTable")]
        private class FloatToIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToIntClass()
        {
            // Setup
            var entity = new FloatToIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<FloatToIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToIntClass

        [Map("CompleteTable")]
        private class FloatToSmallIntClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnInt { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToSmallIntClass()
        {
            // Setup
            var entity = new FloatToSmallIntClass
            {
                SessionId = Guid.NewGuid(),
                ColumnInt = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(12345, data.ColumnInt);

                // Act Delete
                var deletedRows = connection.Delete<FloatToSmallIntClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToSmallIntClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToFloatClass

        [Map("CompleteTable")]
        private class FloatToFloatClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnFloat { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToFloatClass()
        {
            // Setup
            var entity = new FloatToFloatClass
            {
                SessionId = Guid.NewGuid(),
                ColumnFloat = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnFloat, data.ColumnFloat);

                // Act Delete
                var deletedRows = connection.Delete<FloatToFloatClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToFloatClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToRealClass

        [Map("CompleteTable")]
        private class FloatToRealClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnReal { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToRealClass()
        {
            // Setup
            var entity = new FloatToRealClass
            {
                SessionId = Guid.NewGuid(),
                ColumnReal = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(entity.ColumnReal, Math.Round(data.ColumnReal, 2));

                // Act Delete
                var deletedRows = connection.Delete<FloatToRealClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToRealClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion

        #region FloatToBitClass

        [Map("CompleteTable")]
        private class FloatToBitClass
        {
            [Primary]
            public Guid SessionId { get; set; }
            public double ColumnBit { get; set; }
        }

        [TestMethod]
        public void TestSqlConnectionCrudConvertionFromFloatToBitClass()
        {
            // Setup
            var entity = new FloatToBitClass
            {
                SessionId = Guid.NewGuid(),
                ColumnBit = 12345.67
            };

            using (var connection = new SqlConnection(Startup.ConnectionStringForRepoDb).EnsureOpen())
            {
                // Act Insert
                var id = connection.Insert(entity);

                // Act Query
                var data = connection.Query<FloatToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, data.ColumnBit);

                // Act Delete
                var deletedRows = connection.Delete<FloatToBitClass>(e => e.SessionId == (Guid)id);

                // Act Query
                data = connection.Query<FloatToBitClass>(e => e.SessionId == (Guid)id).FirstOrDefault();

                // Assert
                Assert.AreEqual(1, deletedRows);
                Assert.IsNull(data);
            }
        }

        #endregion
    }
}
