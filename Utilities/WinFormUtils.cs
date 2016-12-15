using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Utilities
{
    public class WinFormUtils
    {
        public static void ClearFields(Control controlContainer)
        {
            foreach (Control control in controlContainer.Controls)
            {
                var textEdit = control as TextEdit;
                if (textEdit != null)
                {
                    if (textEdit.EditorTypeName == "TextEdit")
                    {
                        if (textEdit.Name.Substring(0, 1) == "i")
                        {
                            textEdit.EditValue = "";
                        }
                        if (textEdit.Name.Substring(0, 1) == "n")
                        {
                            textEdit.EditValue = 0.00m;
                        }
                        if (textEdit.Name.Substring(0, 1) == "e")
                        {
                            textEdit.EditValue = 0;
                        }
                    }
                }

                var comboBoxEdit = control as ComboBoxEdit;
                if (comboBoxEdit != null)
                {
                    if (textEdit.EditorTypeName == "ComboBoxEdit")
                    {
                        if (comboBoxEdit.Name.Substring(0, 1) == "i")
                        {
                            comboBoxEdit.SelectedIndex = -1;
                        }
                    }
                }


                var lookUpEdit = control as LookUpEdit;
                if (lookUpEdit != null)
                {
                    if (textEdit.EditorTypeName == "LookUpEdit")
                    {
                        if (lookUpEdit.Name.Substring(0, 1) == "i")
                        {
                            lookUpEdit.EditValue = null;
                        }
                    }
                }

                var memoEdit = control as MemoEdit;
                if (memoEdit != null)
                {
                    if (textEdit.EditorTypeName == "MemoEdit")
                    {
                        if (memoEdit.Name.Substring(0, 1) == "i")
                        {
                            memoEdit.EditValue = "";
                        }
                    }
                }

                var dateEdit = control as DateEdit;
                if (dateEdit != null)
                {
                    if (dateEdit.EditorTypeName == "DateEdit")
                    {
                        if (dateEdit.Name.Substring(0, 1) == "i")
                        {
                            dateEdit.EditValue = null;
                        }

                    }
                }

                var searchLookUpEdit = control as SearchLookUpEdit;
                if (searchLookUpEdit != null)
                {
                    if (searchLookUpEdit.EditorTypeName == "SearchLookUpEdit")
                    {
                        if (searchLookUpEdit.Name.Substring(0, 1) == "i")
                        {
                            searchLookUpEdit.EditValue = null;
                        }
                    }
                }
            }            
        }
        public static void ReadOnlyFields(Control controlContainer, bool readOnly)
        {
            foreach (Control control in controlContainer.Controls)
            {                
                var textEdit = control as TextEdit;
                if (textEdit != null)
                {
                    if (textEdit.EditorTypeName == "TextEdit")
                    {
                        if (textEdit.Name.Substring(0, 1) == "i")
                        {
                            textEdit.Properties.ReadOnly = readOnly;
                        }
                        if (textEdit.Name.Substring(0, 1) == "n")
                        {
                            textEdit.Properties.ReadOnly = readOnly;
                        }
                        if (textEdit.Name.Substring(0, 1) == "e")
                        {
                            textEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }

                var comboBoxEdit = control as ComboBoxEdit;
                if (comboBoxEdit != null)
                {
                    if (textEdit.EditorTypeName == "ComboBoxEdit")
                    {
                        if (comboBoxEdit.Name.Substring(0, 1) == "i")
                        {
                            comboBoxEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }


                var lookUpEdit = control as LookUpEdit;
                if (lookUpEdit != null)
                {
                    if (textEdit.EditorTypeName == "LookUpEdit")
                    {
                        if (lookUpEdit.Name.Substring(0, 1) == "i")
                        {
                            lookUpEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }

                var memoEdit = control as MemoEdit;
                if (memoEdit != null)
                {
                    if (textEdit.EditorTypeName == "MemoEdit")
                    {
                        if (memoEdit.Name.Substring(0, 1) == "i")
                        {
                            memoEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }

                var dateEdit = control as DateEdit;
                if (dateEdit != null)
                {
                    if (dateEdit.EditorTypeName == "DateEdit")
                    {
                        if (dateEdit.Name.Substring(0, 1) == "i")
                        {
                            dateEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }

                var searchLookUpEdit = control as SearchLookUpEdit;
                if (searchLookUpEdit != null)
                {
                    if (searchLookUpEdit.EditorTypeName == "SearchLookUpEdit")
                    {
                        if (searchLookUpEdit.Name.Substring(0, 1) == "i")
                        {
                            searchLookUpEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }

                var checkEdit = control as CheckEdit;
                if (checkEdit != null)
                {
                    if (checkEdit.EditorTypeName == "CheckEdit")
                    {
                        if (checkEdit.Name.Substring(0, 1) == "i")
                        {
                            checkEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }

                var timeEdit = control as TimeEdit;
                if (timeEdit != null)
                {
                    if (timeEdit.EditorTypeName == "TimeEdit")
                    {
                        if (timeEdit.Name.Substring(0, 1) == "i")
                        {
                            timeEdit.Properties.ReadOnly = readOnly;
                        }
                    }
                }
            }
        }
        public static bool ValidateFieldsNotEmpty(Control controlContenedor, DXErrorProvider errorProvider)
        {

            bool estado = true;
            int nError = 0;

            foreach (Control control in controlContenedor.Controls)
            {
                var textEdit = control as TextEdit;
                if (textEdit != null && textEdit.Tag != null)
                {
                    if (textEdit.EditorTypeName == "TextEdit" && textEdit.Name.Substring(0, 1) == "i")
                    {
                        if (string.IsNullOrEmpty(textEdit.Text.Trim()))
                        {
                            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                            errorProvider.SetError(control, textEdit.Tag.ToString());
                            nError = nError + 1;
                        }
                        else
                        {
                            errorProvider.SetError(control, string.Empty);
                        }                      
                    }

                    if (textEdit.EditorTypeName == "TextEdit" && textEdit.Name.Substring(0, 1) == "n")
                    {
                        if ((decimal)textEdit.EditValue == 0.00m)
                        {
                            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                            errorProvider.SetError(control, textEdit.Tag.ToString());
                            nError = nError + 1;
                        }
                        else
                        {
                            errorProvider.SetError(control, string.Empty);
                        }                       
                    }

                    if (textEdit.EditorTypeName == "TextEdit" && textEdit.Name.Substring(0, 1) == "e")
                    {

                        if ((int)textEdit.EditValue == 0)
                        {
                            errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                            errorProvider.SetError(control, textEdit.Tag.ToString());
                            nError = nError + 1;
                        }
                        else
                        {
                            errorProvider.SetError(control, string.Empty);
                        }                        
                    }

                }

                var lookUpEdit = control as LookUpEdit;
                if (lookUpEdit != null)
                {
                    if (lookUpEdit.EditorTypeName == "LookUpEdit")
                    {
                        if (lookUpEdit.Tag != null)
                        {
                            if (lookUpEdit.EditValue == null)
                            {
                                errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                                errorProvider.SetError(control, lookUpEdit.Tag.ToString());
                                nError = nError + 1;
                            }
                            else
                            {
                                errorProvider.SetError(control, string.Empty);
                            }

                        }
                    }
                }

                var comboBoxEdit = control as ComboBoxEdit;
                if (comboBoxEdit != null)
                {
                    if (comboBoxEdit.EditorTypeName == "ComboBoxEdit")
                    {
                        if (comboBoxEdit.Tag != null)
                        {
                            if (comboBoxEdit.Text.Length == 0)
                            {
                                errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                                errorProvider.SetError(control, comboBoxEdit.Tag.ToString());
                                nError = nError + 1;
                            }
                            else
                            {
                                errorProvider.SetError(control, string.Empty);
                            }

                        }
                    }
                }

                var memoEdit = control as MemoEdit;
                if (memoEdit != null)
                {
                    if (memoEdit.EditorTypeName == "MemoEdit")
                    {
                        if (memoEdit.Tag != null)
                        {
                            if (memoEdit.EditValue == null)
                            {
                                errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                                errorProvider.SetError(control, memoEdit.Tag.ToString());
                                nError = nError + 1;
                            }
                            else
                            {
                                errorProvider.SetError(control, string.Empty);
                            }

                        }
                    }
                }

                var dateEdit = control as DateEdit;
                if (dateEdit != null)
                {
                    if (dateEdit.EditorTypeName == "DateEdit")
                    {
                        if (dateEdit.Tag != null)
                        {
                            if (dateEdit.EditValue == null)
                            {
                                errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                                errorProvider.SetError(control, dateEdit.Tag.ToString());
                                nError = nError + 1;
                            }
                            else
                            {
                                errorProvider.SetError(control, string.Empty);
                            }

                        }
                    }
                }

                var searchLookUpEdit = control as SearchLookUpEdit;
                if (searchLookUpEdit != null)
                {
                    if (searchLookUpEdit.EditorTypeName == "SearchLookUpEdit")
                    {
                        if (searchLookUpEdit.Tag != null)
                        {
                            if (searchLookUpEdit.EditValue == null || Convert.ToInt32(searchLookUpEdit.EditValue)==0)
                            {
                                errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                                errorProvider.SetError(control, searchLookUpEdit.Tag.ToString());
                                nError = nError + 1;
                            }
                            else
                            {
                                errorProvider.SetError(control, string.Empty);
                            }

                        }
                    }
                }

                var buttonEdit = control as ButtonEdit;
                if (buttonEdit != null)
                {
                    if (buttonEdit.EditorTypeName == "ButtonEdit")
                    {
                        if (buttonEdit.Tag != null)
                        {
                            //if (buttonEdit.EditValue == null || string.IsNullOrEmpty((string)buttonEdit.EditValue))
                            if (buttonEdit.Text.Trim().Length == 0)
                            {
                                errorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                                errorProvider.SetError(control, buttonEdit.Tag.ToString());
                                nError = nError + 1;
                            }
                            else
                            {
                                errorProvider.SetError(control, string.Empty);
                            }

                        }
                    }
                }
            }

            if (nError > 0)
            {
                estado = false;
            }

            return estado;
        }
        public static void SetStyleController(Control parent, StyleController styleController)
        {
            styleController.AppearanceFocused.BackColor = Color.FromArgb(255,217,109);
            styleController.AppearanceFocused.BackColor2 = Color.FromArgb(255, 227, 116);
            styleController.AppearanceFocused.ForeColor = Color.Black;

            foreach (Control control in parent.Controls)
            {
                var baseControl = control as BaseControl;
                if (baseControl != null)

                    baseControl.StyleController = styleController;

                SetStyleController(control, styleController);

            }

        }
        public static void SetEnterMoveNextControl(Control controlContainer, bool enterMoveNextControl)
        {
            foreach (Control control in controlContainer.Controls)
            {
                var textEdit = control as TextEdit;
                if (textEdit != null && textEdit.EditorTypeName == "TextEdit")
                {
                    textEdit.EnterMoveNextControl = enterMoveNextControl;
                }

                var comboBoxEdit = control as ComboBoxEdit;
                if (comboBoxEdit != null && textEdit.EditorTypeName == "ComboBoxEdit")
                {
                    comboBoxEdit.EnterMoveNextControl = enterMoveNextControl;
                }

                var lookUpEdit = control as LookUpEdit;
                if (lookUpEdit != null && textEdit.EditorTypeName == "LookUpEdit")
                {
                    lookUpEdit.EnterMoveNextControl = enterMoveNextControl;
                }

                //var memoEdit = control as MemoEdit;
                //if (memoEdit != null && textEdit.EditorTypeName == "MemoEdit")
                //{
                //    memoEdit.EnterMoveNextControl = enterMoveNextControl;
                //}

                var dateEdit = control as DateEdit;
                if (dateEdit != null && dateEdit.EditorTypeName == "DateEdit")
                {
                    dateEdit.EnterMoveNextControl = enterMoveNextControl;
                }

                var searchLookUpEdit = control as SearchLookUpEdit;
                if (searchLookUpEdit != null && searchLookUpEdit.EditorTypeName == "SearchLookUpEdit")
                {
                    searchLookUpEdit.EnterMoveNextControl = enterMoveNextControl;
                }

                var checkEdit = control as CheckEdit;
                if (checkEdit != null && checkEdit.EditorTypeName == "CheckEdit")
                {
                    checkEdit.EnterMoveNextControl = enterMoveNextControl;
                }

                var buttonEdit = control as ButtonEdit;
                if (buttonEdit != null && buttonEdit.EditorTypeName == "ButtonEdit")
                {
                    buttonEdit.EnterMoveNextControl = enterMoveNextControl;
                }

            }
        }
        public static void ErrorMessage(string msg)
        {
            XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ErrorMessage(string msg, string titleMsg)
        {
            XtraMessageBox.Show(msg, titleMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MessageInformation(string msg)
        {
            XtraMessageBox.Show(msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MessageInformation(string msg, string titleMsg)
        {
            XtraMessageBox.Show(msg, titleMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MessageWarning(string msg)
        {
            XtraMessageBox.Show(msg, "Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MessageWarning(string msg, string titleMsg)
        {
            XtraMessageBox.Show(msg, titleMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult MessageQuestion(string msg)
        {
            //System.Media.SystemSounds.Exclamation.Play();
            return XtraMessageBox.Show(msg, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult MessageQuestion(string msg, string title)
        {
            //System.Media.SystemSounds.Exclamation.Play();
            return XtraMessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        public static string ConvertirCriterioDinamico(string valorBusqueda, string nombreCampo)
        {
            string expresionAunEspacio = Regex.Replace(valorBusqueda, @"\s+", " ").Trim();
            string[] palabras = expresionAunEspacio.Split(' ');
            string condicionDinamica = string.Empty;
            foreach (string palabra in palabras)
            {
                condicionDinamica = string.Format("{0}{1} LIKE '%{2}%' AND ", condicionDinamica, nombreCampo, palabra);
            }
            condicionDinamica = condicionDinamica.Substring(0, condicionDinamica.Length - 5);
            return condicionDinamica;
        }
    }
}