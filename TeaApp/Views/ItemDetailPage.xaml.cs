using TeaApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TeaApp.DataModel;
using TeaApp.Util;
using Windows.Storage;
using Windows.UI.Xaml.Documents;

// “项详细信息页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234232 上提供

namespace TeaApp
{
    /// <summary>
    /// 显示组内某一项的详细信息的页面。
    /// </summary>
    public sealed partial class ItemDetailPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// NavigationHelper 在每页上用于协助导航和
        /// 进程生命期管理
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// 可将其更改为强类型视图模型。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public ItemDetailPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;

        }

        /// <summary>
        /// 使用在导航过程中传递的内容填充页。  在从以前的会话
        /// 重新创建页时，也会提供任何已保存状态。
        /// </summary>
        /// <param name="sender">
        /// 事件的来源; 通常为 <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">事件数据，其中既提供在最初请求此页时传递给
        /// <see cref="Frame.Navigate(Type, Object)"/> 的导航参数，又提供
        /// 此页在以前会话期间保留的状态的
        /// 字典。 首次访问页面时，该状态将为 null。</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            ItemDetailViewModel model = e.NavigationParameter as ItemDetailViewModel;

            this.DefaultViewModel["Items"] = model.Items;
            this.DefaultViewModel["Title"] = model.Title;
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

        //private /*async*/ void ListView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    DetailItem item = e.ClickedItem as DetailItem;

        //    if(item != null)
        //    {
        //        webView.Navigate(new Uri(new Uri("ms-appx-web:///"),item.Content));
        //    }
            
        //    //Windows.Storage.Streams.IRandomAccessStream randAccStream =
        //    //await new TextContentUtil().GetRandomFile("Data/TasteTea/泡茶.rtf");

        //    //this.DescriptionBox.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);

        //    //DescriptionBox.Blocks.Clear();

        //    //BlockCollectionResolver resolver = new BlockCollectionResolver();

        //    //List<Paragraph> ps = await resolver.Resolver("TasteTea/煎茶.xaml");

        //    //foreach (var item in ps)
        //    //{
        //    //    this.DescriptionBox.Blocks.Add(item);
        //    //}

        //}

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count != 0)
            { 
                DetailItem item = e.AddedItems[0] as DetailItem;

                if (item != null && item.Content.EndsWith(".html"))
                {
                    webView.Navigate(new Uri(new Uri("ms-appx-web:///"), item.Content));
                }
            }
        }

        private void itemsList_Loaded(object sender, RoutedEventArgs e)
        {
            itemsList.SelectedIndex = 0;
        }
    }
}