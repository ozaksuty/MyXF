using Acr.UserDialogs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyXF.Client.mobilebase.Services.Dialog
{
    public interface IDialogService : IServiceBase
    {
        Task<string> ActionSheetAsync(string title, string cancel, string destructive, CancellationToken? cancelToken = null, params string[] buttons);
        Task AlertAsync(string message, string title = null, string okText = null, CancellationToken? cancelToken = null);
        Task AlertAsync(AlertConfig config, CancellationToken? cancelToken = null);
        Task<bool> ConfirmAsync(string message, string title = null, string okText = null, string cancelText = null, CancellationToken? cancelToken = null);
        Task<bool> ConfirmAsync(ConfirmConfig config, CancellationToken? cancelToken = null);
        Task<DatePromptResult> DatePromptAsync(string title = null, DateTime? selectedDate = null, CancellationToken? cancelToken = null);
        Task<DatePromptResult> DatePromptAsync(DatePromptConfig config, CancellationToken? cancelToken = null);
        void HideLoading();
        IProgressDialog Loading(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null);
        Task<LoginResult> LoginAsync(string title = null, string message = null, CancellationToken? cancelToken = null);
        Task<LoginResult> LoginAsync(LoginConfig config, CancellationToken? cancelToken = null);
        IProgressDialog Progress(ProgressDialogConfig config);
        IProgressDialog Progress(string title = null, Action onCancel = null, string cancelText = null, bool show = true, MaskType? maskType = null);
        Task<PromptResult> PromptAsync(string message, string title = null, string okText = null, string cancelText = null, string placeholder = "", InputType inputType = InputType.Default, CancellationToken? cancelToken = null);
        Task<PromptResult> PromptAsync(PromptConfig config, CancellationToken? cancelToken = null);
        void ShowLoading(string title = null, MaskType? maskType = null);
        Task<TimePromptResult> TimePromptAsync(TimePromptConfig config, CancellationToken? cancelToken = null);
        Task<TimePromptResult> TimePromptAsync(string title = null, TimeSpan? selectedTime = null, CancellationToken? cancelToken = null);
    }
}