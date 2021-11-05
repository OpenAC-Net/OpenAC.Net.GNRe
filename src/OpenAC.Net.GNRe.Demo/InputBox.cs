using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace OpenAC.Net.GNRe.Demo
{
    public static class InputBox
    {
        public static DialogResult Show<T>(string title, string promptText, ref T value)
        {
            var form = GetForm(title, promptText, out var size);
            Control control;

            switch (value)
            {
                case bool bValue:
                    control = new CheckBox();
                    ((CheckBox)control).Checked = bValue;
                    control.SetBounds(12, 30 + (int)size.Height, 372, 20);
                    control.Anchor |= AnchorStyles.Right;
                    break;

                default:
                    control = new TextBox();
                    control.Text = value.ToString();
                    control.SetBounds(12, 30 + (int)size.Height, 372, 20);
                    control.Anchor |= AnchorStyles.Right;
                    break;
            }

            form.Controls.Add(control);

            var dialogResult = form.ShowDialog();

            var type = typeof(T);
            switch (value)
            {
                case bool _:
                    value = (T)Convert.ChangeType(((CheckBox)control).Checked.ToString(CultureInfo.CurrentCulture), type, CultureInfo.CurrentCulture);
                    break;

                default:
                    try
                    {
                        if (type.IsEnum || type.IsGenericType && type.GetGenericArguments()[0].IsEnum)
                        {
                            value = (T)Enum.Parse(type, control.Text);
                        }
                        else
                        {
                            value = (T)Convert.ChangeType(control.Text, type, CultureInfo.CurrentCulture);
                        }
                    }
                    catch (Exception)
                    {
                        value = default;
                    }
                    break;
            }

            return dialogResult;
        }

        private static Form GetForm(string title, string promptText, out SizeF size)
        {
            var form = new Form();
            var label = new Label();
            var buttonOk = new Button();
            var buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOk.Text = @"OK";
            buttonCancel.Text = @"Cancelar";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            var graph = form.CreateGraphics();
            size = graph.MeasureString(promptText, label.Font);

            label.SetBounds(9, 5 + (int)size.Height, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height + (int)size.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            return form;
        }
    }
}