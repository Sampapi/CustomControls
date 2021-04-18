using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using System;

namespace ViewModels
{
    public abstract class ViewModelBase : BindableBase, IDestructible, INavigationAware, IConfirmNavigationRequest
    {
        public const int NoId = 0;
        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }

        #region Navigation
        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
        #endregion
    }
}
