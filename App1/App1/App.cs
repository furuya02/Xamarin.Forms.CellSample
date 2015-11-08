using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1 {
    public class App : Application {
        public App() {
            MainPage = new MyPage();
        }
    }
    ////////////////////////////////////////////////////
    //
    //  TextCellのサンプル
    //
    ////////////////////////////////////////////////////


    // データの型定義
    class Data {
        public string Text { get; set; }
        public string Detail { get; set; }
    }

    class MyPage :ContentPage {
        public MyPage() {
            // iOSだけ、上部に余白をとる
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            //データの生成
            var ar = new List<Data>();
            foreach(var n in Enumerable.Range(0, 100)) {
                ar.Add(new Data { Text = "Text-"+n, Detail = "Detail-" + n });

            }
            // ListViewを生成する
            var listView = new ListView {
                ItemsSource = ar,//データソースの指定
                ItemTemplate = new DataTemplate(typeof(TextCell))//テンプレートの指定
            };
            //バインディング指定
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Text");
            listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Detail");
            // テキスト色の指定
            listView.ItemTemplate.SetValue(TextCell.TextColorProperty, Color.Red);
            //ListViewのみをコンテンツとして配置する
            Content = listView;
        }
    }
    /*
    ////////////////////////////////////////////////////
    //
    //  ImageCellのサンプル
    //
    ////////////////////////////////////////////////////
    // データの型定義
    class Data {
        public string Text { get; set; }
        public string Detail { get; set; }
        public string Icon { get; set; }
    }

    class MyPage : ContentPage {
        public MyPage() {
            // iOSだけ、上部に余白をとる
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            //データの生成
            var ar = new List<Data>();
            foreach (var n in Enumerable.Range(0, 100)) {
                ar.Add(new Data { Text = "Text-" + n, Detail = "Detail-" + n , Icon ="icon.png"});

            }
            // ListViewを生成する
            var listView = new ListView {
                ItemsSource = ar,//データソースの指定
                ItemTemplate = new DataTemplate(typeof(ImageCell))//テンプレートの指定
            };
            //バインディング指定
            listView.ItemTemplate.SetBinding(ImageCell.TextProperty, "Text");
            listView.ItemTemplate.SetBinding(ImageCell.DetailProperty, "Detail");
            listView.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "Icon");
            // テキスト色の指定
            listView.ItemTemplate.SetValue(ImageCell.TextColorProperty, Color.Green);
            //ListViewのみをコンテンツとして配置する
            Content = listView;
        }
    }
    */
    /*
    ////////////////////////////////////////////////////
    //
    //  EntryCellのサンプル
    //
    ////////////////////////////////////////////////////
    // データの型定義
    class Data {
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string Text { get; set; }
    }

    class MyPage : ContentPage {
        public MyPage() {
            // iOSだけ、上部に余白をとる
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            //データの生成
            var ar = new List<Data>{
                new Data{Label = "名前", Placeholder = "YAMADA TARO"},
                new Data{Label = "メールアドレス", Placeholder = "user@example.com"},
                new Data{Label = "電話番号", Placeholder = "090-000-0000"},
            };

            // ListViewを生成する
            var listView = new ListView {
                ItemsSource = ar,//データソースの指定
                ItemTemplate = new DataTemplate(typeof(EntryCell))//テンプレートの指定
            };
            //バインディング指定
            listView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "Label");
            listView.ItemTemplate.SetBinding(EntryCell.PlaceholderProperty, "Placeholder");
            //BindingModeでarに戻すように指定しないと設定された値を取り出せない
            listView.ItemTemplate.SetBinding(EntryCell.TextProperty, new Xamarin.Forms.Binding("Text", BindingMode.TwoWay));
            //キーボードを指定する場合
            //listView.ItemTemplate.SetValue(EntryCell.KeyboardProperty, Keyboard.Email);

            //ListViewのみをコンテンツとして配置する
            Content = listView;
        }
    }
    */
    /*
    ////////////////////////////////////////////////////
    //
    //  SwitchCellのサンプル
    //
    ////////////////////////////////////////////////////
    // データの型定義
    class Data {
        public string Label { get; set; }
        public bool Sw { get; set; }
    }

    class MyPage : ContentPage {
        public MyPage() {
            // iOSだけ、上部に余白をとる
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            //データの生成
            var ar = new List<Data>{
                new Data{Label = "AAA", Sw = true},
                new Data{Label = "BBB", Sw = false}
            };

            var listView = new ListView {
                ItemsSource = ar,//データソースの指定
                ItemTemplate = new DataTemplate(typeof(SwitchCell))//テンプレートの指定
            };
            //バインディング指定
            listView.ItemTemplate.SetBinding(SwitchCell.TextProperty, "Label");
            listView.ItemTemplate.SetBinding(SwitchCell.OnProperty, "Sw");//双方向でバインディングされる

            //ListViewのみをコンテンツとして配置する
            Content = listView;
        }
    }
    */
    /*
    ////////////////////////////////////////////////////
    //
    //  ViewCellのサンプル
    //
    ////////////////////////////////////////////////////
    // データの型定義
    class Data {
        public string Icon { get; set; }
        public string No { get; set; }
        public string Message { get; set; }
    }

    class MyPage : ContentPage {
        public MyPage() {
            // iOSだけ、上部に余白をとる
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

            //データの生成
            var ar = new List<Data>();
            foreach (var n in Enumerable.Range(0, 100)) {
                ar.Add(new Data { No = "No. " + n, Message = "Message-" + n, Icon = "icon.png" });

            }

            var listView = new ListView {
                ItemsSource = ar,//データソースの指定
                RowHeight = 60
            };
            listView.ItemTemplate = new DataTemplate(() => {
                var icon = new Image();
                icon.SetBinding( Image.SourceProperty, "Icon");
                var no = new Label() { FontSize = 12 };
                no.SetBinding(Label.TextProperty, "No");
                var message = new Label() { FontSize = 20};
                message.SetBinding(Label.TextProperty, "Message");

                //No Messageを縦に並べたテキストレイアウトを作成する
                var textLayout = new StackLayout {
                    Children = { no, message }
                };

                return new ViewCell {
                    View = new StackLayout {
                        Orientation = StackOrientation.Horizontal,//Iconとテキストレイアウトを横に並べる
                        Padding = new Thickness(20, 10, 0, 0),//パディング
                        Spacing = 10,//スペース
                        Children = {  textLayout,icon }
                    }
                };
            });

            //ListViewのみをコンテンツとして配置する
            Content = listView;
        }
    }
    */
}
