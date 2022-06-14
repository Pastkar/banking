using CommonModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorUI.Models
{
    public class LoginState
    {
        public bool IsLoggedIn{ get; set; }
        public ClientGetModel Client { get; set; }
        public CompanyGetModel Company { get; set; }
        public TypeUser TypeUser { get; set; }

        public event Action OnChange;

        public void SetLoginClient(bool login, ClientGetModel user)
        {
            TypeUser = TypeUser.Client;
            Company = null;
            IsLoggedIn = login;
            Client = user;
            NotifyStateChanged();
        }
        public void SetLoginCompany(bool login, CompanyGetModel user)
        {
            TypeUser = TypeUser.Company;
            Client = null;
            IsLoggedIn = login;
            Company = user;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
        public void LogOut()
        {
            Company = null;
            IsLoggedIn = false;
            Client = null;
            NotifyStateChanged();
        }
    }
}
