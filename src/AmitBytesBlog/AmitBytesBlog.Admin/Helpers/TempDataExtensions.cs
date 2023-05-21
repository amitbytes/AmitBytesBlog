using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmitBytesBlog.Admin
{
    public static class TempDataExtensions
    {
        public static void SuccessMessage(this TempDataDictionary tempData,string successMessage)
        {
            tempData[UIConstants.SUCCESS_MESSAGE] = successMessage;
        }
        public static string SuccessMessage(this TempDataDictionary tempData)
        {
            return tempData[UIConstants.SUCCESS_MESSAGE] as string;
        }
    }
}
