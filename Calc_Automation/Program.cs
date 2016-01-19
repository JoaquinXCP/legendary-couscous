using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation_Tools;
using System.Threading;
using System.Windows.Automation;
namespace Calc_Automation
{
    class Program
    {


        static void iniciarHistoria()
        {
            Console.WriteLine("Escribe una operación: ");

        }
        static void iniciar_y_verificar_calc()
        {
            try
            {

                foreach (Process p in Process.GetProcessesByName("calc"))
                {
                    p.Kill();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            try
            {
                Process _calc = new Process();
                _calc.StartInfo.UseShellExecute = true;
                _calc.StartInfo.FileName = "calc.exe";
                _calc.Start();

                while (AutomationElementFactory.automationElementByClassName("CalcFrame") == null)
                {
                    Thread.Sleep(500);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void obtenerResultado()
        {

            Console.Write("\n Resultado: {0}", AutomationElementFactory.findByAutomationId("calc", "150").Current.Name);

        }


        static void Main(string[] args)
        {

            iniciarHistoria();
            string userOp = Console.ReadLine();
            iniciar_y_verificar_calc();
            InterpretadorOperaciones io = new InterpretadorOperaciones(userOp);
            obtenerResultado();
            Console.ReadKey();


        }
    }
}
