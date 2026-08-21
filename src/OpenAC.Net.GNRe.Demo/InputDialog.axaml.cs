using System;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace OpenAC.Net.GNRe.Demo;

public partial class InputDialog : Window
{
    private bool _confirmed;

    public InputDialog()
    {
        InitializeComponent();
        BtnOk.Click += (_, _) =>
        {
            _confirmed = true;
            Close();
        };
        BtnCancel.Click += (_, _) =>
        {
            _confirmed = false;
            Close();
        };
    }

    public static async Task<(bool confirmed, string value)> ShowTextAsync(Window owner, string title, string prompt, string defaultValue = "")
    {
        var dialog = new InputDialog
        {
            Title = title
        };
        dialog.PromptLabel.Text = prompt;
        dialog.InputTextBox.IsVisible = true;
        dialog.InputTextBox.Text = defaultValue;

        await dialog.ShowDialog(owner);
        return (dialog._confirmed, dialog.InputTextBox.Text ?? string.Empty);
    }

    public static async Task<(bool confirmed, bool value)> ShowBooleanAsync(Window owner, string title, string prompt, bool defaultValue = false)
    {
        var dialog = new InputDialog
        {
            Title = title
        };
        dialog.PromptLabel.Text = prompt;
        dialog.InputCheckBox.IsVisible = true;
        dialog.InputCheckBox.Content = prompt;
        dialog.InputCheckBox.IsChecked = defaultValue;

        await dialog.ShowDialog(owner);
        return (dialog._confirmed, dialog.InputCheckBox.IsChecked ?? false);
    }

    public static async Task ShowMessageAsync(Window owner, string title, string message)
    {
        var dialog = new InputDialog
        {
            Title = title
        };
        dialog.PromptLabel.Text = message;
        dialog.BtnCancel.IsVisible = false;
        dialog.BtnOk.Content = "Fechar";

        await dialog.ShowDialog(owner);
    }
}
