using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Throw;

namespace HelperLibrary;

public class ThrowMethods
{
    public string NameValidation(string name)
    {
        try
        {
            name.Throw()
                .IfEmpty()
                .IfWhiteSpace()
                .IfEqualsIgnoreCase("Leandro Reis")
                .IfShorterThan(7)
                .IfLongerThan(12)
                .IfContains("xpto");
            return "Ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }


    public string AdultAgeValidation(int age)
    {
        try
        {
            age.Throw()
            .IfNegative()
            .IfLessThan(18)
            .IfGreaterThan(130);
            return "Ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string DateValidation(DateTime date)
    {
        try
        {
            date.ThrowIfNull()
                .IfGreaterThan(p => p.Date, DateTime.Now.AddDays(1));
            return "Ok";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

