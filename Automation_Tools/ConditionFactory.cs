using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Automation_Tools
{
    public class ConditionFactory
    {
        //  Conditions by PropertyConditions

        public static Condition conditionByProcessName(string processName)
        {
            Func<string, int> obtenerProcessIdFromProcessName = x =>
            {
                return (from Process proc in Process.GetProcessesByName(x) where proc != null select proc).FirstOrDefault().Id;
            };

            int processId = obtenerProcessIdFromProcessName(processName);
            Condition cond = new PropertyCondition(AutomationElement.ProcessIdProperty, processId);

            return cond;

        }

        public static Condition conditionByProcessId(int processId)
        {

            Condition cond = new PropertyCondition(AutomationElement.ProcessIdProperty, processId);

            return cond;

        }

        public static Condition conditionByName(string name)
        {
            Condition cond = new PropertyCondition(AutomationElement.NameProperty, name);

            return cond;
        }

        public static Condition conditionByClassname(string classname)
        {

            Condition cond = new PropertyCondition(AutomationElement.ClassNameProperty, classname);

            return cond;


        }

        public static Condition conditionByControlType(ControlType controlType)
        {

            Condition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, controlType);

            return cond;


        }

        public static Condition conditionByAutomationId(string automationId)
        {
            Condition cond = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);

            return cond;

        }

        public static Condition conditionByLocalizedControlType(string LocalizedControlType)
        {
            Condition cond = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, LocalizedControlType);

            return cond;
        }


    }
}