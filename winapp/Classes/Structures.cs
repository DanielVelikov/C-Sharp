using System;
using System.Collections.ObjectModel;

namespace winapp.Classes
{
    internal class Companies
    {
        internal long lID { get; }
        internal long lUpdateCounter { get; }
        internal string szName { get; }
        internal long lCityID { get; }
        internal long lFieldID { get; }
        internal string szAddress { get; }
        internal string szCityName { get; set; }

        internal long getUpdateCounter()
        {
            return lUpdateCounter;
        }

        internal string getName()
        {
            return szName;
        }

        internal long getCityID()
        {
            return lCityID;
        }

        internal long getFieldID()
        {
            return lFieldID;
        }

        internal string getAddress()
        {
            return szAddress;
        }
        internal Companies(object ID, object UpdateCounter, object Name, object CityID, object FieldID, object Address)
        {
            lID = (long)(int)ID;
            lUpdateCounter = (long)(int)UpdateCounter;
            szName = (string)Name;
            lCityID = (long)(int)CityID;
            lFieldID = (long)(int)FieldID;
            szAddress = (string)Address;
        }

    }

    internal class Transactions
    {
        internal long lID { get; set; }
        internal long lUpdateCounter { get; set; }
        internal string szName { get; set; }
        internal long lTransactionTypeID { get; set; }
        internal long lAccountID { get; set; }
        internal double dAmount { get; set; }
        internal DateTime TransactionDate { get; set; }
        internal long lProjectID { get; set; }
        internal string szProjectName { get; set; }
        internal string szAccountName { get; set; }
        internal string szTransactionTypeName { get; set; }

        internal long getUpdateCounter()
        {
            return lUpdateCounter;
        }

        internal string getName()
        {
            return szName;
        }

        internal long getTransactionTypeID()
        {
            return lTransactionTypeID;
        }

        internal long getAccountID()
        {
            return lAccountID;
        }

        internal double getAmount()
        {
            return dAmount;
        }

        internal DateTime getDate()
        {
            return TransactionDate;
        }

        internal long getProjectID()
        {
            return lProjectID;
        }


        internal Transactions(object ID, object UpdateCounter, object Name, object TransactionTypeID, object AccountID, object Amount,
                                object date, object ProjectID)
        {
            lID = (long)(int)ID;
            lUpdateCounter = (long)(int)UpdateCounter;
            szName = (string)Name;
            lTransactionTypeID = (long)(int)TransactionTypeID;
            lAccountID = (long)(int)AccountID;
            dAmount = (double)Amount;
            TransactionDate = (DateTime)date;
            lProjectID = (long)(int)ProjectID;
        }

    }

    internal class Projects
    {
        internal long lID { get;}
        internal long lUpdateCounter { get; set; }
        internal string szName { get; set; }
        internal long lCompanyID { get; }
        internal long lProjectSizeID { get; set; }
        internal DateTime StartDate { get; set; }
        internal DateTime EndDate { get; set; }
        internal string szProjectSizeName { get; set; }

        internal long getUpdateCounter()
        {
            return lUpdateCounter;
        }

        internal string getName()
        {
            return szName;
        }

        internal long getCompanyID()
        {
            return lCompanyID;
        }

        internal long getProjectSizeID()
        {
            return lProjectSizeID;
        }

        internal DateTime getStartDate()
        {
            return StartDate;
        }

        internal DateTime getEndDate()
        {
            return EndDate;
        }

        internal Projects(object ID, object UpdateCounter, object Name, object CompanyID, object ProjectSizeID, object Start, object End)
        {
            lID = (long)(int)ID;
            lUpdateCounter = (long)(int)UpdateCounter;
            szName = (string)Name;
            lCompanyID = (long)(int)CompanyID;
            lProjectSizeID = (long)(int)ProjectSizeID;
            StartDate = (DateTime)Start;
            EndDate = (DateTime)End;
        }
    }

    internal class Accounts
    {
        internal long lID { get; }
        long lUpdateCounter;
        internal string szName { get; }
        long lAccountTypeID;
        long lCompanyID;

        internal long getUpdateCounter()
        {
            return lUpdateCounter;
        }
        internal string getName()
        {
            return szName;
        }

        internal long getAccountTypeID()
        {
            return lAccountTypeID;
        }

        internal long getCompanyID()
        {
            return lCompanyID;
        }

        internal Accounts(object ID, object UpdateCounter, object Name, object AccountTypeID, object CompanyID)
        {
            lID = (long)(int)ID;
            lUpdateCounter = (long)(int)UpdateCounter;
            szName = (string)Name;
            lAccountTypeID = (long)(int)AccountTypeID;
            lCompanyID = (long)(int)CompanyID;
        }
    }

    internal class Fields
    {
        internal long lID { get; }
        long lUpdateCounter;
        long lFieldTypeID;
        internal string szName { get; }
        internal string szImage { get; set; }

        internal long getUpdateCounter()
        {
            return lUpdateCounter;
        }
        internal string getName()
        {
            return szName;
        }
        internal long getFieldTypeID()
        {
            return lFieldTypeID;
        }

        internal Fields(object ID, object UpdateCounter, object FieldTypeID, object Name)
        {
            lID = (long)(int)ID;
            lUpdateCounter = (long)(int)UpdateCounter;
            szName = (string)Name;
            lFieldTypeID = (long)(int)FieldTypeID;
        }
    }

    internal class Cities
    {
        internal long lID { get; }
        long lUpdateCounter;
        string szName;
        string szRegion;

        internal long getUpdateCounter()
        {
            return lUpdateCounter;
        }

        internal string getName()
        {
            return szName;
        }

        internal string getRegion()
        {
            return szRegion;
        }

        internal Cities(object ID, object UpdateCounter, object Name, object Region)
        {
            lID = (long)(int)ID;
            lUpdateCounter = (long)(int)UpdateCounter;
            szName = (string)Name;
            szRegion = (string)Region;
        }
    }

    internal class FieldTypes
    {
        internal long lID { get; }
        internal string szFieldType { get; }

        internal FieldTypes(object ID, object Type)
        {
            lID = (long)(int)ID;
            szFieldType = (string)Type;
        }
    }

    internal class ProjectSizes
    {
        internal long lID { get; }
        internal string szProjectSize { get; }

        internal ProjectSizes(object ID, object Type)
        {
            lID = (long)(int)ID;
            szProjectSize = (string)Type;
        }
    }

    internal class TransactionTypes
    {
        internal long lID { get; }
        internal string szName { get; }

        internal TransactionTypes(object ID, object Type)
        {
            lID = (long)(int)ID;
            szName = (string)Type;
        }
    }

    internal class AccountTypes
    {
        internal long lID { get; }
        internal string szName { get; }

        internal AccountTypes(object ID, object Type)
        {
            lID = (long)(int)ID;
            szName = (string)Type;
        }
    }

}
