using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Automation_Tools
{
    public class AutomationElementFactory
    {
        /// <summary>
        /// AutomationElement from password property enabled.
        /// </summary>
        /// <param name="currentAutomationElement">AutomationElement as starting point of search.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementTypePassword(AutomationElement currentAutomationElement)
        {

            AutomationElementCollection aeCollection = currentAutomationElement.FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection> recorrer = null;
            recorrer = (colection) =>
            {
                foreach (AutomationElement ae in colection)
                {
                    if (ae.Current.IsPassword == true)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition));

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }


            return auto_ElemAux;

        }
        
        /// <summary>
        /// AutomationElement by ProcessName from AutomationElement.RootElement.
        /// </summary>
        /// <param name="processName">Name of Process.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByProcessName(string processName)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByProcessName(processName)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            // AutomationElement by ProcessName from RootElement

        }

        /// <summary>
        /// AutomationElement by ProcessName from AutomationElement.
        /// </summary>
        /// <param name="currentAutomationElement">AutomationElement as starting point of search.</param>
        /// <param name="processName">Name of process.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByProcessName(AutomationElement currentAutomationElement, string processName)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, ConditionFactory.conditionByProcessName(processName)) where ae != null select ae).FirstOrDefault();

            return auto_elem;

        }

        /// <summary>
        /// AutomationElement by ProcessId from AutomationElement.RootElement.
        /// </summary>
        /// <param name="processId">Id of process.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByProcessId(int processId)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByProcessId(processId)) where ae != null select ae).FirstOrDefault();

            return auto_elem;

        }

        /// <summary>
        /// AutomationElement by ProcessId from AutomationElement.
        /// </summary>
        /// <param name="currentAutomationElement">AutomationElement as starting point of search.</param>
        /// <param name="processId">Id of process.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByProcessId(AutomationElement currentAutomationElement, int processId)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, ConditionFactory.conditionByProcessId(processId)) where ae != null select ae).FirstOrDefault();

            return auto_elem;

        }

        /// <summary>
        /// AutomationElement by Name from AutomationElement.RootElement.
        /// </summary>
        /// <param name="name">Name of process.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByName(string name)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByName(name)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            

        }

        /// <summary>
        /// AutomationElement by Name from AutomationElement.
        /// </summary>
        /// <param name="currentAutomationElement">AutomationElement as starting point of search.</param>
        /// <param name="name">Name of process.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByName(AutomationElement currentAutomationElement, string name)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, ConditionFactory.conditionByName(name)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            

        }

        /// <summary>
        ///  AutomationElement by ClassName from AutomationElement.RootElement.
        /// </summary>
        /// <param name="className">ClassName of AutomationElement.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByClassName(string className)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByClassname(className)) where ae != null select ae).FirstOrDefault();

            return auto_elem;

        }

        /// <summary>
        /// AutomationElement by ClassName from AutomationElement.RootElement
        /// </summary>
        /// <param name="currentAutomationElement">AutomationElement as starting point of search.</param>
        /// <param name="className">ClassName of AutomationElement.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByClassName(AutomationElement currentAutomationElement, string className)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, ConditionFactory.conditionByClassname(className)) where ae != null select ae).FirstOrDefault();

            return auto_elem;

        }

        /// <summary>
        /// AutomationElement by ControlType from AutomationElement.RootElement.
        /// </summary>
        /// <param name="controlType">ControlType of AutomationElement.</param>
        /// <returns>AutomationElement</returns>
        public static AutomationElement automationElementByControlType(ControlType controlType)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByControlType(controlType)) where ae != null select ae).FirstOrDefault();

            return auto_elem;

        }

        public static AutomationElement automationElementByControlType(AutomationElement currentAutomationElement, ControlType controlType)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, ConditionFactory.conditionByControlType(controlType)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            // AutomationElement by ControlType from AutomationElement

        }

        public static AutomationElement automationElementByAutomationId(string automationId)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByAutomationId(automationId)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            // AutomationElement by AutomationId from RootElement

        }

        public static AutomationElement automationElementByAutomationId(AutomationElement currentAutomationElement, string automationId)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, ConditionFactory.conditionByAutomationId(automationId)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            // AutomationElement by AutomationId from AutomationElement

        }

        public static AutomationElement automationElementByLocalizedControlType(string localizedControlType)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByLocalizedControlType(localizedControlType)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            // AutomationElement by LocalizedControlType from RootElement

        }

        public static AutomationElement automationElementByLocalizedControlType(AutomationElement currentAutomationElement, string localizedControlType)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, ConditionFactory.conditionByLocalizedControlType(localizedControlType)) where ae != null select ae).FirstOrDefault();

            return auto_elem;
            // AutomationElement by LocalizedControlType from AutomationElement

        }

        public static AutomationElement automationElementByChildrenCount(AutomationElement currentAutomationElement, int childrenCount)
        {

            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, Condition.TrueCondition) where ae.FindAll(TreeScope.Children, Condition.TrueCondition).Count == childrenCount select ae).FirstOrDefault();



            return auto_elem;

            // AutomationElement by ChildrenCount

        }

        public static AutomationElement automationElementByChildProperty(AutomationProperty prop, string value)
        {
            AutomationElement auto_elem = (from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, Condition.TrueCondition) where ae.FindAll(TreeScope.Children, new PropertyCondition(prop, value)).Count == 1 select ae).FirstOrDefault();



            return auto_elem;

            // AutomationElement by ChildProperty from RootElement

        }

        public static AutomationElement automationElementByChildProperty(AutomationElement currentAutomationElement, AutomationProperty prop, string value)
        {
            AutomationElement auto_elem = (from AutomationElement ae in currentAutomationElement.FindAll(TreeScope.Children, Condition.TrueCondition) where ae.FindAll(TreeScope.Children, new PropertyCondition(prop, value)).Count == 1 select ae).FirstOrDefault();



            return auto_elem;
            // AutomationElement by ChildProperty from AutomationElement

        }

        public static AutomationElement findByName(string processName, string nameAE)
        {
            AutomationElementCollection aeCollection = AutomationElementFactory.automationElementByProcessName(processName).FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection, string> recorrer = null;
            recorrer = (collection, nameAux) =>
            {
                foreach (AutomationElement ae in collection)
                {
                    if (ae.Current.Name == nameAux)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition), nameAux);

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection, nameAE);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }

            return auto_ElemAux;
        }

        public static AutomationElement findByName(AutomationElement currentAutomationElement, string nameAE)
        {
            AutomationElementCollection aeCollection = currentAutomationElement.FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection, string> recorrer = null;
            recorrer = (collection, nameAux) =>
            {
                foreach (AutomationElement ae in collection)
                {
                    if (ae.Current.Name == nameAux)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition), nameAux);

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection, nameAE);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }

            return auto_ElemAux;
        }

        public static AutomationElement findByAutomationId(string processName, string automationId)
        {
            AutomationElementCollection aeCollection = AutomationElementFactory.automationElementByProcessName(processName).FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection, string> recorrer = null;
            recorrer = (colection, nameAux) =>
            {
                foreach (AutomationElement ae in colection)
                {
                    if (ae.Current.AutomationId == automationId)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition), nameAux);

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection, automationId);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }


            return auto_ElemAux;



        }

        public static AutomationElement findByAutomationId(AutomationElement currentAutomationElement, string automationId)
        {
            AutomationElementCollection aeCollection = currentAutomationElement.FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection, string> recorrer = null;
            recorrer = (colection, nameAux) =>
            {
                foreach (AutomationElement ae in colection)
                {
                    if (ae.Current.AutomationId == automationId)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition), nameAux);

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection, automationId);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }


            return auto_ElemAux;



        }

        public static AutomationElement findByClassName(string processName, string className)
        {


            AutomationElementCollection aeCollection = AutomationElementFactory.automationElementByProcessName(processName).FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection, string> recorrer = null;
            recorrer = (colection, nameAux) =>
            {
                foreach (AutomationElement ae in colection)
                {
                    if (ae.Current.ClassName == className)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition), nameAux);

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection, className);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }


            return auto_ElemAux;

        }

        public static AutomationElement findByClassName(AutomationElement currentAutomationElement, string className)
        {


            AutomationElementCollection aeCollection = currentAutomationElement.FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection, string> recorrer = null;
            recorrer = (colection, nameAux) =>
            {
                foreach (AutomationElement ae in colection)
                {
                    if (ae.Current.ClassName == className)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition), nameAux);

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection, className);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }


            return auto_ElemAux;

        }

        public static AutomationElement findByClassName(AutomationElement currentAutomationElement, string className, bool isPasswordField)
        {


            AutomationElementCollection aeCollection = currentAutomationElement.FindAll(TreeScope.Children, Automation.RawViewCondition);

            AutomationElement auto_ElemAux = null;
            Action<AutomationElementCollection, string> recorrer = null;
            recorrer = (colection, nameAux) =>
            {
                foreach (AutomationElement ae in colection)
                {
                    if (ae.Current.ClassName == className && ae.Current.IsPassword == isPasswordField)
                    {

                        auto_ElemAux = ae;
                        break;

                    }

                    recorrer.Invoke(ae.FindAll(TreeScope.Children, Automation.RawViewCondition), nameAux);

                }


            };
            foreach (AutomationElement ae_ in aeCollection)
            {

                recorrer.Invoke(aeCollection, className);
                if (auto_ElemAux != null)
                {
                    break;

                }




            }


            return auto_ElemAux;

        }
        


    }
}