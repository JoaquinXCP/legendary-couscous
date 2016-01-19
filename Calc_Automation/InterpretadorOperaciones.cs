using Automation_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
namespace Calc_Automation
{
    enum OperacionesAritmeticas
    {
        SUMA, RESTA, MULTIPLICACION, DIVISION
    }
    public class InterpretadorOperaciones
    {
        
        AutomationElement _Calc { get; set; }

        AutomationElement button_current { get; set; }

        InvokePattern clicButton { get; set; }

        private OperacionesAritmeticas operacionAritmetica(string operacion)
        {
            OperacionesAritmeticas aux = new OperacionesAritmeticas();
            if (operacion.Contains("+"))
            {
                aux = OperacionesAritmeticas.SUMA;
            }
            if (operacion.Contains("-"))
            {
                aux = OperacionesAritmeticas.RESTA;
            }
            if (operacion.Contains("*"))
            {
                aux = OperacionesAritmeticas.MULTIPLICACION;
            }
            if (operacion.Contains("/"))
            {
                aux = OperacionesAritmeticas.DIVISION;
            }
            return aux;
        }

        private bool calcMainWindowReady()
        {
            bool vacio = true;

            Predicate<AutomationElement> automationElementVacio = x => x == null;
            _Calc = AutomationElementFactory.automationElementByProcessName("calc");
                //(from AutomationElement ae in AutomationElement.RootElement.FindAll(TreeScope.Children, ConditionFactory.conditionByClassname("CalcFrame")) where ae != null select ae).FirstOrDefault();
            vacio = automationElementVacio.Invoke(_Calc);
            return vacio;
            

            
        }

        void clic_Action(string nameCurrentButton)
        {

            button_current = (from AutomationElement _ae in (from AutomationElement ae in _Calc.FindAll(TreeScope.Children, ConditionFactory.conditionByControlType(ControlType.Pane)) where ae != null select ae).FirstOrDefault().FindAll(TreeScope.Children, ConditionFactory.conditionByName(nameCurrentButton)) where _ae != null select _ae).FirstOrDefault();

            clicButton = button_current.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;

            clicButton.Invoke();
        }
        void ingresarOperacion(string operacion, OperacionesAritmeticas tipoOperacion)
        {
            string primerCifra;
            string segundaCifra;
            String[] caracteres = new String[2];

            #region SWITCH TIPO OPERACION
            switch (tipoOperacion)
            {

                case OperacionesAritmeticas.SUMA:
                    caracteres = operacion.Split('+');
                    break;
                case OperacionesAritmeticas.RESTA:
                    caracteres = operacion.Split('-');

                    break;
                case OperacionesAritmeticas.MULTIPLICACION:
                    caracteres = operacion.Split('*');

                    break;
                case OperacionesAritmeticas.DIVISION:
                    caracteres = operacion.Split('/');

                    break;
            }
            #endregion

            primerCifra = caracteres[0];
            segundaCifra = caracteres[1];
            foreach (char letra in primerCifra)
            {

                clic_Action(letra.ToString());

            }
            switch (tipoOperacion)
            {

                case OperacionesAritmeticas.SUMA:
                    clic_Action("Sumar");

                    break;
                case OperacionesAritmeticas.RESTA:
                    clic_Action("Restar");


                    break;
                case OperacionesAritmeticas.MULTIPLICACION:
                    clic_Action("Multiplicar");
                    break;
                case OperacionesAritmeticas.DIVISION:
                    clic_Action("Dividir");
                    break;
            }
            foreach (char letra in segundaCifra)
            {

                clic_Action(letra.ToString());

            }
            //Botón igual
            clic_Action("Igual a");


        }
        public InterpretadorOperaciones(string operacion_)
        {

            calcMainWindowReady();

            ingresarOperacion(operacion_, operacionAritmetica(operacion_));

            //switch (operacionAritmetica(operacion_))
            //{

            //    case OperacionesAritmeticas.SUMA:

            //        break;
            //    case OperacionesAritmeticas.RESTA:

            //        break;
            //    case OperacionesAritmeticas.MULTIPLICACION:

            //        break;
            //    case OperacionesAritmeticas.DIVISION:

            //        break;
            //}
        }



    }
}
