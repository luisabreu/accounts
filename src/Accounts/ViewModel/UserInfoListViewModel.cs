using System.Collections.Generic;
using Accounts.Model;

namespace Accounts.ViewModel {
    public class UserInfoListViewModel {
        public IEnumerable<UserInfo> Users { get; set; }
    }
}