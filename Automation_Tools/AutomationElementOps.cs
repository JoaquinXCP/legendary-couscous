using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Automation_Tools
{
    public static class AutomationElementOps
    {
        public static void waitForAutomationElement(AutomationElement auto_Elem)
        {



            bool ventanaCargada = false;

            while (ventanaCargada == false)
            {
                try
                {
                    if (auto_Elem == null)
                    {

                        continue;
                    }
                    ventanaCargada = true;
                }
                catch (Exception)
                {

                    ventanaCargada = false;

                }


            }

        }

        public static void waitForAutomationElementDissapear(AutomationElement auto_Elem)
        {



            bool aeVisible = true;

            while (aeVisible == true)
            {
                try
                {
                    if (auto_Elem != null)
                    {

                        continue;
                    }
                    aeVisible = true;
                }
                catch (Exception)
                {

                    aeVisible = true;

                }


            }

        }

        public static void clicAction(AutomationElement autoElem)
        {
            (autoElem.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern).Invoke();

        }

        public static void setValue(AutomationElement automElem, string value)
        {



            (automElem.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).SetValue(value);


        }

        public static void closeWindow(AutomationElement window)
        {


            (window.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern).Close();



        }

        public static void selectItem(AutomationElement autoElem)
        {

            (autoElem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern).Select();


        }

        #region Clic en otro hilo

        private static AutomationElement test = null;
        static bool cliqueado = false;
        public static void clicAE()
        {


            cliqueado = false;
            Thread hilo = new Thread(clic);
            try
            {
                hilo.Start();
                while (cliqueado == false)
                {
                    Console.WriteLine(hilo.ExecutionContext);
                   
                }
            }
            catch (Exception)
            {

            }

        }
        public static void prepararAE(AutomationElement auto_Elem)
        {
            test = auto_Elem;
        }

        private static void clic()
        {
            (test.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern).Invoke();
            cliqueado = true;
        }

        #endregion
    }
}

