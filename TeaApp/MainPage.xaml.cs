using TeaApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using TeaApp.DataModel;
using TeaApp.Views;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace TeaApp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private NavigationHelper navigationHelper;
        
        public MainPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            List<TeaTopicItem> items = TeaTopicDataSource.GetTopicItems();

            this.defaultViewModel["Items"] = items;
        }

        /// <summary>
        /// NavigationHelper 在每页上用于协助导航和
        /// 进程生命期管理
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel { get { return this.defaultViewModel; } }

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            TeaTopicItem item = e.ClickedItem as TeaTopicItem;

            ItemDetailViewModel model = new ItemDetailViewModel();

            switch (item.Title)
            {
                case "饮茶":
                    //List<DetailItem> items = await new TeaDrinkDataSource().GetTeaItemsSaync();

                    //model.Items = items;
                    //model.Title = "饮茶";
                    TeaDrinkDataSource dataSource = new TeaDrinkDataSource();
                    List<DetailItem> items = await dataSource.GetTeaItemsSaync();
                    this.Frame.Navigate(typeof(DrinkTeaPage),items);
                    break;
                case "追茶":
                    this.Frame.Navigate(typeof(FollowTeaPage));
                    break;
                case "品茶":
                    //List<DetailItem> list = await new TasteTeaDataSource().GetTasteTeaItems();
                    //model.Items = list;
                    //model.Title = "品茶";
                    this.Frame.Navigate(typeof(TasteTeaPage));
                    break;
                case "说茶":
                    this.Frame.Navigate(typeof(TalkTeaPage));
                    break;
                case "聊天室":
                    this.Frame.Navigate(typeof(ChatRoomPage));
                    break;
                default:
                    break;
            }
        }

        #region NavigationHelper 注册

        /// 此部分中提供的方法只是用于使
        /// NavigationHelper 可响应页面的导航方法。
        /// 
        /// 应将页面特有的逻辑放入用于
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// 和 <see cref="GridCS.Common.NavigationHelper.SaveState"/> 的事件处理程序中。
        /// 除了在会话期间保留的页面状态之外
        /// LoadState 方法中还提供导航参数。

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
