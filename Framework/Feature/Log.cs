using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.DSAUtil;
using FISCA.Authentication;

namespace Framework.Feature
{
    public static class Log
    {
        public static void InsertLog(IEnumerable<LogInfo> logs)
        {
            bool hasLog = false;
            DSXmlHelper request = new DSXmlHelper("InsertRequest");

            foreach ( var log in logs )
            {
                request.AddElement(".", log.BaseElement);
                hasLog = true;
            }
            if ( hasLog )
                DSAServices.CallService("SmartSchool.ApplicationLog.Insert", new DSRequest(request.BaseElement));
        }
        public static void InsertLog(params LogInfo[] logs)
        { 
            InsertLog((IEnumerable<LogInfo> )logs);
        }

    }
}
