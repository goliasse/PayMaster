using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Paymaster.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private bool IsPluralizationCorrect(string singular, string plural)
        {
            var pluralizedString = PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(singular);
            return string.Equals(plural, pluralizedString);
        }

        [TestMethod]
        public void PluraliseService_table_User()
        {
            Assert.IsTrue(IsPluralizationCorrect("User", "Users"));
        }

        [TestMethod]
        public void PluraliseService_table_payorvariable()
        {
            Assert.IsTrue(IsPluralizationCorrect("PayorVariable", "PayorVariables"));
        }

        [TestMethod]
        public void PluraliseService_table_Earning()
        {
            Assert.IsTrue(IsPluralizationCorrect("Earning", "Earnings"));
        }

        [TestMethod]
        public void PluraliseService_table_payor()
        {
            Assert.IsTrue(IsPluralizationCorrect("Payor", "Payors"));
        }

        [TestMethod]
        public void PluraliseService_table_check()
        {
            Assert.IsTrue(IsPluralizationCorrect("Check", "Checks"));
        }

        [TestMethod]
        public void PluraliseService_table_Email()
        {
            Assert.IsTrue(IsPluralizationCorrect("Email", "Emails"));
        }

        [TestMethod]
        public void PluraliseService_table_PayPeriod()
        {
            Assert.IsTrue(IsPluralizationCorrect("PayPeriod", "PayPeriods"));
        }

        [TestMethod]
        public void PluraliseService_table_Employees()
        {
            Assert.IsTrue(IsPluralizationCorrect("Employee", "Employees"));
        }

        [TestMethod]
        public void PluraliseService_table_Address()
        {
            Assert.IsTrue(IsPluralizationCorrect("Address","Addresses") );
        }

        [TestMethod]
        public void PluraliseService_table_TimePunch()
        {
            Assert.IsTrue(IsPluralizationCorrect("TimePunch", "TimePunches"));
        }

        [TestMethod]
        public void PluraliseService_table_Phone()
        {
            Assert.IsTrue(IsPluralizationCorrect("Phone", "Phones"));
        }

        [TestMethod]
        public void PluraliseService_table_EmployeeDeduction()
        {
            Assert.IsTrue(IsPluralizationCorrect("EmployeeDeduction", "EmployeeDeductions"));
        }

        [TestMethod]
        public void PluraliseService_table_EmployeeChangeLog()
        {
            Assert.IsTrue(IsPluralizationCorrect("EmployeeChangeLog", "EmployeeChangeLogs"));
        }

        [TestMethod]
        public void PluraliseService_table_UserAccess()
        {
            Assert.IsTrue(IsPluralizationCorrect("UserAccess", "UserAccesses"));
        }

        [TestMethod]
        public void PluraliseService_table_FedTaxTable()
        {
            Assert.IsTrue(IsPluralizationCorrect("FedTaxTable", "FedTaxTables"));
        }

        [TestMethod]
        public void PluraliseService_table_FedAllowance()
        {
            Assert.IsTrue(IsPluralizationCorrect("FedAllowance", "FedAllowances"));
        }


        [TestMethod]
        public void PluraliseService_table_Token()
        {
            Assert.IsTrue(IsPluralizationCorrect("Token", "Tokens"));
        }






    }
}
