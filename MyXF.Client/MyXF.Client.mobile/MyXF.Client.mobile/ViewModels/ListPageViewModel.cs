using MyXF.Client.mobile.Models;
using MyXF.Client.mobile.Services.User;
using MyXF.Client.mobilebase.Helper;
using MyXF.Client.mobilebase.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyXF.Client.mobile.ViewModels
{
    public class ListPageViewModel : ViewModelBase
    {
        private IList<User> _users;
        public IList<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new ObservableCollection<User>();
                return _users;
            }
            set
            {
                _users = value;
            }
        }

        private readonly IUserService _userService;
        public ListPageViewModel(IUserService userService)
        {
            _userService = userService;
        }
        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var result = await _userService.Get(PriorityType.UserInitiated);
            foreach (var item in result)
                Users.Add(item);
            IsBusy = false;
        }
    }
}